using System.Collections.Generic;
using System.Linq;

namespace JALJ_MIA_ASLlib
{
    public class ASTFormat
    {
        /// <summary>
        /// Type of the format.
        /// </summary>
        public enum FormatType
        {
            TREE, JSON
        }

        /// <summary>
        /// Format the abstract syntax tree.
        /// </summary>
        /// <param name="ast">abstract syntax tree node</param>
        /// <param name="type">type to format to</param>
        /// <returns></returns>
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
                case FormatType.JSON:
                    result = StrJson(ast);
                    break;
            }

            return result;
        }

        #region Private functions 

        /// <summary>
        /// Generate the formatted ast node.
        /// </summary>
        /// <param name="ast">abstract syntax tree node</param>
        /// <returns>an enumerable sequence of nodes as strings</returns>
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

        /// <summary>
        /// Add a padding to the ast string representation, depending on its position.
        /// </summary>
        /// <param name="tree">the tree</param>
        /// <param name="len">length</param>
        /// <returns>padded tree string representation</returns>
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

        /// <summary>
        /// Creates a JSON representation of the ast node.
        /// </summary>
        /// <param name="ast">AST node</param>
        /// <param name="nesting">nesting level for identation</param>
        /// <returns></returns>
        private static string StrJson(AST ast, int nesting = 0)
        {
            string pad = new string('\t', nesting);
            string result = pad;

            switch (ast.GetType().Name)
            {

                case "ASTProp":
                    return "\"" + ((ASTProp)ast).value.ToString() + "\"";

                case "ASTOpUnary":
                    result = "\n" + pad + "{ \"operador\"\t: \"" + ((ASTOpUnary)ast).value.ToString().ToLower() + "\" \n";
                    result += pad + "  \"proposicao\"\t: " + StrJson(((ASTOpUnary)ast).ast, nesting + 1) + "\n";
                    break;

                case "ASTOpBinary":
                    result = "\n" + pad + "{ \"operador\" :\t\"" + ((ASTOpBinary)ast).value.ToString().ToLower() + "\" \n";
                    result += pad + "  \"proposicoes\"\t: [ " + StrJson(((ASTOpBinary)ast).left, nesting + 1) + " , ";
                    result += StrJson(((ASTOpBinary)ast).right, nesting + 1) + " ]\n";
                    break;
            } // switch

            return result + pad + "}";

        }

        #endregion Private functions.
    }
}
