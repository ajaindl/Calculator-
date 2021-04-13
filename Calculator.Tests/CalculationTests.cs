using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculationTests
    {
        private ExpressionCalculator _calculator;

        [TestInitialize]
        public void Initialize()
        {
            _calculator = new ExpressionCalculator();
        }
        [TestMethod]
        public void Test_Basic_Expression()
        {
            var expression = "add(1,2)";
            int expResult = 3;
            int result = _calculator.Calculate(expression);
            Assert.AreEqual(expResult, result);
        }

        [TestMethod]
        public void Test_Nested_Expression()
        {
            var expression = "mult(add(3,4),4)";
            int expResult = 28;
            int result = _calculator.Calculate(expression);
            Assert.AreEqual(expResult, result);
        }

        [TestMethod]
        public void Test_Multiple_Nested_Expressions()
        {
            var expression = "add(mult(2,2),div(4,2))";
            int expResult = 6;
            int result = _calculator.Calculate(expression);
            Assert.AreEqual(expResult, result);
        }
    }
}
