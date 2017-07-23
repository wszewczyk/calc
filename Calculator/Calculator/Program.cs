namespace Calculator
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            {
                ICalculator<int> calc = new SYMathCalculator();
                string s = Console.ReadLine();
                Console.WriteLine($"input: {s}");
                Console.WriteLine();
                
                double res = calc.Execute(s);
                Console.WriteLine($"Result: {res}");
                Console.ReadKey();
            }
        }
    }
}