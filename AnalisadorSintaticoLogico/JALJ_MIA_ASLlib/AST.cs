using System;

namespace JALJ_MIA_ASLlib
{
    #pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()

    /// <summary>
    /// Abstract Syntax Tree (AST) abstract node.
    /// </summary>
    public abstract class AST
    {
        /// <summary>
        /// Default ast string internal format.
        /// </summary>
        public static ASTFormat.FormatType format = ASTFormat.FormatType.PLAIN;

        /// <summary>
        /// Negate this AST.
        /// </summary>
        /// <returns>This AST negation.</returns>
        public virtual AST Negation()
        {
            return new ASTOpUnary(this, Language.Symbol.NAO);
        }

        // override object.Equals
        public abstract override bool Equals(object obj);

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

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return this.value == (obj as ASTProp).value;
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

        public override AST Negation()
        {
            return this.ast;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ASTOpUnary other = obj as ASTOpUnary;
            return this.value == other.value && this.ast.Equals(other.ast);
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ASTOpBinary other = obj as ASTOpBinary;
            return
                this.left.Equals(other.left) &&
                this.right.Equals(other.right) &&
                this.value == other.value
              ;
        }
    }

    #pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
}
