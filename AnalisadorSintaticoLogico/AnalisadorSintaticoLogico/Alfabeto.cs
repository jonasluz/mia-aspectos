using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorSintaticoLogico
{
    class Linguagem
    {
        public enum Simbolo
        {
            VAZIO, ABERTURA, FECHAMENTO, PROP,
            OPER_E, OPER_OU, OPER_NAO, OPER_IMPLICA,
            INVALIDO, TODOS
        }

        #region Singleton
        /// <summary>
        /// Singleton Instance.
        /// </summary>
        public static Linguagem Ling
        {
            get
            {
                if (s_instance == null) s_instance = new Linguagem();
                return s_instance;
            }
        }
        private static Linguagem s_instance;
        #endregion Singleton

        public char[] LetrasProposicionais
        {
            get; private set;
        }

        public Dictionary<Simbolo, List<Simbolo>> TiposEsperados
        {
            get; private set;
        }

        public Simbolo[] IniciaisValidas
        {
            get; private set;
        }

        #region Construtor
        /* Construtor */
        private Linguagem()
        {
            // Conjunto das letras proposicionais válidas.
            List<char> extralogicos = new List<char>();
            for (char letra = 'a'; letra <= 'z'; letra++)
                extralogicos.Add(letra);
            LetrasProposicionais = extralogicos.ToArray();

            // Gramática (tipos esperados) para análise sintática.
            TiposEsperados = new Dictionary<Simbolo, List<Simbolo>>()
            {
                { Simbolo.ABERTURA,
                  new List<Simbolo>() { Simbolo.ABERTURA, Simbolo.FECHAMENTO, Simbolo.PROP, Simbolo.VAZIO, Simbolo.OPER_NAO }
                },
                { Simbolo.FECHAMENTO,
                  new List<Simbolo>() { Simbolo.FECHAMENTO, Simbolo.VAZIO, Simbolo.OPER_NAO, Simbolo.OPER_E, Simbolo.OPER_OU, Simbolo.OPER_IMPLICA }
                },
                { Simbolo.PROP,
                  new List<Simbolo>() { Simbolo.FECHAMENTO, Simbolo.VAZIO, Simbolo.OPER_E, Simbolo.OPER_OU, Simbolo.OPER_IMPLICA }
                },
                { Simbolo.OPER_E,
                  new List<Simbolo>() { Simbolo.ABERTURA, Simbolo.PROP, Simbolo.VAZIO, Simbolo.OPER_NAO }
                },
                { Simbolo.OPER_OU,
                  new List<Simbolo>() { Simbolo.ABERTURA, Simbolo.PROP, Simbolo.VAZIO, Simbolo.OPER_NAO }
                },
                { Simbolo.OPER_IMPLICA,
                  new List<Simbolo>() { Simbolo.ABERTURA, Simbolo.PROP, Simbolo.VAZIO, Simbolo.OPER_NAO }
                },
                { Simbolo.OPER_NAO,
                  new List<Simbolo>() { Simbolo.ABERTURA, Simbolo.PROP, Simbolo.VAZIO, Simbolo.OPER_NAO }
                },
                { Simbolo.VAZIO,
                  new List<Simbolo>() { Simbolo.TODOS }
                },
            };

            // Iniciais válidas.
            IniciaisValidas = new Simbolo[]
            {
                Simbolo.ABERTURA, Simbolo.OPER_NAO, Simbolo.PROP, Simbolo.VAZIO
            };
        }
        #endregion Construtor

        public bool EhLetraValida(char letra)
        {
            return LetrasProposicionais.Contains(letra);
        }

        public bool EhInicialValida(char simb)
        {
            return IniciaisValidas.Contains(TokenOf(simb));
        }

        public bool Follows(Simbolo follower, Simbolo followed)
        {
            bool result =
                TiposEsperados.Keys.Contains(followed)
                && (TiposEsperados[followed].Contains(follower)
                   || TiposEsperados[followed].Contains(Simbolo.TODOS));
            return result;
        }

        public Simbolo TokenOf(char simb)
        {
            switch (simb)
            {
                case '(':
                    return Simbolo.ABERTURA;
                case ')':
                    return Simbolo.FECHAMENTO;
                case '&':
                    return Simbolo.OPER_E;
                case '|':
                    return Simbolo.OPER_OU;
                case '~':
                    return Simbolo.OPER_NAO;
                case '>':
                    return Simbolo.OPER_IMPLICA;
                case ' ':
                    return Simbolo.VAZIO;
                default:
                    return EhLetraValida(simb) ? Simbolo.PROP : Simbolo.INVALIDO;
            }
        }
    }
}
