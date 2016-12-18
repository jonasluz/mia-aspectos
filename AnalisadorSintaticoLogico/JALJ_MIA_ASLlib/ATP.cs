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
        private struct TestedPair
        {
            int first, second;

            public TestedPair(int first, int second)
            {
                this.first = first; this.second = second;
            }
        }

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
            clauses.AddRange(m_theoremNegation.Props);
            clauses.Sort();
            string premissesStr = "Cláusulas (premissas + negação do teorema):";
            int premisseCount = 0;
            foreach (MultipleDisjunction premisse in clauses)
                premissesStr += string.Format("\n({0}) {1}", ++premisseCount, premisse);
            report(premissesStr + "\n");

            // Evaluate Resolutions.
            report("\n=====================\nTentando provar...\n------------------\n\n");
            List<TestedPair> tested = new List<TestedPair>();
            bool solved = false;
            for (int i = 0; i < clauses.Count; i++)
            {
                for (int j = 0; j < clauses.Count; j++)
                {
                    if (i == j) continue;

                    TestedPair pair = new TestedPair(i, j);
                    if (tested.Contains(pair)) continue;
                    else tested.Add(pair);

                    MultipleDisjunction resolvent = clauses[i].ApplyResolution(clauses[j]);
                    if (resolvent == null) continue; // complementaries not found.
                    solved = resolvent.ISNullClause;
                    if (solved)
                    {
                        report(string.Format(
                            "Cláusula nula encontrada da aplicação de {0} em {1}.\n",
                            j + 1, i + 1
                          ));
                        break;
                    }
                    if (clauses.Contains(resolvent)) continue;
                    clauses.Add(resolvent);
                    report(string.Format(
                        "({0}) {1} :: De {2} em {3}.\n",
                        clauses.Count, 
                        resolvent.ToString(),
                        j + 1, i + 1
                      ));
                    i = j = 0;
                }
                if (solved) break;
            }

            report("\n\n==================\n");
            report(solved ? "TEOREMA PROVADO!" : "NÃO FOI POSSÍVEL PROVAR A TEORIA!");
            report("\n==================\n\n");
        }
    } // ATP

}
