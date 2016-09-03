
namespace JALJ_MIA_Fundamentos
{
    struct Token
    {
        public Language.Symbol type;
        public char value;

        public Token(Language.Symbol symbol, char value)
        {
            this.type = symbol;
            this.value = value;
        }
    }
}
