using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorSintaticoLogico
{
    public enum Operador
    {
        NULO,
        E, OU, NAO, IMPLICA
    }

    class Alfabeto
    {
        public static readonly char TOKEN_DELIM_ESQ = '(';
        public static readonly char TOKEN_DELIM_DIR = ')';

        public static char[] ExtraLogicos
        {
            get
            {
                if (s_ExtraLogicos.Count == 0)
                    for (char c = 'a'; c <= 'z'; c++)
                        s_ExtraLogicos.Add(c);
                return s_ExtraLogicos.ToArray();
            }
        }

        private static List<char> s_ExtraLogicos =
            new List<char>();

        private static Dictionary<Operador, char> s_OperadorToken =
            new Dictionary<Operador, char>()
            {
                { Operador.E, '&' },
                { Operador.OU, '|' },
                { Operador.NAO, '~' },
                { Operador.IMPLICA, '>' },
                { Operador.NULO, ' ' }
            };
        private static Dictionary<char, Operador> s_TokenOperador =
            new Dictionary<char, Operador>()
            {
                { '&', Operador.E },
                { '|', Operador.OU },
                { '~', Operador.NAO },
                { '>', Operador.IMPLICA }
            };

        public static bool EhLetraProposicionalValida(char extralogico)
        {
            return ExtraLogicos.Contains(extralogico);
        }

        public static char TokenOfOperador(Operador operador)
        {
            return s_OperadorToken[operador];
        }

        public static Operador OperadorWithToken(char token)
        {
            return ExtraLogicos.Contains(token) ? s_TokenOperador[token] : Operador.NULO;
        }

    }
}
