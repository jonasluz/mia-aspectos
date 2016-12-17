using System.Collections.Generic;

namespace JALJ_MIA_ASLlib
{
    /// <summary>
    /// Conjunctive normal form (CNF) conversion.
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
            /// An enumerable sequence of the extracted formulas.
            /// </summary>
            public IEnumerable<AST> Formulas
            {
                get
                {
                    return m_formulas;
                }
            }

            AST m_formula = null;   // Formula to extract partial formulas from.
            List<AST> m_formulas;   // Extracted formulas.

            // Constructor
            public Extractor(AST formula)
            {
                m_formula = formula;
                Extract();
            }

            /// <summary>
            /// Formula extraction.
            /// </summary>
            /// <param name="branch">The current branch to extract from</param>
            private void Extract(AST branch = null)
            {
                if (m_formulas == null) m_formulas = new List<AST>();
                AST current = branch != null ? branch : m_formula;

                switch (current.GetType().Name)
                {
                    case "ASTProp":
                    case "ASTOpUnary":
                        m_formulas.Add(current);
                        break;
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
                                break;
                            default:                    // There should not be other symbols in an CNF formula.
                                break;
                        }
                        break;
                }
            }
        }  // Extractor class

        #endregion Inner classes

        #region Public functions

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
                    ASTOpBinary opBin = ast as ASTOpBinary;
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
                        case Language.Symbol.EQUIVALE: // Form (P<->Q). Equivalent to (P&Q)|(~P&~Q).
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
                    AST p = (ast as ASTOpUnary).ast;
                    switch (p.GetType().Name)
                    {
                        case "ASTProp":         // Form ~P ... return ~P
                            return ast;
                        case "ASTOpUnary":      // Form ~(~P) - double negation ... return Convert(P)
                            return Convert((p as ASTOpUnary).ast);
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

        /// <summary>
        /// Separates a formula in CNF in its OR components clauses.
        /// </summary>
        /// <param name="astInCnf">An AST in CNF form.</param>
        /// <returns>A enumerable of CnfOr clauses.</returns>
        public static IEnumerable<CnfOr> Separate(AST astInCnf, bool order = false)
        {
            if (astInCnf == null) return null;

            List<CnfOr> result = new List<CnfOr>(1);

            switch (astInCnf.GetType().Name)
            {
                case "ASTProp":
                case "ASTOpUnary":
                    result.Add(new CnfOr(astInCnf));
                    break;
                case "ASTOpBinary":
                    ASTOpBinary opBin = (ASTOpBinary)astInCnf;
                    switch (opBin.value)
                    {
                        case Language.Symbol.OU:        // Form (A|B).
                            result.Add(new CnfOr(astInCnf));
                            break;
                        case Language.Symbol.E:         // Form (A&B).
                            result.AddRange(Separate(opBin.left));
                            result.AddRange(Separate(opBin.right));
                            break;
                        case Language.Symbol.IMPLICA:   // Form (P->Q).
                        case Language.Symbol.EQUIVALE: // Form (P<->Q).
                            throw new System.Exception("AST in CNF separation failed. There can't be other binary operator beside & or | in a formula in CNF.");
                    }
                    break;
            }

            if (order)
                result.Sort();
            return result;
        }

        #endregion Public functions

        #region Private functions

        /// <summary>
        /// Distribute formulas from left over right ASTs.
        /// </summary>
        /// <param name="left">Left AST</param>
        /// <param name="right">Right AST</param>
        /// <returns>A new AST representing left OR right</returns>
        private static AST Distribute(AST left, AST right)
        {
            if (left == null) return right;
            if (right == null) return left;

            // left and right must be already in CNF.
            IEnumerable<AST> leftFormulas = new Extractor(left).Formulas;
            IEnumerable<AST> rightFormulas = new Extractor(right).Formulas;
            
            // Distribute the formulas, creating the disjunctions list.
            List<AST> disjunctions = new List<AST>();
            foreach (AST lf in leftFormulas)
                foreach (AST rf in rightFormulas)
                {
                    AST disjunction = 
                        lf.Equals(rf) ? lf
                        : new ASTOpBinary(lf, rf, Language.Symbol.OU);
                    disjunction = Simplify(disjunction);
                    if (disjunction != null) disjunctions.Add(disjunction);
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

        private static AST Simplify(AST disjunction)
        {
            CnfOr cnf = new CnfOr(disjunction);
            cnf.Simplify();
            return cnf.Restore();
        }

        #endregion Private functions
    }
}
