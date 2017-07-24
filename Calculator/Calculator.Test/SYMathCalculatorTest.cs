namespace Calculator.Test
{
    using System;

    using Calculator.Command.CommandSYMath;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SYMathCalculatorTest
    {
        [TestMethod]
        public void Execute_returns_correct_result()
        {
            int res = 5;
            string formula = "3 + 2";

            ICalculator<int> calc = new SYMathCalculator(new SYMathCommandReciver());

            int resFromCalc = calc.Execute(formula);

            Assert.AreEqual(res, resFromCalc);
        }

        [TestMethod]
        public void Execute_throws_exception_with_bad_formula()
        {
            int res = 5;
            string formula = "a + 2";

            ICalculator<int> calc = new SYMathCalculator(new SYMathCommandReciver());

            try
            {
                int resFromCalc = calc.Execute(formula);
                Assert.Fail("Exception not cought");
            }
            catch (Exception e)
            {
                if (e.Message != "Bad formula")
                {
                    Assert.Fail("Bad exception");
                }
            }
        }
    }
}
