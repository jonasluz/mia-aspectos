using System;
using System.Collections.Generic;

namespace JALJ_MIA_ASLlib
{
    public class CnfOr
    {
        #region Inner structure

        public struct Component
        {
            bool negates;
            char letter;

            public Component(char letter, bool negates = false)
            {
                this.negates = negates;
                this.letter = letter;
            }

            public bool opposite(Component other)
            {
                return (other.letter == this.letter && other.negates != this.negates);
            }
        }

        #endregion Inner structure

        /// <summary>
        /// Components counting.
        /// </summary>
        public int Count
        {
            get
            {
                return content.Count;
            }
        }

        /// <summary>
        /// Is this CnfOr a null clause?
        /// </summary>
        public bool NullClause
        {
            get
            {
                return Count == 0;
            }
        }

        List<Component> content = new List<Component>(1);

        // Constructor.
        public CnfOr(AST astInCNF)
        {
            Extract(astInCNF);
        }

        /// <summary>
        /// Applies Resolution method from a CnfOr over this one.
        /// </summary>
        /// <param name="other">The other CnfOr to be applied over this one.</param>
        /// <returns>A simplified CnfOr or a null clause</returns>
        public CnfOr appliesResolution(CnfOr other)
        {
            // TODO: Implement.
            return this;
        }

        #region Private functions

        private void Extract(AST astInCNF)
        {
            switch (astInCNF.GetType().Name)
            {
                case "ASTProp":
                    char letter = (astInCNF as ASTProp).value;
                    content.Add(new Component(letter));
                    break;
                case "ASTOpUnary":
                    ASTOpUnary astNeg = astInCNF as ASTOpUnary;
                    if (astNeg.ast.GetType().Name != "ASTProp")
                    {   // In CNF form, the negation can only refers to a simple proposition.
                        throw new Exception("Error creating a CnfOr : In CNF form, the negation can only refers to a simple proposition.");
                    }
                    letter = (astNeg.ast as ASTProp).value;
                    content.Add(new Component(letter, true));
                    break;
                case "ASTOpBinary":
                    ASTOpBinary opBin = astInCNF as ASTOpBinary;
                    switch (opBin.value)
                    {
                        case Language.Symbol.OU:        // Form (A|B).
                            Extract(opBin.left);
                            Extract(opBin.right);
                            break;
                        case Language.Symbol.E:         // Form (A&B).
                        case Language.Symbol.IMPLICA:   // Form (P->Q).
                        case Language.Symbol.EQUIVALE: // Form (P<->Q).
                            throw new Exception("Error creating a CnfOr : In CNF form, OR formulas can't contain other operators than OR.");
                    }
                    break;
            }
        }

        #endregion Private functions
    }
}
