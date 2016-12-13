using System;
using System.Collections.Generic;

namespace JALJ_MIA_ASLlib
{
    public class CnfOr: IComparable
    {
        #region Inner class Component

        /// <summary>
        /// Component of a CNFOr formula.
        /// </summary>
        public class Component: IComparable
        {
            bool m_negates;
            char m_letter;

            public Component(char letter, bool negates = false)
            {
                this.m_negates = negates;
                this.m_letter = letter;
            }

            public AST ToAst()
            {
                ASTProp result = new ASTProp(m_letter);

                return (m_negates ? new ASTOpUnary(result, Language.Symbol.NAO) : result as AST);
            }

            public bool Opposite(Component other)
            {
                return (other.m_letter == this.m_letter && other.m_negates != this.m_negates);
            }

            public override string ToString()
            {
                string neg = m_negates ? "~" : " ";
                return neg + this.m_letter;
            }

            public int CompareTo(object other)
            {
                Component o = other as Component;
                int diff = m_letter - o.m_letter;
                if (diff == 0)
                    diff = m_negates == o.m_negates ? 0
                        : m_negates ? -1 : 1;
                return diff;
            }

            // override object.Equals
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                Component other = obj as Component;
                return (this.m_letter == other.m_letter && this.m_negates == other.m_negates);
            }
            // override object.GetHashCode
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        #endregion Inner structure

        #region Public attributes

        /// <summary>
        /// Components counting.
        /// </summary>
        public int Count
        {
            get
            {
                return m_content.Count;
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

        #endregion Public attributes

        List<Component> m_content = new List<Component>(1);

        // Constructor.
        public CnfOr(AST astInCNF)
        {
            Extract(astInCNF);
            m_content.Sort();
        }

        /// <summary>
        /// Restore an AST from the CnfOr.
        /// </summary>
        /// <returns>The restores AST.</returns>
        public AST Restore()
        {
            if (m_content.Count == 0) return null;

            AST result = null;
            foreach (Component component in m_content)
            {
                result = (
                    result == null ? component.ToAst()
                    : new ASTOpBinary(result, component.ToAst(), Language.Symbol.OU)
                    );
            }

            return result;
        }

        /// <summary>
        /// Simplify this disjunction.
        /// </summary>
        public void Simplify()
        {
            for (int i = 0; i < m_content.Count; i++)
                for (int j = i + 1; j < m_content.Count; j++)
                    if (m_content[i].Equals(m_content[j])) m_content.RemoveAt(j);
                    else if (m_content[i].Opposite(m_content[j]))
                    {
                        m_content.Clear();
                        return;
                    }
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

        #region Overriding and interface implementation

        public override string ToString()
        {
            return string.Join(" | ", m_content);
        }

        public int CompareTo(object obj)
        {
            CnfOr o = obj as CnfOr;
            return
                Count < o.Count ? -1
                : Count == o.Count ? 0
                : 1;
        }

        #endregion Overriding and interface implementation

        #region Private functions

        private void Extract(AST astInCNF)
        {
            switch (astInCNF.GetType().Name)
            {
                case "ASTProp":
                    char letter = (astInCNF as ASTProp).value;
                    m_content.Add(new Component(letter));
                    break;
                case "ASTOpUnary":
                    ASTOpUnary astNeg = astInCNF as ASTOpUnary;
                    if (astNeg.ast.GetType().Name != "ASTProp")
                    {   // In CNF form, the negation can only refers to a simple proposition.
                        throw new Exception("Error creating a CnfOr : In CNF form, the negation can only refers to a simple proposition.");
                    }
                    letter = (astNeg.ast as ASTProp).value;
                    m_content.Add(new Component(letter, true));
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
