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
                string s = System.Console.ReadLine();
                Console.WriteLine("input: {0}", s);
                Console.WriteLine();
                List<string> ss = s.Split(' ').ToList();
                
                double res = calc.Execute(ss);
                Console.WriteLine("Result: {0}", res);
                Console.ReadKey();
            }
        }
    }
}