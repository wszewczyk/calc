namespace Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            {
                ICalculator<int, string> calc = new ShuntingYardSimpleMathCalculator();
                string s = Console.ReadLine();
                Console.WriteLine($"input: {s}");
                Console.WriteLine();
                List<string> ss = s.Split(' ').ToList();
                
                double res = calc.Execute(ss);
                Console.WriteLine($"Result: {res}");
                Console.ReadKey();
            }
        }
    }
}