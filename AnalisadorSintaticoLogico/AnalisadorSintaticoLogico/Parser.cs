using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorSintaticoLogico
{
    class Parser
    {
        private static readonly string ERR_SIMBOLO =
            "Símbolo {0} inesperado em {1}. São esperados: {2}";
        private static readonly string ERR_SIMBOLODESCONHECIDO =
            "Símbolo {0} em {1} é desconhecido pela linguagem.";
        private static readonly string ERR_PARENTESES =
            "O fechamento dos parênteses está incompleto. Há {0} {1} a mais.";

        public string Error
        {
            get; private set;
        }

        List<Token> tokenized = new List<Token>();
        int opened = 0;

        public bool Tokenize(string expr)
        {
            if (expr.Length == 0)
                return true;

            for(int i = 0; i < expr.Length; i++)
            {
                char token = expr[i];
                Linguagem.Simbolo simbolo = Linguagem.Ling.TokenOf(token);

                if (simbolo == Linguagem.Simbolo.INVALIDO)
                { // Símbolo desconhecido.
                    CreateError(ERR_SIMBOLODESCONHECIDO, token, i);
                    return false;
                }

                bool isValid;
                string valid;
                if (tokenized.Count == 0)
                { // início da expressão.
                    isValid = Linguagem.Ling.EhInicialValida(token);
                    valid = string.Join<Linguagem.Simbolo>(",", Linguagem.Ling.IniciaisValidas);
                } else
                { // intermeio da expressão.
                    Linguagem.Simbolo previous = tokenized.Last().type;
                    isValid = Linguagem.Ling.Follows(simbolo, previous);
                    valid = string.Join<Linguagem.Simbolo>(",", Linguagem.Ling.TiposEsperados[previous]);
                }
                
                if (isValid)
                {
                    tokenized.Add(new Token(simbolo, token));
                } else
                {
                    CreateError(ERR_SIMBOLO, new object[] { token, i, valid });
                    return false;
                }

                if (simbolo == Linguagem.Simbolo.ABERTURA) opened++;
                if (simbolo == Linguagem.Simbolo.FECHAMENTO) opened--;
            }

            if (opened != 0)
            {
                char paren = opened < 1 ? ')' : '(';
                CreateError(ERR_PARENTESES, new object[] { Math.Abs(opened), paren });
                return false;
            }

            return true;
        }

        private void CreateError(string msg, params object[] args)
        {
            Console.WriteLine(msg, args);
            //Error = string.Format(ERR_SIMBOLO, args);
        }
    }
}
