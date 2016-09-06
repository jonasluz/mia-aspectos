using System.Collections.Generic;

namespace JALJ_MIA_ASLlib
{
    public class Parser
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
        int m_conditionals;
        AST m_current;

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
                case Language.Symbol.NAO:
                    ast = new ASTOpUnary(Walk(true), token.type);
                    break;
                case Language.Symbol.E:
                case Language.Symbol.OU:
                    ast = new ASTOpBinary(m_current, Walk(true), token.type);
                    break;
                case Language.Symbol.CONDICIONAL:
                case Language.Symbol.BICONDICIONAL:
                    bool bi = token.type == Language.Symbol.BICONDICIONAL;
                    bool forward =                      // sigo adiante se...
                        m_conditionals == 0 ||          // ... não há condicional aguardando ou...
                        (m_conditionals == 2 && !bi);   // ... bicondicional aguarda e atual é condicional simples.
                    if (forward)
                    {   // segue em frente.
                        int conditionals = m_conditionals;
                        m_conditionals = bi ? 2 : 1;
                        ast = new ASTOpBinary(m_current, Walk(false), token.type);
                        if (m_conditionals == 0) precede = false;
                        m_conditionals = conditionals;
                    } else 
                    {   // conclui operação em andamento (recursão atual) para voltar depois.
                        m_idx--;
                        ast = m_current;
                        precede = true;
                        m_conditionals = 0;
                        break;
                    }
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
