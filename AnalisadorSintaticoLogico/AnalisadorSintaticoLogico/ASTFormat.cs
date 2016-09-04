using System.Collections.Generic;
using System.Linq;

namespace JALJ_MIA_Fundamentos
{
    class ASTFormat
    {
        public enum FormatType
        {
            TREE, JSON
        }

        public static string Format(AST ast, FormatType type = FormatType.TREE)
        {
            string result = "";

            switch (type)
            {
                case FormatType.TREE:
                    int len;
                    IEnumerable<string> padded = PadTree(StrTree(ast), out len);
                    foreach (string line in padded)
                        result += line + "\n";
                    break;
            }

            return result;
        }

        #region Métodos privados 

        private static IEnumerable<string> StrTree(AST ast)
        {
            IEnumerable<string> result = null; 

            switch (ast.GetType().Name)
            {
                case "ASTProp":
                    return new string[] { ((ASTProp)ast).value.ToString() };

                case "ASTOpUnary":
                    result = new string[] { ((ASTOpUnary)ast).value.ToString(), "|" };
                    return result.Concat(StrTree(((ASTOpUnary)ast).ast));

                case "ASTOpBinary":
                    result = new List<string>() { ((ASTOpBinary)ast).value.ToString() };
                    int lenL, lenR;
                    string[] strL = PadTree(new string[] { "/" }.Concat(StrTree(((ASTOpBinary)ast).left)), out lenL).ToArray();
                    string[] strR = PadTree(StrTree(((ASTOpBinary)ast).right), out lenR).ToArray();
                    strR = new string[] { "\\".PadRight(lenR) }.Concat(strR).ToArray();
                    string lineL = new string(' ', lenL);
                    string lineR = new string(' ', lenR);
                    List<string> joined = new List<string>();
                    for (
                        int i = 0, maxL = strL.Count(), maxR = strR.Count();
                        i < maxL || i < maxR;
                        i++
                    )
                    { // união
                        string line =
                            i < maxL ?
                                i < maxR ? strL[i] + " " + strR[i]
                                    : strL[i] + lineR
                                : lineL + strR[i];
                        joined.Add(line);
                    }
                    return result.Concat(joined);
            } // switch

            return result;
        }

        private static IEnumerable<string> PadTree(IEnumerable<string> tree, out int len)
        {
            // Calcula o comprimento máximo de uma linha.
            int max = 0;
            foreach (string line in tree)
                if (line.Length > max) max = line.Length;

            // Ajusta as linhas ao comprimento máximo
            tree = tree.Select(s =>
            {
                int pad = (max - s.Length);
                return s.PadLeft(pad);
            });

            len = max;
            return tree;
        }

        #endregion Métodos privados 
    }
}
