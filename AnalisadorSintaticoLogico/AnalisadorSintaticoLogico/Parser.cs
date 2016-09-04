using System.Collections.Generic;

namespace JALJ_MIA_Fundamentos
{
    class Parser
    {

        #region Atributos públicos

        public List<Token> Tokens
        {
            get; set;
        }

        public AST Ast
        {
            get; private set;
        }

        #endregion Atributos públicos

        int m_idx;
        AST m_current;
        Stack<AST> m_opened = new Stack<AST>();

        public AST Parse(List<Token> tokens = null)
        {
            if (tokens != null) Tokens = tokens;

            m_idx = -1;

            Ast = Walk();

            return Ast;
        }

        AST Walk(bool precede = false)
        {
            m_idx++;
            if (m_idx >= Tokens.Count) return null;

            Token token = Tokens[m_idx];
            AST ast = null;

            switch (token.type)
            {
                case Language.Symbol.PROP:
                    ast = new ASTProp(token.value);
                    break;
                case Language.Symbol.OPER_NAO:
                    ast = new ASTOpUnary(Walk(true), token.type);
                    break;
                case Language.Symbol.OPER_E:
                case Language.Symbol.OPER_OU:
                case Language.Symbol.OPER_IMPLICA:
                    ast = new ASTOpBinary(m_current, Walk(true), token.type);
                    break;
                case Language.Symbol.ABERTURA:
                    while (Walk(precede) != null)
                        ast = m_current;
                    break;
                case Language.Symbol.FECHAMENTO:
                    return null;
            }

            m_current = ast;

            if (!precede && m_idx < Tokens.Count) Walk();

            return m_current;
        }
    }
}
