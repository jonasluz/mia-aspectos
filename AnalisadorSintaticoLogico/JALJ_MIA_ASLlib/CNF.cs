using System.Collections.Generic;

namespace JALJ_MIA_ASLlib
{
    /// <summary>
    /// Conjuntive normal form (CNF) conversion.
    /// </summary>
    /// <see cref="http://cs.jhu.edu/~jason/tutorials/convert-to-CNF"/>
    public abstract class CNF
    {
        #region Inner classes

        /// <summary>
        /// Formula extractor.
        /// Extracts formulas from a formula already in CNF.
        /// </summary>
        private class Extractor
        {
            /// <summary>
            /// An enumerable sequence o the extracted formulas.
            /// </summary>
            public IEnumerable<AST> Formulas
            {
                get
                {
                    if (m_formulas == null)
                    {
                        m_formulas = new List<AST>(1);
                        Extract();
                    }
                    return m_formulas;
                }
            }
            AST m_formula = null;   // Formula to extract partial formulas from.
            List<AST> m_formulas;   // Extracted formulas.

            // Constructor
            public Extractor(AST formula)
            {
                m_formula = formula;
            }

            /// <summary>
            /// Formula extraction.
            /// </summary>
            /// <param name="branch">The current branch to extract from</param>
            private void Extract(AST branch = null)
            {
                AST current = branch != null ? branch : m_formula;

                switch (current.GetType().Name)
                {
                    case "ASTProp":
                    case "ASTOpUnary":
                        m_formulas.Add(current);
                        return;
                    case "ASTOpBinary":
                        ASTOpBinary binOp = (ASTOpBinary)current;
                        switch (binOp.value)
                        {
                            case Language.Symbol.E:     // Extraction must continue.
                                Extract(binOp.left);
                                Extract(binOp.right);
                                break;
                            case Language.Symbol.OU:    // Already a disjuction. Extraction must return.
                                m_formulas.Add(current);
                                return;
                            default:                    // There should not be other symbols in an CNF formula.
                                // TODO: throw some error here.
                                break;
                        }
                        break;
                }
            }
        }  // Extractor class

        #endregion Inner classes

        /// <summary>
        /// Convert the formula to conjuntive normal form.
        /// </summary>
        /// <param name="ast">original abstract syntatic tree representinf the formula.</param>
        /// <returns>formula in CNF.</returns>
        public static AST Convert(AST ast)
        {
            switch (ast.GetType().Name)
            {
                case "ASTProp":
                    return ast;
                case "ASTOpBinary":
                    ASTOpBinary opBin = (ASTOpBinary)ast;
                    switch (opBin.value)
                    {
                        case Language.Symbol.E:         // Form (P&Q).
                            AST left = Convert(opBin.left);
                            AST right = Convert(opBin.right);
                            return new ASTOpBinary(left, right, Language.Symbol.E);
                        case Language.Symbol.OU:        // Form (P|Q).
                            left = Convert(opBin.left);
                            right = Convert(opBin.right);
                            return Distribute(left, right);
                        case Language.Symbol.IMPLICA:   // Form (P->Q). Equivalent to (~P|Q)
                            return Convert(
                                new ASTOpBinary(
                                    new ASTOpUnary(opBin.left, Language.Symbol.NAO),
                                    opBin.right, Language.Symbol.OU)
                                );
                        case Language.Symbol.EQUIVALENTE: // Form (P<->Q). Equivalent to (P&Q)|(~P&~Q).
                            left = new ASTOpBinary(opBin.left, opBin.right, Language.Symbol.E);
                            right = new ASTOpBinary(
                                new ASTOpUnary(opBin.left, Language.Symbol.NAO),
                                new ASTOpUnary(opBin.right, Language.Symbol.NAO),
                                Language.Symbol.E
                                );
                            return Convert(new ASTOpBinary(left, right, Language.Symbol.OU));
                    }
                    break;
                case "ASTOpUnary":
                    AST p = ((ASTOpUnary)ast).ast;
                    switch (p.GetType().Name)
                    {
                        case "ASTProp":         // Form ~P ... return ~P
                            return ast;
                        case "ASTOpUnary":      // Form ~(~P) - double negation ... return Convert(P)
                            return Convert(p);
                        case "ASTOpBinary":
                            opBin = (ASTOpBinary)p;
                            Language.Symbol op = opBin.value;
                            if (op != Language.Symbol.E && op != Language.Symbol.OU)
                            { // Not yet in CNF. 
                                AST pInNcf = Convert(p);
                                return Convert(new ASTOpUnary(pInNcf, Language.Symbol.NAO));
                            }
                            AST left = new ASTOpUnary(opBin.left, Language.Symbol.NAO);
                            AST right = new ASTOpUnary(opBin.right, Language.Symbol.NAO);
                            Language.Symbol deMorganOp = Language.Symbol.INVALIDO;
                            if (opBin.value == Language.Symbol.E)
                                // Form ~(P&Q): from DeMorgan's Law, return Convert(~P|~Q)
                                deMorganOp = Language.Symbol.OU;
                            else if (opBin.value == Language.Symbol.OU)
                                // Form ~(P|Q): from DeMorgan's Law, return Convert(~P&~Q)
                                deMorganOp = Language.Symbol.E;
                            return Convert(new ASTOpBinary(left, right, deMorganOp));
                    }
                    break;
            }

            return null;
        }

        #region Private functions.

        /// <summary>
        /// Distribute formulas from left over right ASTs.
        /// </summary>
        /// <param name="left">Left AST</param>
        /// <param name="right">Right AST</param>
        /// <returns>A new AST representing left OR right</returns>
        private static AST Distribute(AST left, AST right)
        {
            // left and right must be already in CNF.
            IEnumerable<AST> leftFormulas = new Extractor(left).Formulas;
            IEnumerable<AST> rightFormulas = new Extractor(right).Formulas;

            // Distribute the formulas, creating the disjunctions list.
            List<AST> disjunctions = new List<AST>(1);
            foreach (AST lf in leftFormulas)
                foreach (AST rf in rightFormulas)
                {
                    AST disjunction = new ASTOpBinary(lf, rf, Language.Symbol.OU);
                    disjunctions.Add(disjunction);
                }

            // Joins the disjuction list, creating the general conjunction.
            AST conjunction = null;
            foreach (AST disjunction in disjunctions)
            {
                conjunction = 
                    conjunction == null ? disjunction 
                    : new ASTOpBinary(conjunction, disjunction, Language.Symbol.E);
            }

            return conjunction;
        } // Distribute.

        #endregion Private functions.
    }
}
