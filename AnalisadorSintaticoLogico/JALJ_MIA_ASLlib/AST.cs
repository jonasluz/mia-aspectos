namespace JALJ_MIA_ASLlib
{
    /// <summary>
    /// Abstract Syntax Tree (AST) abstract node.
    /// </summary>
    public abstract class AST
    {
        /// <summary>
        /// Default ast string internal format.
        /// </summary>
        public static ASTFormat.FormatType format = ASTFormat.FormatType.TREE;

        // public overriding.
        public override string ToString()
        {
            return ASTFormat.Format(this, format);
        }
    }

    /// <summary>
    /// Simple propositional AST node.
    /// </summary>
    public class ASTProp : AST
    {
        /// <summary>
        /// Proposition letter
        /// </summary>
        public char value;

        // Constructor.
        public ASTProp(char value)
        {
            this.value = value;
        }
    }

    /// <summary>
    /// Unary operation AST node.
    /// </summary>
    public class ASTOpUnary : AST
    {
        // Propositional symbol for negation.
        public Language.Symbol value;
        // Negated AST.
        public AST ast;

        // Constructor.
        public ASTOpUnary(AST ast, Language.Symbol value)
        {
            this.value = value;
            this.ast = ast;
        }
    }

    /// <summary>
    /// Binary operation AST node.
    /// </summary>
    public class ASTOpBinary : AST
    {
        // Operation symbol.
        public Language.Symbol value;
        // Left and right operated AST.
        public AST left, right;

        // Constructor.
        public ASTOpBinary(AST left, AST right, Language.Symbol value)
        {
            this.left = left;
            this.right = right;
            this.value = value;
        }
    }
}
