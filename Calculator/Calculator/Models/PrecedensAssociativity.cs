using Calculator.Models.Enums;

namespace Calculator.Models
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