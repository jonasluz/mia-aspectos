using System;
using System.Collections.Generic;
using System.Linq;

namespace JALJ_MIA_Fundamentos
{
    class Parser
    {
        public string Error
        {
            get
            {
                return m_tokenizer.Error;
            }
        }

        private Tokenizer m_tokenizer; 

        public bool Tokenize(string expr)
        {
            m_tokenizer = new Tokenizer();
            return m_tokenizer.Tokenize(expr);
        }
    }
}
