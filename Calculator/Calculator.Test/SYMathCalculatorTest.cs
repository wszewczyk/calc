namespace Calculator.Test
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SYMathCalculatorTest
    {
        [TestMethod]
        public void Execute_returns_correct_result()
        {
            int res = 5;
            string formula = "3 + 2";

            ICalculator<int> calc = new SYMathCalculator();

            int resFromCalc = calc.Execute(formula);

            Assert.AreEqual(res, resFromCalc);
        }
    }
}
