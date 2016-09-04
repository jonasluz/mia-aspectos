namespace JALJ_MIA_ASLlib
{
    public abstract class AST
    {
        public static ASTFormat.FormatType format = ASTFormat.FormatType.TREE;

        public override string ToString()
        {
            return ASTFormat.Format(this, format);
        }
    }

    public class ASTProp : AST
    {
        public char value;

        public ASTProp(char value)
        {
            this.value = value;
        }
    }

    public class ASTOpUnary : AST
    {
        public Language.Symbol value;
        public AST ast;

        public ASTOpUnary(AST ast, Language.Symbol value)
        {
            this.value = value;
            this.ast = ast;
        }
    }

    public class ASTOpBinary : AST
    {
        public Language.Symbol value;
        public AST left, right;

        public ASTOpBinary(AST left, AST right, Language.Symbol value)
        {
            this.left = left;
            this.right = right;
            this.value = value;
        }
    }
}
