using System.Collections.Generic;
using System.Linq;

namespace JALJ_MIA_Fundamentos
{
    class Language
    {
        public enum Symbol
        {
            VAZIO, ABERTURA, FECHAMENTO, PROP,
            E, OU, NAO, IMPLICA,
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

        public char[] PropositionalLetter
        {
            get; private set;
        }

        public Dictionary<Symbol, List<Symbol>> Expected
        {
            get; private set;
        }

        public Symbol[] Initial
        {
            get; private set;
        }

        #region Construtor
        /* Construtor */
        private Language()
        {
            // Conjunto das letras proposicionais válidas.
            List<char> extralogic = new List<char>();
            for (char letter = 'a'; letter <= 'z'; letter++)
                extralogic.Add(letter);
            PropositionalLetter = extralogic.ToArray();

            // Gramática (tipos esperados) para análise sintática.
            Expected = new Dictionary<Symbol, List<Symbol>>()
            {
                { Symbol.ABERTURA,
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.FECHAMENTO, Symbol.PROP, Symbol.VAZIO, Symbol.NAO }
                },
                { Symbol.FECHAMENTO,
                  new List<Symbol>() { Symbol.FECHAMENTO, Symbol.VAZIO, Symbol.NAO, Symbol.E, Symbol.OU, Symbol.IMPLICA }
                },
                { Symbol.PROP,
                  new List<Symbol>() { Symbol.FECHAMENTO, Symbol.VAZIO, Symbol.E, Symbol.OU, Symbol.IMPLICA }
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
                { Symbol.NAO,
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.PROP, Symbol.VAZIO, Symbol.NAO }
                },
                { Symbol.VAZIO,
                  new List<Symbol>() { Symbol.TODOS }
                },
            };

            // Iniciais válidas.
            Initial = new Symbol[]
            {
                Symbol.ABERTURA, Symbol.NAO, Symbol.PROP, Symbol.VAZIO
            };
        }
        #endregion Construtor

        public bool IsValidLetter(char letter)
        {
            return PropositionalLetter.Contains(letter);
        }

        public bool IsValidInitial(char simb)
        {
            return Initial.Contains(SymbolOf(simb));
        }

        public bool Follows(Symbol follower, Symbol followed)
        {
            bool result =
                Expected.Keys.Contains(followed)
                && (Expected[followed].Contains(follower)
                   || Expected[followed].Contains(Symbol.TODOS));
            return result;
        }

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
                case ' ':
                    return Symbol.VAZIO;
                default:
                    return IsValidLetter(token) ? Symbol.PROP : Symbol.INVALIDO;
            }
        }
    }
}
