namespace JALJ_MIA_Fundamentos
{
    abstract class AST
    {
        public override string ToString()
        {
            return ASTFormat.Format(this);
        }
    }

    class ASTProp : AST
    {
        public char value;

        public ASTProp(char value)
        {
            this.value = value;
        }
    }

    class ASTOpUnary : AST
    {
        public Language.Symbol value;
        public AST ast;

        public ASTOpUnary(AST ast, Language.Symbol value)
        {
            this.value = value;
            this.ast = ast;
        }
    }

    class ASTOpBinary : AST
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
