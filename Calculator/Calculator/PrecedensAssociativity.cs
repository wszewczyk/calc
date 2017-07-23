namespace Calculator
{
    public struct PrecedensAssociativity
    {
        public PrecedensAssociativity(int p, Asso a)
        {
            Prec = p;
            Associativity = a;
        }

        public int Prec;

        public enum Asso
        {
            Left,
            Right
        }

        public Asso Associativity;
    }
}