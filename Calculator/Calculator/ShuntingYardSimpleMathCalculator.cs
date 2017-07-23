﻿namespace Calculator
{
    using System;
    using System.Collections.Generic;
    public class ShuntingYardSimpleMathCalculator : ShuntingYardBaseCalculator<int, string>
    {
        Dictionary<char, PrecedensAssociativity> Oprs = new Dictionary<char, PrecedensAssociativity>()
        {
            { '+', new PrecedensAssociativity(2,PrecedensAssociativity.Asso.Left)},
            { '-', new PrecedensAssociativity(2,PrecedensAssociativity.Asso.Left)},
            { '*', new PrecedensAssociativity(3,PrecedensAssociativity.Asso.Left)},
            { '/', new PrecedensAssociativity(3,PrecedensAssociativity.Asso.Left)},
            { '^', new PrecedensAssociativity(4,PrecedensAssociativity.Asso.Right)},
        };

        protected override int Evaluate(int result1, char opr, int result2)
        {
            switch (opr)
            {
                case '+':
                    return (int)result1 + result2;
                case '-':
                    return (int)result1 - result2;
                case '*':
                    return (int)result1 * result2;
                case '/':
                    return (int)result1 / result2;
                case '^':
                    return (int)Math.Pow(result1, result2);
            }
            throw new Exception("Wrong operator!!");
        }

        protected override int TypecastIdentifier(string input)
        {
            int result;
            if (int.TryParse(input, out result))
                return result;
            throw new Exception("Wrong identifier!!");
        }
        protected override bool IsIdentifier(string input)
        {
            int result;
            return int.TryParse(input, out result);
        }
        protected override bool IsOperator(char? opr)
        {
            if (opr == null) return false;
            return Oprs.ContainsKey((char)opr);
        }
        protected override char? TypecastOperator(string input)
        {
            if (!Oprs.ContainsKey(input[0]))
                return null;
            return (char?)input[0];
        }

        protected override PrecedensAssociativity.Asso Association(char opr)
        {
            if (!Oprs.ContainsKey(opr))
                throw new Exception("Wrong operator!!");
            return Oprs[opr].Associativity;
        }

        protected override int Precedence(char opr1, char opr2)
        {
            if (!Oprs.ContainsKey(opr1))
                throw new Exception("Wrong operator!!");
            if (!Oprs.ContainsKey(opr2))
                throw new Exception("Wrong operator!!");
            if (Oprs[opr1].Prec > Oprs[opr2].Prec) return 1;
            if (Oprs[opr1].Prec < Oprs[opr2].Prec) return -1;
            return 0;
        }

        protected override bool IsNoise(string input)
        {
            return false;
        }
    }
}