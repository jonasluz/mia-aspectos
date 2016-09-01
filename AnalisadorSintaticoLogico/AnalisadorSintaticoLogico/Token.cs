using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorSintaticoLogico
{
    struct Token
    {
        public Linguagem.Simbolo type;
        public char value;

        public Token(Linguagem.Simbolo simbolo, char value)
        {
            this.type = simbolo;
            this.value = value;
        }
    }
}
