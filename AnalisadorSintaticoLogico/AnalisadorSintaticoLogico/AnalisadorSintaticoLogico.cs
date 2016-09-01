using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorSintaticoLogico
{
    class AnalisadorSintaticoLogico
    {
        #region Mensagens de erro
        private static readonly string S_ERR_INICIOSEMFIM =
            "Os parênteses abertos em {0} não tem fechamento.";
        private static readonly string S_ERR_FIMSEMINICIO =
            "Os parênteses fechados em {0} não foram abertos.";
        private static readonly string S_ERR_FIMPREMATURO =
            "A operação iniciada em {0} encerrou prematuramente.";
        private static readonly string S_ERR_OPERADORSEMOPERANDOS =
            "Não há operando para o operador {0} em {1}.";
        private static readonly string S_ERR_OPERANDOSSEMOPERADOR =
            "Operando em {0} não possui operador.";
        private static readonly string S_ERR_NEGACAOSEMOPERANDO =
            "A negação em {0} está sem operando.";
        private static readonly string S_ERR_NEGACAODEVESERUNARIA =
            "A negação em {0} não deve ter operando anterior.";
        private static readonly string S_ERR_TOKENDESCONHECIDO =
            "O token em {0} não é conhecido.";
        #endregion Mensagens de erro

        #region Classe interna - Operacao
        class Operacao
        {
            #region Atributos
            public bool Valida
            {
                get
                {
                    if (p1 != ' ' && op == Operador.NULO)
                        m_valida = true;

                    return m_valida;
                }
            }
            private bool m_valida = false;

            public bool Aberta
            {
                get
                {
                    return m_aberta;
                }
            }
            private bool m_aberta = true;

            public int Idx
            {
                get; private set;
            }

            #endregion Atributos

            Operador op;
            char p1, p2;

            #region Construtores
            public Operacao(Operacao o)
            {
                Idx = o.Idx;
                op = o.op;
                p1 = o.p1;
                p2 = o.p2;
                m_aberta = o.m_aberta;
                m_valida = o.m_valida;
            }

            public Operacao(int idx, bool opened = true)
            {
                Idx = idx;
                op = Operador.NULO;
                p1 = p2 = ' ';
                m_aberta = opened;
            }
            #endregion Construtores

            public bool Tokenize(char token, int pos)
            {
                bool result = false;

                if (Alfabeto.EhLetraProposicionalValida(token))
                {
                    if (p1 == ' ' && p2 == ' ')
                    {
                        if (op == Operador.NAO)
                        {
                            p2 = token;
                            result = true;
                        }
                        else
                        { // op == nulo.
                            p1 = token;
                        }
                    }
                    else
                    { // p1 ocupado.
                        if (op == Operador.NULO)
                            throw new Exception(string.Format(S_ERR_OPERANDOSSEMOPERADOR, pos));
                        else
                        {
                            p2 = token;
                            result = true;
                        }
                    }
                } else
                { // Não é letra proposicional.
                    op = Alfabeto.OperadorWithToken(token);
                    if (op == Operador.NULO)
                        throw new Exception(string.Format(S_ERR_TOKENDESCONHECIDO, pos));
                    else if (op == Operador.NAO)
                    {
                        if (p1 != ' ')
                            throw new Exception(string.Format(S_ERR_NEGACAODEVESERUNARIA, pos));
                    } else
                    { // operador binário.
                        if (p1 == ' ')
                            throw new Exception(string.Format(S_ERR_OPERADORSEMOPERANDOS, op, pos));
                    }
                }

                m_valida = result;
                return result;
            }

            #region Overriding
            public override string ToString()
            {
                string result = "";

                if (op == Operador.NULO)
                    result += p1;
                else
                {
                    result += "  " + op + "\n";
                    result += op == Operador.NAO ? "  |\n" + p2 + "\n" : " /\\\n" + p1 + "  " + p2;
                }

                return result;
            }
            #endregion Overriding

        }
        #endregion Classe interna - Operacao

        // Pilha de proposições abertas.
        private Stack<Proposicao> m_propTree = new Stack<Proposicao>(1);

        #region Atributos e variáveis públicas

        public string Error
        {
            get; private set;
        }

        public string Tree
        {
            get
            {
                if (m_treeStr.Length == 0) 
                {
                    // TODO
                }
                return m_treeStr;
            }
        }
        private string m_treeStr = "";

        #endregion Atributos e variáveis públicas

        #region Métodos públicos

        public bool Valida(string expr)
        {
            bool result;
            try
            {
                result = Trace(ref expr); 
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }

            return result;
        }

        #endregion Métodos públicos

        #region Métodos privados

        private bool Trace(ref string expr)
        {
            Stack<Operacao> openProps = new Stack<Operacao>();
            Operacao top = null;

            if (expr.Length == 1)
                return Alfabeto.EhLetraProposicionalValida(expr[0]);

            if (expr.Length == 2 && expr[0] == Alfabeto.TokenOfOperador(Operador.NAO))
                return Alfabeto.EhLetraProposicionalValida(expr[1]);

            for (int i = 0; i < expr.Length; i++)
            {
                char token = expr[i];

                if (token == Alfabeto.TOKEN_DELIM_ESQ)
                {
                    if (i == expr.Length - 1)
                        throw new Exception(string.Format(S_ERR_INICIOSEMFIM, i));

                    if (top != null)
                        openProps.Push(new Operacao(top));
                    top = new Operacao(i);

                } else if (token == Alfabeto.TOKEN_DELIM_DIR)
                {
                    if (top == null || !top.Valida)
                        throw new Exception(string.Format(S_ERR_FIMPREMATURO, i));

                    m_treeStr = top + m_treeStr;

                    if (openProps.Count != 0)
                    {
                        top = openProps.Pop();
                        top.Tokenize('a', top.Idx);
                    } else
                        top = null;
                } else
                { // letra proposicional ou operador.
                    if (top == null)
                        top = new Operacao(i, false);
                    top.Tokenize(token, i);
                } 
            }

            int idx =
                top != null && ( top.Aberta || !top.Valida) ? top.Idx
                    : openProps.Count != 0 ? openProps.Pop().Idx
                    : -1;
            if (idx >= 0)
                throw new Exception(string.Format(S_ERR_FIMPREMATURO, idx));

            return true;
        }

        #endregion Métodos privados
    }
}
