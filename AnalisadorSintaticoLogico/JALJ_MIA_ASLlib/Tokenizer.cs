using System;
using System.Collections.Generic;
using System.Linq;

namespace JALJ_MIA_ASLlib
{
    /// <summary>
    /// Extract the tokens from a logic expression.
    /// </summary>
    public class Tokenizer
    {
        #region Error messages
        // Syntax errors messages.
        private static readonly string ERR_SYMBOL =
            "Símbolo {0} inesperado em {1}. São esperados: {2}";
        private static readonly string ERR_UNKNOWNSYMBOL =
            "Símbolo {0} em {1} é desconhecido pela linguagem.";
        private static readonly string ERR_PARENS =
            "O fechamento dos parênteses está incompleto. Há {0} {1} a mais.";
        #endregion Error messages

        #region Public attributes

        /// <summary>
        /// The expression to parse.
        /// </summary>
        public string Expr
        {
            get; set;
        }

        /// <summary>
        /// List of parsing errors.
        /// </summary>
        public List<string> Error
        {
            get; private set;
        }

        /// <summary>
        /// Tokens extracted from parsing.
        /// </summary>
        public List<Token> Tokens
        {
            get; private set;
        }

        #endregion Public attributes.

        #region Constructor
        public Tokenizer()
        {
            Tokens = new List<Token>();
        }
        #endregion Construtor

        #region Public functions

        /// <summary>
        /// Tokenization function
        /// </summary>
        /// <param name="expr">Logic expression to tokenize</param>
        /// <returns>If tokenization succedded. If not, see the erros in Errors attribute.</returns>
        public bool Tokenize(string expr = "")
        {
            if (expr != "") Expr = expr;

            int opened = 0;
            Error = new List<string>();

            // Go through all the expression.
            for (int i = 0; i < expr.Length; i++)
            {
                // Get the symbol of the character in current position.
                char token = expr[i];
                Language.Symbol symbol = Language.Lang.SymbolOf(token);

                if (symbol == Language.Symbol.INVALIDO)
                { // Symbol unknown.
                    CreateError(ERR_UNKNOWNSYMBOL, token, i);
                    continue;
                }

                bool isValid;   // is the token valid to its position? 
                string valid;   // valid tokens for the token's position.
                if (Tokens.Count == 0)
                { // starting of the expression.
                    // Token is a valid initial? 
                    isValid = Language.Lang.IsValidInitial(token);
                    // Get the valid initial tokens set.
                    valid = string.Join<Language.Symbol>(",", Language.Lang.Initial);
                }
                else
                { // middle of the expression.
                    // Token as valid as a follower of the previous symbol? 
                    Language.Symbol previous = Tokens.Last().type;
                    isValid = Language.Lang.Follows(symbol, previous);
                    // Get the valid symbols for the previous one.
                    valid = string.Join<Language.Symbol>(",", Language.Lang.Expected[previous]);
                }

                if (isValid)
                { // token detected as valid.
                    if (symbol != Language.Symbol.VAZIO)        // empty symbols/tokens are ignored.
                        Tokens.Add(new Token(symbol, token));   // add the token to the extracted tokens list.
                }
                else
                { // Token is not valid to its position. 
                    CreateError(ERR_SYMBOL, new object[] { token, i, valid });
                    continue;
                }

                // Add or subtract the opening counting.
                if (symbol == Language.Symbol.ABERTURA) opened++;
                if (symbol == Language.Symbol.FECHAMENTO) opened--;
            }

            if (opened != 0)
            { // Opening and closing counts doesn't match.
                // Gets the exceding symbol/token and create error accordingly.
                char paren = opened < 1 ? ')' : '(';
                CreateError(ERR_PARENS, new object[] { Math.Abs(opened), paren });
            }

            return Error.Count == 0;
        }

        #endregion Public functions

        /// <summary>
        /// Error creation.
        /// </summary>
        /// <param name="msg">Template message.</param>
        /// <param name="args">Error arguments.</param>
        void CreateError(string msg, params object[] args)
        {
            Error.Add(string.Format(msg, args));
        }

    }
}
