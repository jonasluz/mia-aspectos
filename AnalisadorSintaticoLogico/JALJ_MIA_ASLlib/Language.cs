using System.Collections.Generic;
using System.Linq;

namespace JALJ_MIA_ASLlib
{
    /// <summary>
    /// The Logic language definition and its syntax rules.
    /// </summary>
    public class Language
    {
        // Symbol type.
        public enum Symbol
        {
            VAZIO, ABERTURA, FECHAMENTO, PROP,
            E, OU, NAO, IMPLICA, EQUIVALENTE,
            INVALIDO, TODOS
        }

        #region Singleton
        /// <summary>
        /// Singleton Instance.
        /// </summary>
        public static Language Lang
        {
            get
            {
                if (s_instance == null) s_instance = new Language();
                return s_instance;
            }
        }
        private static Language s_instance;
        #endregion Singleton

        #region Public attributes

        /// <summary>
        /// Array of the valid propositional letters part of the syntax.
        /// </summary>
        public char[] PropositionalLetter
        {
            get; private set;
        }

        /// <summary>
        /// Dictionary of the expected symbols, according to the language syntax.
        /// </summary>
        public Dictionary<Symbol, List<Symbol>> Expected
        {
            get; private set;
        }

        /// <summary>
        /// Valid initial symbols, according to the language syntax.
        /// </summary>
        public Symbol[] Initial
        {
            get; private set;
        }

        #endregion Atributos públicos

        #region Constructor
        // Constructor 
        private Language()
        {
            // Set of all valid propositional letters.
            List<char> extralogic = new List<char>();
            for (char letter = 'a'; letter <= 'z'; letter++)
                extralogic.Add(letter);
            PropositionalLetter = extralogic.ToArray();

            // Expected symbols definition - language syntax.
            Expected = new Dictionary<Symbol, List<Symbol>>()
            {
                { Symbol.ABERTURA,
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.FECHAMENTO, Symbol.PROP, Symbol.VAZIO, Symbol.NAO }
                },
                { Symbol.FECHAMENTO,
                  new List<Symbol>() { Symbol.FECHAMENTO, Symbol.VAZIO, Symbol.NAO, Symbol.E, Symbol.OU, Symbol.IMPLICA, Symbol.EQUIVALENTE }
                },
                { Symbol.PROP,
                  new List<Symbol>() { Symbol.FECHAMENTO, Symbol.VAZIO, Symbol.E, Symbol.OU, Symbol.IMPLICA, Symbol.EQUIVALENTE }
                },
                { Symbol.E,
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.PROP, Symbol.VAZIO, Symbol.NAO }
                },
                { Symbol.OU,
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.PROP, Symbol.VAZIO, Symbol.NAO }
                },
                { Symbol.IMPLICA,
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.PROP, Symbol.VAZIO, Symbol.NAO }
                },
                { Symbol.EQUIVALENTE,
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.PROP, Symbol.VAZIO, Symbol.NAO }
                },
                { Symbol.NAO,
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.PROP, Symbol.VAZIO, Symbol.NAO }
                },
                { Symbol.VAZIO,
                  new List<Symbol>() { Symbol.TODOS }
                },
            };

            // Valid initials.
            Initial = new Symbol[]
            {
                Symbol.ABERTURA, Symbol.NAO, Symbol.PROP, Symbol.VAZIO
            };
        } // constructor.
        #endregion Construtor

        /// <summary>
        /// Is the parameter a valid propositional letter?
        /// </summary>
        /// <param name="letter">letter to test</param>
        /// <returns>if the parameter is a valid propositional letter</returns>
        public bool IsValidLetter(char letter)
        {
            return PropositionalLetter.Contains(letter);
        }

        /// <summary>
        /// Is the parameter a valid initial? 
        /// </summary>
        /// <param name="simb">symbol  to test</param>
        /// <returns>if the parameter symbol is valid as the first in the expression.</returns>
        public bool IsValidInitial(char simb)
        {
            return Initial.Contains(SymbolOf(simb));
        }

        /// <summary>
        /// Can the first symbol follow the second one? 
        /// </summary>
        /// <param name="follower">the symbol that follows.</param>
        /// <param name="followed">the followed symbol.</param>
        /// <returns>if the follower can follow the followed</returns>
        public bool Follows(Symbol follower, Symbol followed)
        {
            bool result =
                Expected.Keys.Contains(followed)
                && (Expected[followed].Contains(follower)
                   || Expected[followed].Contains(Symbol.TODOS));
            return result;
        }

        /// <summary>
        /// Gives the symbol instance of the token.
        /// </summary>
        /// <param name="token">token as a char</param>
        /// <returns>the correspondent symbol instance</returns>
        public Symbol SymbolOf(char token)
        {
            switch (token)
            {
                case '(':
                    return Symbol.ABERTURA;
                case ')':
                    return Symbol.FECHAMENTO;
                case '^':
                case '&':
                case '.':
                    return Symbol.E;
                case '+':
                case '|':
                    return Symbol.OU;
                case '~':
                case '!':
                case '-':
                    return Symbol.NAO;
                case '>':
                    return Symbol.IMPLICA;
                case '=':
                    return Symbol.EQUIVALENTE;
                case ' ':
                    return Symbol.VAZIO;
                default:
                    return IsValidLetter(token) ? Symbol.PROP : Symbol.INVALIDO;
            }
        } // SymbolOf
    }
}
