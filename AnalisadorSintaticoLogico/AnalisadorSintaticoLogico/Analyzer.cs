using System;
using System.Collections.Generic;
using System.Linq;

namespace JALJ_MIA_Fundamentos
{
    class Analyzer
    {
        public string Error
        {
            get; private set;
        }

        string m_expr;
        Tokenizer m_tokenizer; 

        public Analyzer(string expr)
        {
            m_expr = expr;
        }

        public bool Tokenize()
        {
            m_tokenizer = new Tokenizer();

            bool result = m_tokenizer.Tokenize(m_expr);
            if (!result) Error = m_tokenizer.Error;

            return result;
        }

        public bool Parse()
        {
            return true;
        }
    }
}
