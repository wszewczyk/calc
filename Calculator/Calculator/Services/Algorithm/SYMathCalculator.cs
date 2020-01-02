using System;
using System.Collections.Generic;
using System.Globalization;
using Calculator.Command;
using Calculator.Command.CommandSYMath;
using Calculator.Models;
using Calculator.Models.Enums;

namespace Calculator.Services.Algorithm
{
    public class SYMathCalculator : SYBaseCalculator<double, string>
    {
        private ASYCommand _command;

        private readonly AddCommand _addCommand;

        private readonly SubtractCommand _subtractCommand;

        private readonly MultiplyCommand _multiplyCommand;

        private readonly DivCommand _divCommand;

        private readonly PowCommand _powCommand;

        public SYMathCalculator(ISYReciever reciever)
        {
            _addCommand = new AddCommand(reciever);
            _subtractCommand = new SubtractCommand(reciever);
            _multiplyCommand = new MultiplyCommand(reciever);
            _divCommand = new DivCommand(reciever);
            _powCommand = new PowCommand(reciever);
        }

        private readonly Dictionary<char, PrecedensAssociativity> operators = new Dictionary<char, PrecedensAssociativity>()
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

        protected override double Evaluate(double result1, char opr, double result2)
        {
            switch (opr)
            {
                case '+':
                    this._command = this._addCommand;
                    return this._command.Execute(result1, result2);
                case '-':
                    this._command = this._subtractCommand;
                    return this._command.Execute(result1, result2);
                case '*':
                    this._command = this._multiplyCommand;
                    return this._command.Execute(result1, result2);
                case '/':
                    this._command = this._divCommand;
                    return this._command.Execute(result1, result2);
                case '^':
                    this._command = this._powCommand;
                    return this._command.Execute(result1, result2);
            }

            throw new Exception("Wrong operator!");
        }

        protected override double TypecastIdentifier(string input)
        {
            double result;
            if (double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out result)) return result;
            throw new Exception("Wrong identifier!");
        }

        protected override bool IsIdentifier(string input)
        {
            return double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out _);
        }

        protected override bool IsOperator(char? opr)
        {
            if (opr == null) return false;
            return operators.ContainsKey((char) opr);
        }

        protected override char? TypecastOperator(string input)
        {
            if (!operators.ContainsKey(input[0])) return null;
            return (char?) input[0];
        }

        protected override List<string> Split(object expression)
        {
            List<string> tokens = ((string) expression).Split(' ').ToList();
            return tokens;
        }

        protected override Associativity Association(char opr)
        {
            if (!operators.ContainsKey(opr)) throw new Exception("Wrong operator!!");
            return operators[opr].Associativity;
        }

        protected override double Precedence(char op1, char op2)
        {
            if (!operators.ContainsKey(op1)) throw new Exception("Wrong operator!!");
            if (!operators.ContainsKey(op2)) throw new Exception("Wrong operator!!");
            if (operators[op1].Precedens > operators[op2].Precedens) return 1;
            if (operators[op1].Precedens < operators[op2].Precedens) return -1;
            return 0;
        }

        protected override bool IsForbidden(string input)
        {
            string nums = "0123456789.,";
            string ops = "()-+*/^";

            if (ops.Contains(input) && input.Length == 1)
            {
                return false;
            }

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