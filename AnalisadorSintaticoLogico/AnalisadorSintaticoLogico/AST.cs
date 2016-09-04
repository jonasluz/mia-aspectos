using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JALJ_MIA_Fundamentos
{
    abstract class AST
    {
        protected int nesting;

        protected AST(int nesting)
        {
            this.nesting = nesting;
        }
    }

    class ASTProp : AST
    {
        public char value;

        public ASTProp(char value, int nesting = 0) : base(nesting)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return "Prop { ".PadLeft(nesting * 4) + this.value + " }";
        }
    }

    class ASTOpUnary : AST
    {
        public Language.Symbol value;
        public AST ast;

        public ASTOpUnary(int nesting = 0) : base(nesting) { }
        public ASTOpUnary(AST ast, Language.Symbol value, int nesting = 0) : base(nesting)
        {
            this.value = value;
            this.ast = ast;
        }

        public override string ToString()
        {
            return this.value.ToString().PadLeft(nesting * 4) + " {\n"
                + this.ast + "\n" + " }".PadLeft(nesting * 4);
        }
    }

    class ASTOpBinary : AST
    {
        public Language.Symbol value;
        public AST left, right;

        public ASTOpBinary(int nesting = 0) : base(nesting) { }
        public ASTOpBinary(AST left, AST right, Language.Symbol value, int nesting = 0) : base(nesting)
        {
            this.left = left;
            this.right = right;
            this.value = value;
        }

        public override string ToString()
        {
            return this.value.ToString().PadLeft(nesting * 4) + " {\n"
                + this.left + ",\n"
                + this.right + "\n" + " }".PadLeft(nesting * 4);
        }
    }
}
