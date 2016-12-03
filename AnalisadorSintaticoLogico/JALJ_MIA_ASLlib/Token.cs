
namespace JALJ_MIA_ASLlib
{
    /// <summary>
    /// Token data structure.
    /// </summary>
    public struct Token
    {
        /// <summary>
        /// Language symbol for this token instance.
        /// </summary>
        public Language.Symbol type;
        /// <summary>
        /// Character representation for this symbol.
        /// </summary>
        public char value;

        // Construtor.
        public Token(Language.Symbol symbol, char value)
        {
            this.type = symbol;
            this.value = value;
        }

        // Conversão para string.
        public override string ToString()
        {
            return this.type + "{ " + this.value + " }";
        }
    }
}
