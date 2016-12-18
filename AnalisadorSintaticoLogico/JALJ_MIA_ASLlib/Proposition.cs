using System;
using System.Linq;
using System.Collections.Generic;

namespace JALJ_MIA_ASLlib
{
    /// <summary>
    /// Proposition root class.
    /// </summary>
    public abstract class Proposition: IComparable
    {
        #region Public static functions

        // Transitional function. Convert from AST.
        public static Proposition FromAST(AST ast)
        {
            switch (ast.GetType().Name)
            {
                case "ASTProp":
                    return new SingleProposition(ast as ASTProp);
                case "ASTOpUnary":
                    return new NegationProposition(ast as ASTOpUnary);
                case "ASTOpBinary":
                    ASTOpBinary opBin = ast as ASTOpBinary;
                    switch (opBin.value)
                    {
                        case Language.Symbol.E:
                            return new ConjunctiveProposition(opBin);
                        case Language.Symbol.OU:
                            return new DisjunctiveProposition(opBin);
                        case Language.Symbol.IMPLICA:
                            return new ImpliesProposition(opBin);
                        case Language.Symbol.EQUIVALE:
                            return new EquivalentProposition(opBin);
                        default:
                            throw new Exception(string.Format(
                                "The operation {0} is not supported for conversion to Proposition",
                                opBin.value
                              ));
                    }
            }

            return null;
        }

        #endregion Public static functions

        #region Public functions

        /// <summary>
        /// Common negation. 
        /// </summary>
        /// <returns></returns>
        public virtual Proposition Negated()
        {
            return new NegationProposition(this);
        }

        /// <summary>
        /// Compare if this proposition negates other.
        /// </summary>
        /// <param name="other">Proposition to compare negation to</param>
        /// <returns>If this proposition negates the other one</returns>
        public virtual bool Negates(Proposition other)
        {
            return this.Negated().Equals(other);
        }

        #endregion Public functions

        public abstract int CompareTo(object obj);
    } // Proposition class

    /// <summary>
    /// Single proposition, composed by just a propositional letter.
    /// </summary>
    public class SingleProposition: Proposition
    {
        /// <summary>
        /// Representative letter.
        /// </summary>
        public char Letter
        {
            get; private set;
        }

        #region Constructors

        // Constructor
        public SingleProposition(char letter)
        {
            if (Language.Lang.IsValidLetter(letter)) Letter = letter;
            else throw new Exception(string.Format(
                "A SingleProposition must be created with a valid letter. They are: {0}", 
                string.Join(",", Language.Lang.PropositionalLetter)
              ));
        }
        // Transition constructor from AST.
        public SingleProposition(ASTProp ast)
        {
            Letter = ast.value;
        }

        #endregion Constructors

        #region object class overriding

        public override string ToString()
        {
            return Letter.ToString();
        }
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            SingleProposition other = obj as SingleProposition;
            return other.Letter.Equals(this.Letter);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;
            SingleProposition other = obj as SingleProposition;
            return this.Letter.CompareTo(other.Letter);
        }

