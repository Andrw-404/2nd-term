// <copyright file="CalculatorTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorOnForms2.Tests
{
#pragma warning disable SA1600 // Elements should be documented
    public class CalculatorTests
    {
        private Calculator testCalculator;

        [SetUp]
        public void Setup()
        {
            this.testCalculator = new Calculator();
        }

        [Test]
        public void AppendNumber_MultiDigitNumber_ShouldShowTheCorrectNumber()
        {
            this.testCalculator.AppendNumber("1");
            this.testCalculator.AppendNumber("5");
            this.testCalculator.AppendNumber("7");
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("157"));
        }

        [Test]
        public void AppendNumber_AddingZerosToZero_ShoulShowSingleZero()
        {
            this.testCalculator.AppendNumber("0");
            this.testCalculator.AppendNumber("0");
            this.testCalculator.AppendNumber("0");
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("0"));
        }

        [Test]
        public void Clear_AddingANumberAndAnOperator_ShoulShowSingleZero()
        {
            this.testCalculator.AppendNumber("145");
            this.testCalculator.SetOperator('+');
            this.testCalculator.Clear();
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("0"));
        }

        [Test]
        public void Addition_ExpressionWithZero_ShouldReturnCorrectAmount()
        {
            this.testCalculator.AppendNumber("5");
            this.testCalculator.SetOperator('+');
            this.testCalculator.AppendNumber("0");
            this.testCalculator.Calculate();
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("5"));
        }

        [Test]
        public void Addition_SimpleExpression_ShouldReturnCorrectAmount()
        {
            this.testCalculator.AppendNumber("5");
            this.testCalculator.SetOperator('+');
            this.testCalculator.AppendNumber("7");
            this.testCalculator.Calculate();
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("12"));
        }

        [Test]
        public void Addition_SimpleExpressionWithTwoDigitNumbers_ShouldReturnCorrectAmount()
        {
            this.testCalculator.AppendNumber("32");
            this.testCalculator.SetOperator('+');
            this.testCalculator.AppendNumber("68");
            this.testCalculator.Calculate();
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("100"));
        }

        [Test]
        public void Subtraction_ExpressionWithZero_ShouldReturnDecreasingNumber()
        {
            this.testCalculator.AppendNumber("4600");
            this.testCalculator.SetOperator('-');
            this.testCalculator.AppendNumber("0");
            this.testCalculator.Calculate();
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("4600"));
        }

        [Test]
        public void Subtraction_SimpleExpressionWithTwoDigitNumbers_ShouldReturnCorrectNegativeNumber()
        {
            this.testCalculator.AppendNumber("23");
            this.testCalculator.SetOperator('-');
            this.testCalculator.AppendNumber("64");
            this.testCalculator.Calculate();
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("-41"));
        }

        [Test]
        public void Multiplication_SimpleExpressionWithTwoDigitNumbers_ShouldReturnCorrectProductOfNumbers()
        {
            this.testCalculator.AppendNumber("12");
            this.testCalculator.SetOperator('*');
            this.testCalculator.AppendNumber("17");
            this.testCalculator.Calculate();
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("204"));
        }

        [Test]
        public void Multiplication_ExpressionWithZero_ShouldReturnZero()
        {
            this.testCalculator.AppendNumber("648");
            this.testCalculator.SetOperator('*');
            this.testCalculator.AppendNumber("0");
            this.testCalculator.Calculate();
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("0"));
        }

        [Test]
        public void Division_SimpleExpressionWithTwoDigitNumbers_ShouldReturnCorrectQuotient()
        {
            this.testCalculator.AppendNumber("325");
            this.testCalculator.SetOperator('/');
            this.testCalculator.AppendNumber("13");
            this.testCalculator.Calculate();
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("25"));
        }

        [Test]
        public void Division_ZeroIsTheDivisor_ShouldThrowAnException()
        {
            this.testCalculator.AppendNumber("350");
            this.testCalculator.SetOperator('/');
            this.testCalculator.AppendNumber("0");
            Assert.Throws<DivideByZeroException>(() => this.testCalculator.Calculate());
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("Деление на ноль невозможно"));
        }

        [Test]
        public void Calculate_SequentialInput_ShouldReturnCorrectValue()
        {
            this.testCalculator.AppendNumber("5");
            this.testCalculator.SetOperator('+');
            this.testCalculator.AppendNumber("7");
            this.testCalculator.SetOperator('*');
            this.testCalculator.AppendNumber("14");
            this.testCalculator.SetOperator('/');
            this.testCalculator.AppendNumber("7");
            this.testCalculator.SetOperator('-');
            this.testCalculator.AppendNumber("12");
            Assert.That(this.testCalculator.CurrentDisplay, Is.EqualTo("12"));
        }
    }
}
