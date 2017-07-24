﻿namespace Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Calculator.Command;
    using Calculator.Command.CommandSYMath;

    public class SYMathCalculator : SYBaseCalculator<int, string>
    {
        private ASYCommand command;

        private AddCommand addCommand;

        private SubtractCommand subtractCommand;

        private MultiplyCommand multiplyCommand;

        private DivCommand divCommand;

        private PowCommand powCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="SYMathCalculator"/> class.
        /// </summary>
        /// <param name="reciever">
        /// The reciever.
        /// </param>
        public SYMathCalculator(ISYReciever reciever)
        {
            addCommand = new AddCommand(reciever);
            subtractCommand = new SubtractCommand(reciever);
            multiplyCommand = new MultiplyCommand(reciever);
            divCommand = new DivCommand(reciever);
            powCommand = new PowCommand(reciever);
        }

        Dictionary<char, PrecedensAssociativity> Oprs = new Dictionary<char, PrecedensAssociativity>()
                                                            {
                                                                    {
                                                                        '+', new PrecedensAssociativity(2, Associativity.Left)
                                                                    },
                                                                    {
                                                                        '-', new PrecedensAssociativity(2, Associativity.Left)
                                                                    },
                                                                    {
                                                                        '*', new PrecedensAssociativity(3, Associativity.Left)
                                                                    },
                                                                    {
                                                                        '/', new PrecedensAssociativity(3, Associativity.Left)
                                                                    },
                                                                    {
                                                                        '^',
                                                                        new PrecedensAssociativity(4, Associativity.Right)
                                                                    },
                                                            };

        protected override int Evaluate(int result1, char opr, int result2)
        {
            switch (opr)
            {
                case '+':
                    this.command = this.addCommand;
                    return this.command.Execute(result1, result2);
                case '-':
                    this.command = this.subtractCommand;
                    return this.command.Execute(result1, result2);
                case '*':
                    this.command = this.multiplyCommand;
                    return this.command.Execute(result1, result2);
                case '/':
                    this.command = this.divCommand;
                    return this.command.Execute(result1, result2);
                case '^':
                    this.command = this.powCommand;
                    return this.command.Execute(result1, result2);
            }

            throw new Exception("Wrong operator!");
        }

        protected override int TypecastIdentifier(string input)
        {
            int result;
            if (int.TryParse(input, out result)) return result;
            throw new Exception("Wrong identifier!");
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
            if (!Oprs.ContainsKey(input[0])) return null;
            return (char?)input[0];
        }

        protected override List<string> Split(object expression)
        {
            List<string> tokens = ((string)expression).Split(' ').ToList();
            return tokens;
        }

        protected override Associativity Association(char opr)
        {
            if (!Oprs.ContainsKey(opr)) throw new Exception("Wrong operator!!");
            return Oprs[opr].Associativity;
        }

        protected override int Precedence(char op1, char op2)
        {
            if (!Oprs.ContainsKey(op1)) throw new Exception("Wrong operator!!");
            if (!Oprs.ContainsKey(op2)) throw new Exception("Wrong operator!!");
            if (Oprs[op1].Precedens > Oprs[op2].Precedens) return 1;
            if (Oprs[op1].Precedens < Oprs[op2].Precedens) return -1;
            return 0;
        }

        protected override bool IsForbidden(string input)
        {
            string nums = "0123456789";
            string ops = "()-+*/^";

            if (ops.Contains(input) && input.Length == 1)
            {
                return false;
            }
            else
            {
                bool res = false;
                foreach (var c in input)
                {
                    if (!nums.Contains(c.ToString()))
                    {
                        res = true;
                    }
                }

                return res;
            }
        }
    }
}