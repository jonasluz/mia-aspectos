using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorSintaticoLogico
{
    class AnalisadorSintaticoLogico
    {
        private static readonly string S_ERR_INICIOSEMFIM =
            "Os parênteses abertos em %1 não tem fechamento.";
        private static readonly string S_ERR_FIMSEMINICIO =
            "Os parênteses fechados em %1 não foram abertos.";
        private static readonly string S_ERR_OPERADORSEMOPERANDOS =
            "Não há operando para o operador %1 em %2.";
        private static readonly string S_ERR_NEGACAOSEMOPERANDO =
            "A negação em %1 está sem operando.";

        private Stack<Proposicao> m_propTree = new Stack<Proposicao>(1);

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

        public bool Valida(string expr)
        {
            try
            {
                Trace(ref expr); 
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }

            return true;
        }

        private bool Trace(ref string expr)
        {
            bool result = false; 

            Stack<int> openProps = new Stack<int>();
            bool negate = false;
            Proposicao first = null; 
            Operador oper = Operador.NULO;
            string partial;

            switch (expr.Length)
            {
                case 1: // Caso de proposição simples.
                    m_propTree.Push(new Proposicao(expr[0]));
                    return true;

                case 2: // Caso de proposição simples com negação.
                    m_propTree.Push(new Proposicao(expr[1], Alfabeto.OperadorWithToken(expr[0])));
                    return true;

                default: // Demais casos (de 3 tokens acima).
                    int limit = expr.Length - 1;
                    for (int i = 0; i < limit; i++)
                    {
                        char token = expr[i];
                        if (token == Alfabeto.TOKEN_DELIM_ESQ)
                        {
                            if (i == limit)
                                throw new Exception(string.Format(S_ERR_INICIOSEMFIM, i));

                            openProps.Push(i);
                            continue;

                        }
                        else if (token == Alfabeto.TOKEN_DELIM_DIR)
                        {
                            if (openProps.Count == 0)
                                throw new Exception(string.Format(S_ERR_FIMSEMINICIO, i));
                            else
                            {
                                int start = openProps.Pop() + 1;
                                int len = i - start - 1;
                                if (len == 0) continue;     // parênteses vazios.
                                partial = expr.Substring(start, len);
                            }
                        }
                        else
                        {
                            Operador tmpOper = Alfabeto.OperadorWithToken(token);
                            if (tmpOper == Operador.NULO)
                                partial = token.ToString();
                            else if (tmpOper == Operador.NAO)
                            {
                                if (i == limit)
                                    throw new Exception(string.Format(S_ERR_NEGACAOSEMOPERANDO, i));
                                negate = true;
                                partial = expr.Substring(i + 1);
                            }
                            else
                            {
                                if (i == 0 || m_propTree.Count == 0)
                                    throw new Exception(string.Format(S_ERR_OPERADORSEMOPERANDOS, tmpOper, i));
                                else
                                {
                                    first = m_propTree.Pop();
                                    oper = tmpOper;
                                    partial = expr.Substring(i + 1);
                                }
                            }
                        }

                        result = Trace(ref partial);
                        if (negate)
                        {
                            if (m_propTree.Count == 0)
                                throw new Exception(string.Format(S_ERR_NEGACAOSEMOPERANDO, i));
                            first = new Proposicao(m_propTree.Pop(), Operador.NAO);
                            m_propTree.Push(first);
                        }
                        else if (first != null)
                        {
                            if (m_propTree.Count == 0)
                                throw new Exception(string.Format(S_ERR_OPERADORSEMOPERANDOS, oper, i));
                            first = new Proposicao(first, m_propTree.Pop(), oper);
                            m_propTree.Push(first);
                        }
                    }
                    break;
            }
            return result;
        }

    }
}
