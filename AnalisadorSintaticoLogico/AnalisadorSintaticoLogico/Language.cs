using System.Collections.Generic;
using System.Linq;

namespace JALJ_MIA_Fundamentos
{
    class Language
    {
        public enum Symbol
        {
            VAZIO, ABERTURA, FECHAMENTO, PROP,
            OPER_E, OPER_OU, OPER_NAO, OPER_IMPLICA,
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
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.FECHAMENTO, Symbol.PROP, Symbol.VAZIO, Symbol.OPER_NAO }
                },
                { Symbol.FECHAMENTO,
                  new List<Symbol>() { Symbol.FECHAMENTO, Symbol.VAZIO, Symbol.OPER_NAO, Symbol.OPER_E, Symbol.OPER_OU, Symbol.OPER_IMPLICA }
                },
                { Symbol.PROP,
                  new List<Symbol>() { Symbol.FECHAMENTO, Symbol.VAZIO, Symbol.OPER_E, Symbol.OPER_OU, Symbol.OPER_IMPLICA }
                },
                { Symbol.OPER_E,
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.PROP, Symbol.VAZIO, Symbol.OPER_NAO }
                },
                { Symbol.OPER_OU,
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.PROP, Symbol.VAZIO, Symbol.OPER_NAO }
                },
                { Symbol.OPER_IMPLICA,
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.PROP, Symbol.VAZIO, Symbol.OPER_NAO }
                },
                { Symbol.OPER_NAO,
                  new List<Symbol>() { Symbol.ABERTURA, Symbol.PROP, Symbol.VAZIO, Symbol.OPER_NAO }
                },
                { Symbol.VAZIO,
                  new List<Symbol>() { Symbol.TODOS }
                },
            };

            // Iniciais válidas.
            Initial = new Symbol[]
            {
                Symbol.ABERTURA, Symbol.OPER_NAO, Symbol.PROP, Symbol.VAZIO
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
                case '&':
                    return Symbol.OPER_E;
                case '|':
                    return Symbol.OPER_OU;
                case '~':
                    return Symbol.OPER_NAO;
                case '>':
                    return Symbol.OPER_IMPLICA;
                case ' ':
                case '-':
                    return Symbol.VAZIO;
                default:
                    return IsValidLetter(token) ? Symbol.PROP : Symbol.INVALIDO;
            }
        }
    }
}
