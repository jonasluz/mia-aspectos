using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorSintaticoLogico
{
    class Proposicao : ICloneable
    {
        /* Valores de classe (estáticos) */
        #region Valores estáticos - Mensagens de erro.
        /* Mensagens de erro */
        static readonly string S_ERR_PROPSIMPLESINVALIDA =
            "A proposição simples deve usar um caracter de a-z (minúsculo).";
        static readonly string S_ERR_PROPUNARIAINVALIDA =
            "Proposição unária apenas existe com o operador de negação.";
        #endregion Valores estáticos - Mensagens de erro

        /* Valor default/nulo para proposições simples */
        const char C_SIMPLES_DEFAULT_VALUE = '-';

        #region Atributos privados

        /* Acessor do extralógico de uma proposição simples */
        char ProposicaoSimples
        {
            set
            {
                if (Alfabeto.EhLetraProposicionalValida(value))
                    m_simples = value;
                else
                    throw new Exception(S_ERR_PROPSIMPLESINVALIDA);
            }
        }
        char m_simples = C_SIMPLES_DEFAULT_VALUE;

        Proposicao m_operando1, m_operando2;
        Operador m_operador;

        #endregion Atributos privados

        #region Construtores
        /* Construtores */

        public Proposicao(Proposicao prop)
        {
            m_operador = prop.m_operador;
            m_operando1 = prop.m_operando1;
            m_operando2 = prop.m_operando2;
            m_simples = prop.m_simples;
        }

        public Proposicao(char extralogico)
        {
            ProposicaoSimples = extralogico;
        }

        public Proposicao(char operando, Operador operador)
        {
            if (operador != Operador.NAO)
                throw new Exception(S_ERR_PROPUNARIAINVALIDA);
            ProposicaoSimples = operando;
            m_operador = operador;
        }

        public Proposicao(Proposicao operando, Operador operador)
        {
            if (operador != Operador.NAO)
                throw new Exception(S_ERR_PROPUNARIAINVALIDA);
            m_operando1 = operando;
            m_operador = operador;
        }

        public Proposicao(char operando1, char operando2, Operador operador)
        {
            m_operando1 = new Proposicao(operando1);
            m_operando2 = new Proposicao(operando2);
            m_operador = operador;
        }

        public Proposicao(Proposicao operando1, Proposicao operando2, Operador operador)
        {
            m_operando1 = operando1;
            m_operando2 = operando2;
            m_operador = operador;
        }

        #endregion Construtores

        #region Overriding

        /* Clonagem de um operador */
        public object Clone()
        {
            return new Proposicao(m_operando1, m_operando2, m_operador);
        }

        /* Conversão para string */
        public override string ToString()
        {
            string result = base.ToString();

            if (m_simples != C_SIMPLES_DEFAULT_VALUE)
            {
                if (m_operador != Operador.NULO) result += Alfabeto.TokenOfOperador(m_operador);
                result += m_simples;
            } else
            {
                result += m_operando1 + Alfabeto.TokenOfOperador(m_operador).ToString() + m_operando2;
            }

            return result;
        }

        #endregion Overriding
    }
}
