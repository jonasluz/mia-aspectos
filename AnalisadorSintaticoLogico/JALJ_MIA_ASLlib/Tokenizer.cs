using System;
using System.Collections.Generic;
using System.Linq;

namespace JALJ_MIA_ASLlib
{
    public class Tokenizer
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

        public List<string> Error
        {
            get; private set;
        }

        public string Expr
        {
            get; set; 
        }

        public List<Token> Tokens
        {
            get; private set;
        }

        #endregion Atributos públicos

        #region Construtor
        public Tokenizer()
        {
            Tokens = new List<Token>();
        }
        #endregion Construtor

        #region Métodos públicos

        public bool Tokenize(string expr = "")
        {
            if (expr != "") Expr = expr;

            int opened = 0;
            Error = new List<string>();

            for (int i = 0; i < expr.Length; i++)
            {
                char token = expr[i];
                Language.Symbol symbol = Language.Lang.SymbolOf(token);

                if (symbol == Language.Symbol.INVALIDO)
                { // Símbolo desconhecido.
                    CreateError(ERR_UNKNOWNSYMBOL, token, i);
                    continue;
                }

                bool isValid;
                string valid;
                if (Tokens.Count == 0)
                { // início da expressão.
                    isValid = Language.Lang.IsValidInitial(token);
                    valid = string.Join<Language.Symbol>(",", Language.Lang.Initial);
                }
                else
                { // intermeio da expressão.
                    Language.Symbol previous = Tokens.Last().type;
                    isValid = Language.Lang.Follows(symbol, previous);
                    valid = string.Join<Language.Symbol>(",", Language.Lang.Expected[previous]);
                }

                if (isValid)
                {
                    if (symbol != Language.Symbol.VAZIO)        // vazios são ignorados.
                        Tokens.Add(new Token(symbol, token));
                }
                else
                {
                    CreateError(ERR_SYMBOL, new object[] { token, i, valid });
                    continue;
                }

                if (symbol == Language.Symbol.ABERTURA) opened++;
                if (symbol == Language.Symbol.FECHAMENTO) opened--;
            }

            if (opened != 0)
            {
                char paren = opened < 1 ? ')' : '(';
                CreateError(ERR_PARENS, new object[] { Math.Abs(opened), paren });
            }

            return Error.Count == 0;

        }

        #endregion Métodos públicos

        void CreateError(string msg, params object[] args)
        {
            Error.Add(string.Format(msg, args));
        }

    }
}
