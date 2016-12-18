using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JALJ_MIA_ASLlib
{
    /// <summary>
    /// Automatic Theorem Proving
    /// </summary>
    public class ATP
    {
        public delegate void ReportDelegate(string message);

        public IDictionary<string, CNFProposition> Premisses
        {
            get; private set;
        }
        public CNFProposition Theorem
        {
            get; set;
        }
        public List<MultipleDisjunction> Deductions
        {
            get; private set;
        }

        private CNFProposition m_theoremNegation;
        private List<MultipleDisjunction> m_premisses = new List<MultipleDisjunction>();

        #region constructors

        public ATP(IEnumerable<CNFProposition> premisses, CNFProposition theorem = null)
        {
            this.Premisses = new Dictionary<string, CNFProposition>();
            foreach (CNFProposition premisse in premisses)
                AddPremisse(premisse);

            if (theorem != null) this.Theorem = theorem;
        }
        public ATP()
        {
            this.Premisses = new Dictionary<string, CNFProposition>();
        }

        #endregion constructors

        public void AddPremisse(CNFProposition premisse)
        {
            this.Premisses.Add(premisse.Ast.ToString(), premisse);
            m_premisses.AddRange(premisse.Props);
        }

        public void ProveIt(ReportDelegate report)
        {
            // Negates the theorem.
            AST negated = CNF.Convert(Theorem.Ast.Negation());
            m_theoremNegation = new CNFProposition(negated);
            report(string.Format(
                "Teorema: {0}\nTeorema negado: {1}\nTeorema negado em FNC: {2}\n",
                CNF.Convert(Theorem.Ast).ToString(),
                negated.ToString(),
                m_theoremNegation.ToString()
              ));

            // Join all premisses and sort them.
            List<MultipleDisjunction> clauses = new List<MultipleDisjunction>();
            foreach (CNFProposition premisse in Premisses.Values)
                clauses.AddRange(premisse.Props);
            clauses.Sort();
            string premissesStr = "Premissas em FNC:";
            int premisseCount = 0;
            foreach (MultipleDisjunction premisse in clauses)
                premissesStr += string.Format("\n({0}) {1}", ++premisseCount, premisse);
            report(premissesStr + "\n");

            //Procura...
        }
    } // ATP

}
