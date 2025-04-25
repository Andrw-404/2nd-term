namespace CalculatorOnForms2.Tests
{
    public class CalculatorTests
    {
        private Calculator testCalculator;

        [SetUp]
        public void Setup()
        {
            testCalculator = new Calculator();
        }

        [Test]
        public void Addition_ExpressionWithZero_ShouldReturnCorrectAmount()
        {
            testCalculator.AppendNumber("5");
            testCalculator.SetOperator('+');
            testCalculator.AppendNumber("0");
            testCalculator.Calculate();
            Assert.That(testCalculator.CurrentDisplay, Is.EqualTo("5"));
        }
    }
}
