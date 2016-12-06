using System.Collections.Generic;

namespace JALJ_MIA_ASLlib
{
    /// <summary>
    /// Logic Parser.
    /// </summary>
    public class Parser
    {
        #region Public attributes.

        /// <summary>
        /// Extracted tokens.
        /// </summary>
        public List<Token> Tokens
        {
            get; set;
        }

        /// <summary>
        /// AST node current instance.
        /// </summary>
        public AST Ast
        {
            get; private set;
        }

        #endregion Public attributes.

        int m_idx;              // current index.
        AST m_current;          // current AST node.
        int m_implFlag;         // implication flag, to control implications precedence.

        // Constructor.
        public AST Parse(List<Token> tokens = null)
        {
            if (tokens != null) Tokens = tokens;

            m_idx = -1;

            Ast = Walk();

            return Ast;
        }

        /// <summary>
        /// Parsing recursive implementation.
        /// </summary>
        /// <param name="precede">does precedence must be considered in this recursive call?</param>
        /// <returns>the resulting AST node.</returns>
        AST Walk(bool precede = false)
        {
            // Increment the global index.
            m_idx++;
            if (m_idx >= Tokens.Count) return null;

            // Read the current index's token value.
            Token token = Tokens[m_idx];

            AST ast = null;

            switch (token.type)
            {
                case Language.Symbol.PROP:          // a propositional letter.
                    ast = new ASTProp(token.value);
                    break;
                case Language.Symbol.NAO:           // negation operation.
                    ast = new ASTOpUnary(Walk(true), token.type);
                    break;
                case Language.Symbol.E:             // conjunction operation. 
                case Language.Symbol.OU:            // disjunction operation.
                    ast = new ASTOpBinary(m_current, Walk(true), token.type);
                    break;
                case Language.Symbol.IMPLICA:       // implication operation.
                case Language.Symbol.EQUIVALE: // double implication operation.
                    // double implication has lesser precedence over single implication. 
                    bool bi = token.type == Language.Symbol.EQUIVALE;
                    // must continue to parse?
                    bool forward =                  // we continue parsing if...
                        m_implFlag == 0 ||          // ... there is no implications awaiting or ...
                        (m_implFlag == 2 && !bi);   // ... a double implication awaits and the current is a single implication.
                    if (forward)
                    {   // must continue the parsing.
                        // save current implication flag value...
                        int implications = m_implFlag;
                        // and update the global value.
                        m_implFlag = bi ? 2 : 1;
                        // enter another recursion.
                        ast = new ASTOpBinary(m_current, Walk(false), token.type);
                        // did the last recursive call finished precedence analysis? 
                        if (m_implFlag == 0) precede = false;
                        // restore previous (saved) implication flag value.
                        m_implFlag = implications;
                    } else 
                    {   // must not continue and must return to the last call.
                        m_idx--;
                        ast = m_current;
                        precede = true;
                        m_implFlag = 0;
                        break;
                    }
                    break;
                case Language.Symbol.ABERTURA:      // opening expression symbol.
                    // enter a new recursive call, as an AST node must come from the parenthesis' content analysis.
                    while (Walk(precede) != null)
                        ast = m_current;
                    break;
                case Language.Symbol.FECHAMENTO:    // closing expression symbol.
                    return null;
            }

            // update current AST node.
            m_current = ast;

            // continue the processing as long as there are tokens and no precedence.
            if (!precede && m_idx < Tokens.Count) Walk();

            return m_current;
        }
    }
}
