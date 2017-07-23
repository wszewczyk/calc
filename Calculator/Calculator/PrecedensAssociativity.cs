namespace Calculator
{
    public struct PrecedensAssociativity
    {
        public Associativity Associativity;
        public int Precedens;

        public PrecedensAssociativity(int p, Associativity a)
        {
            Precedens = p;
            Associativity = a;
        }
    }
}