using System.Collections.Generic;

namespace JALJ_MIA_ASLlib
{
    /// <summary>
    /// Logic Syntatic Analyzer
    /// </summary>
    public class Analyzer
    {
        #region Public attributes

        /// <summary>
        /// Errors list.
        /// </summary>
        public List<string> Errors
        {
            get; private set;
        }

        /// <summary>
        /// Log records list.
        /// </summary>
        public List<string> Log
        {
            get; private set;
        }

        /// <summary>
        /// Identified tokens list.
        /// </summary>
        public List<Token> Tokens
        {
            get
            {
                return m_tokenizer.Tokens;
            }
        }

        #endregion Public attributes

        string m_expr;              // expression to analyze.
        Tokenizer m_tokenizer;
        Parser m_parser;

        // Constructor.
        public Analyzer(string expr)
        {
            m_expr = expr;
        }

        /// <summary>
        /// Tokenize the expression.
        /// </summary>
        /// <returns>If tokenization succedded.</returns>
        public bool Tokenize()
        {
            m_tokenizer = new Tokenizer();

            bool result = m_tokenizer.Tokenize(m_expr);
            if (!result) Errors = m_tokenizer.Error;

            return result;
        }

        /// <summary>
        /// Parse the expression.
        /// </summary>
        /// <returns>The AST resulted from the expression parsing.</returns>
        public AST Parse()
        {
            // Tokenizing phase. 
            if (m_tokenizer == null)
            {
                Log.Add("Tokenizing will be called automatically.");
                Tokenize();
            }
            List<Token> tokens = m_tokenizer.Tokens;

            // Parsing phase.
            m_parser = new Parser();
            return m_parser.Parse(tokens);
        }
    }
}
