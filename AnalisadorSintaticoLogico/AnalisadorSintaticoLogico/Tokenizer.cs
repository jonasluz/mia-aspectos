using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JALJ_MIA_Fundamentos
{
    class Tokenizer
    {

        #region Mensagens de erro
        private static readonly string ERR_SYMBOL =
            "Símbolo {0} inesperado em {1}. São esperados: {2}";
        private static readonly string ERR_UNKNOWNSYMBOL =
            "Símbolo {0} em {1} é desconhecido pela linguagem.";
        private static readonly string ERR_PARENS =
            "O fechamento dos parênteses está incompleto. Há {0} {1} a mais.";
        #endregion Mensagens de erro

        #region Atributos públicos

        public string Error
        {
            get; private set;
        }

        public string Expr
        {
            get; set; 
        }

        public List<Token> Tokenized
        {
            get; private set;
        }

        #endregion Atributos públicos

        #region Construtor
        public Tokenizer()
        {
            Tokenized = new List<Token>();
        }
        #endregion Construtor

        #region Métodos públicos

        public bool Tokenize(string expr = "")
        {
            if (expr != "") Expr = expr;

            int opened = 0;

            for (int i = 0; i < expr.Length; i++)
            {
                char token = expr[i];
                Language.Symbol symbol = Language.Lang.SymbolOf(token);

                if (symbol == Language.Symbol.INVALIDO)
                { // Símbolo desconhecido.
                    CreateError(ERR_UNKNOWNSYMBOL, token, i);
                    return false;
                }

                bool isValid;
                string valid;
                if (Tokenized.Count == 0)
                { // início da expressão.
                    isValid = Language.Lang.IsValidInitial(token);
                    valid = string.Join<Language.Symbol>(",", Language.Lang.Initial);
                }
                else
                { // intermeio da expressão.
                    Language.Symbol previous = Tokenized.Last().type;
                    isValid = Language.Lang.Follows(symbol, previous);
                    valid = string.Join<Language.Symbol>(",", Language.Lang.Expected[previous]);
                }

                if (isValid)
                {
                    Tokenized.Add(new Token(symbol, token));
                }
                else
                {
                    CreateError(ERR_SYMBOL, new object[] { token, i, valid });
                    return false;
                }

                if (symbol == Language.Symbol.ABERTURA) opened++;
                if (symbol == Language.Symbol.FECHAMENTO) opened--;
            }

            if (opened != 0)
            {
                char paren = opened < 1 ? ')' : '(';
                CreateError(ERR_PARENS, new object[] { Math.Abs(opened), paren });
                return false;
            }

            return true;

        }

        #endregion Métodos públicos

        void CreateError(string msg, params object[] args)
        {
            Error = string.Format(msg, args);
        }

    }
}