        #endregion object class overriding

    } // SingleProposition class

    /// <summary>
    /// Abstract class for an unary operation (only Negation is known).
    /// </summary>
    public abstract class UnaryOperation: Proposition
    {
        /// <summary>
        /// The negated proposition.
        /// </summary>
        public Proposition P
        {
            get; protected set;
        }

        #region Constructors

        // Constructor
        public UnaryOperation(Proposition p)
        {
            P = p;
        }
        public UnaryOperation(char letter)
        {
            P = new SingleProposition(letter);
        }
        // transitional constructor.
        public UnaryOperation(ASTOpUnary ast)
        {
            P = Proposition.FromAST(ast.ast);
        }

        #endregion Constructors

        #region object class overriding

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            UnaryOperation other = obj as UnaryOperation;
            return other.P == this.P;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected string ToStringImpl(string oper)
        {
            return string.Format("({0}{1})", oper, P);
        }

        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;
            UnaryOperation other = obj as UnaryOperation;
            return this.P.CompareTo(other.P);
        }

        #endregion object class overriding

    } // UnaryOperation class

    /// <summary>
    /// Abstract class for a binary logic operation.
    /// </summary>
    public abstract class BinaryOperation : Proposition
    {
        #region Attributes 

        public Proposition Left
        {
            get; protected set;
        }
        public Proposition Right
        {
            get; protected set;
        }

        #endregion Attributes

        #region Constructors

        public BinaryOperation(Proposition p, Proposition q)
        {
            Left = p; Right = q;
        }
        // transitional constructor
        public BinaryOperation(ASTOpBinary ast)
        {
            Left = Proposition.FromAST(ast.left);
            Right = Proposition.FromAST(ast.right);
        }

        #endregion Constructors

        #region object class overriding

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            BinaryOperation other = obj as BinaryOperation;
            return other.Left == this.Left && other.Right == this.Right;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected string ToStringImpl(string oper)
        {
            return string.Format("({0} {2} {1})", Left, Right, oper);
        }

        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;
            BinaryOperation other = obj as BinaryOperation;
            return this.Left.CompareTo(other.Left) * 10 + this.Right.CompareTo(other.Right);
        }

        #endregion object class overriding

    } // BinaryOperation class

    /// <summary>
    /// Abstract class for a multiple operation, all of the same type.
    /// </summary>
    public abstract class MultipleOperation: Proposition
    {
        public bool ISNullClause
        {
            get
            {
                return m_props.Count() == 0;
            }
        }

        public IEnumerable<Proposition> Props
        {
            get
            {
                return m_props;
            }
        }
        protected List<Proposition> m_props = new List<Proposition>();

        public abstract void Simplify();

        #region Constructors

        public MultipleOperation(params Proposition[] props)
        {
            m_props = new List<Proposition>(props);
        }
        public MultipleOperation(IEnumerable<Proposition> props)
        {
            m_props = new List<Proposition>(props);
        }
        public MultipleOperation(Proposition prop)
        {
            if (prop is BinaryOperation)
                m_props = new List<Proposition>(Plainify(prop));
            else
                m_props.Add(prop);
        }
        // transitional constructor.
        public MultipleOperation(AST ast, Language.Symbol oper = Language.Symbol.INVALIDO)
        {
            if (oper == Language.Symbol.INVALIDO && ast.GetType().Name == "ASTOpBinary")
                oper = (ast as ASTOpBinary).value;
            m_props = new List<Proposition>(ConvertFromAST(ast, oper));
        }

        #endregion Constructors

        #region object class overriding

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            MultipleOperation other = obj as MultipleOperation;
            return
                other.m_props.Count() == this.m_props.Count() &&
                other.m_props.TrueForAll(p => this.m_props.Contains(p));
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;
            MultipleOperation other = obj as MultipleOperation;
            return this.m_props.Count() - other.m_props.Count();
        }

        #endregion object class overriding

        #region Protected functions

        protected IEnumerable<Proposition> Plainify(Proposition prop, string type = null)
        {
            List<Proposition> result = new List<Proposition>();

            if (prop is BinaryOperation)
            {
                if (type == null) type = prop.GetType().Name;

                if (prop.GetType().Name.Equals(type))
                {
                    BinaryOperation binary = prop as BinaryOperation;
                    result.AddRange(Plainify(binary.Left));
                    result.AddRange(Plainify(binary.Right));
                    return result;
                }
            }

            // else: 
            result.Add(prop);
            return result;
        }

        protected IEnumerable<Proposition> ConvertFromAST(AST ast, Language.Symbol oper)
        {
            if (ast == null) return null;

            List<Proposition> result = new List<Proposition>();
            string type = ast.GetType().Name;
            if (type == "ASTOpBinary")
            {
                ASTOpBinary opBin = ast as ASTOpBinary;
                if (opBin.value == oper)
                {
                    result.AddRange(ConvertFromAST(opBin.left, oper));
                    result.AddRange(ConvertFromAST(opBin.right, oper));
                    return result;
                }
            }

            // else
            result.Add(Proposition.FromAST(ast));
            return result;
        }

        protected string ToStringImpl(string oper)
        {
            if (m_props.Count() == 0) return "[]";
            string result = m_props.First().ToString();
            foreach(var prop in m_props)
            {
                if (prop == m_props.First()) continue;
                result += string.Format(" {0} {1}", oper, prop);
            }

            return result;
        }

        #endregion Protected functions

    } // MultipleOperation class

    /// <summary>
    /// Negation logic operation.
    /// </summary>
    public class NegationProposition : UnaryOperation
    {
        // Constructors
        public NegationProposition(Proposition p): base(p) { }
        public NegationProposition(char letter) : base(letter) { }
        public NegationProposition(ASTOpUnary ast): base(ast) { }

        public override Proposition Negated()
        {
            return P;
        }

        public override string ToString()
        {
            return base.ToStringImpl("~");
        }
    } // NegationProposition class

    /// <summary>
    /// Conjunctive (AND) logical operation.
    /// </summary>
    public class ConjunctiveProposition : BinaryOperation
    {
        public ConjunctiveProposition(Proposition p, Proposition q) : base(p, q) { }
        public ConjunctiveProposition(ASTOpBinary ast) : base(ast)
        {
            if (ast.value != Language.Symbol.E)
                throw new Exception("A ConjunctiveProposition can only be created from an AST if this is a ASTOpBinary of type E.");
        }

        public override string ToString()
        {
            return base.ToStringImpl("&");
        }
    } // ConjunctiveProposition class

    /// <summary>
    /// Disjunctive (OR) logical operation.
    /// </summary>
    public class DisjunctiveProposition : BinaryOperation
    {
        public DisjunctiveProposition(Proposition p, Proposition q) : base(p, q) { }
        public DisjunctiveProposition(ASTOpBinary ast) : base(ast)
        {
            if (ast.value != Language.Symbol.OU)
                throw new Exception("A DisjunctiveProposition can only be created from an AST if this is a ASTOpBinary of type OU.");
        }

        public override string ToString()
        {
            return base.ToStringImpl("|");
        }
    } // DisjunctiveProposition class

    /// <summary>
    /// Implies (if..then) logical operation.
    /// </summary>
    public class ImpliesProposition : BinaryOperation
    {
        public ImpliesProposition(Proposition p, Proposition q) : base(p, q) { }
        public ImpliesProposition(ASTOpBinary ast) : base(ast)
        {
            if (ast.value != Language.Symbol.IMPLICA)
                throw new Exception("An ImpliesProposition can only be created from an AST if this is a ASTOpBinary of type IMPLICA.");
        }

        public override string ToString()
        {
            return base.ToStringImpl("->");
        }
    } // ImpliesProposition class

    /// <summary>
    /// Equivalence (implies and is implied by) logical operation.
    /// </summary>
    public class EquivalentProposition : BinaryOperation
    {
        public EquivalentProposition(Proposition p, Proposition q) : base(p, q) { }
        public EquivalentProposition(ASTOpBinary ast) : base(ast)
        {
            if (ast.value != Language.Symbol.EQUIVALE)
                throw new Exception("An EquivalentProposition can only be created from an AST if this is a ASTOpBinary of type EQUIVALE.");
        }

        public override string ToString()
        {
            return base.ToStringImpl("<->");
        }
    } // EquivalentProposition class

    /// <summary>
    /// Exclusive disjunction (exclusive OR - XOR) logical operation.
    /// </summary>
    public class ExclusiveDisjunctionProposition : BinaryOperation
    {
        public ExclusiveDisjunctionProposition(Proposition p, Proposition q) : base(p, q) { }

        public override string ToString()
        {
            return base.ToStringImpl("xor");
        }
    } // ExclusiveDisjunction class

    /// <summary>
    /// Multiple conjunction (a multiple AND operation).
    /// </summary>
    public class MultipleConjunction : MultipleOperation
    {
        public MultipleConjunction(params Proposition[] props) : base(props) { }
        public MultipleConjunction(IEnumerable<Proposition> props) : base(props) { }
        public MultipleConjunction(Proposition prop) : base(prop) { }

        // transitional constructor.
        public MultipleConjunction(AST ast): base(ast, Language.Symbol.E) { }

        public override void Simplify()
        {
            m_props = new List<Proposition>(m_props.Distinct());
        }

        public override string ToString()
        {
            return base.ToStringImpl("&");
        }
    } // MultipleConjunction class

    /// <summary>
    /// Multiple disjunction (a multiple OR operation). 
    /// </summary>
    public class MultipleDisjunction : MultipleOperation
    {
        public MultipleDisjunction(params Proposition[] props) : base(props) { }
        public MultipleDisjunction(IEnumerable<Proposition> props): base(props) { }
        public MultipleDisjunction(Proposition prop): base(prop) { }
        // transitional constructor.
        public MultipleDisjunction(AST ast): base(ast, Language.Symbol.OU) { }

        /// <summary>
        /// Applies the Resolution technic.
        /// </summary>
        /// <param name="other">other disjunction to apply.</param>
        /// <returns>the resoluted disjunction if found</returns>
        public MultipleDisjunction ApplyResolution(MultipleDisjunction other)
        {
            List<Proposition> result = new List<Proposition>(m_props);
            result.AddRange(other.m_props);

            foreach (Proposition p in m_props)
                foreach (Proposition q in other.m_props)
                    if (p.Negated().Equals(q) || q.Negated().Equals(p))
                    {
                        result.Remove(p);
                        result.Remove(q);
                        MultipleDisjunction md = new MultipleDisjunction(result);
                        md.Simplify();
                        return md;
                    }

            return null; // A resolution wasn't found.
        }

        public override void Simplify()
        {
            for (int i = 0; i < m_props.Count; i++)
                for (int j = i + 1; j < m_props.Count; j++)
                    if (m_props[i].Equals(m_props[j])) m_props.RemoveAt(j);
        }

        public override string ToString()
        {
            return base.ToStringImpl("|");
        }
    } // MUltipleDisjunction class

    /// <summary>
    /// Conjunctive Normal Form Propositional (transitional version).
    /// </summary>
    public class CNFProposition: MultipleConjunction
    {
        public AST Ast
        {
            get; private set;
        }

        public new IEnumerable<MultipleDisjunction> Props
        {
            get
            {
                List<MultipleDisjunction> result = new List<MultipleDisjunction>();
                foreach (MultipleDisjunction item in m_props)
                    result.Add(item);
                return result;
            }
        }

        // Transition constructor. Creates a CNFProposition from an AST.
        public CNFProposition(AST ast)
        {
            this.Ast = ast;
            ast = CNF.Convert(ast);
            IEnumerable<Proposition> orClauses = ConvertFromAST(ast, Language.Symbol.E);
            if (orClauses == null) return;

            foreach(Proposition orClause in orClauses)
                m_props.Add(new MultipleDisjunction(orClause));
            m_props.Sort();
        }
        protected CNFProposition(IEnumerable<MultipleDisjunction> props):base(props) { }

        public override string ToString()
        {
            return string.Join(" , ", m_props);
        }

    }

}
