namespace ParsingTree.Tests
{
    public class Tests
    {
        private Parser parser;

        [SetUp]
        public void SetUp()
        {
            parser = new Parser();
        }

        [Test]
        public void Parse_SimpleExpression_ShouldReturnCorrectValue()
        {
            var root = parser.Parse("(+ 3 8)");
            Assert.That(root.ValueOrExpression, Is.EqualTo(11));
        }

        [Test]
        public void Parse_ComplexExpression_ShouldReturnCorrectValue()
        {
            var root = parser.Parse("(* (+ 3 8) (/ 18 6) ) ");
            Assert.That(root.ValueOrExpression, Is.EqualTo(33));
        }

        [Test]
        public void Parse_InvalidOperator_ShouldThrowException()
        {
            var ex = Assert.Throws<InvalidDataException>(() => parser.Parse("($ 1 3"));
            Assert.That(ex.Message, Does.Contain("Invalid symbol $"));
        }

        [Test]
        public void Parse_UnclosedBracket_ShouldThrowException()
        {
            var ex = Assert.Throws<InvalidDataException>(() => parser.Parse("(/ 6 3"));
            Assert.That(ex.Message, Does.Contain("expected ')'"));
        }

        [Test]
        public void Parse_DivisionByZero_ShouldThrowException()
        {
            var root = parser.Parse("(/ 3 0)");
            var ex = Assert.Throws<DivideByZeroException>(() => root.ValueOrExpression());
            Assert.That(ex.Message, Does.Contain("division by zero"));
        }

        [Test]
        public void Parse_NegativeNumber_ShouldReturnCorrectValue()
        {
            var root = parser.Parse("-3");
            Assert.That(root.ValueOrExpression, Is.EqualTo(-3));
        }
    }
}
