
namespace JALJ_MIA_ASLlib
{
    public struct Token
    {
        public Language.Symbol type;
        public char value;

        public Token(Language.Symbol symbol, char value)
        {
            this.type = symbol;
            this.value = value;
        }

        public override string ToString()
        {
            return this.type + "{ " + this.value + " }";
        }
    }
}
