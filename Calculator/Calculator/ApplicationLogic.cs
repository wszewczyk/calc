namespace Calculator
{
    using System;

    public class ApplicationLogic
    {
        private ICalculator<int> calc;

        public ApplicationLogic(ICalculator<int> calc)
        {
            this.calc = calc;
        }

        public void Run()
        {
            string s = Console.ReadLine();
            Console.WriteLine($"input: {s}");
            Console.WriteLine();

            double res = this.calc.Execute(s);
            Console.WriteLine($"Result: {res}");
            Console.ReadKey();
        }
    }
}