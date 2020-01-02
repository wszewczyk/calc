using Calculator.Models;

namespace Calculator
{
    using System;

    public class ApplicationLogic
    {
        private readonly ICalculator<double> _calc;

        public ApplicationLogic(ICalculator<double> calc)
        {
            this._calc = calc;
        }

        public void Run()
        {
            while (true)
            {
                string s = Console.ReadLine();
                Console.WriteLine($"input: {s}");
                Console.WriteLine();

                double res = this._calc.Execute(s);
                Console.WriteLine($"Result: {res}");
            }
        }
    }
}