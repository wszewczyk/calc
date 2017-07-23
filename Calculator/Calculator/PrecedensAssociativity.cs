namespace Calculator
{
    public struct PrecedensAssociativity
    {
        public Asso Associativity;
        public int Precedens;

        public PrecedensAssociativity(int p, Asso a)
        {
            Precedens = p;
            Associativity = a;
        }

        public enum Asso
        {
            Left,
            Right
        }
    }
}