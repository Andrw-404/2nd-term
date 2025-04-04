namespace ParsingTree.Tests
{
    public class Tests
    {
        [Test]
        public void Splitting_ValidExpression_ShouldReturnCorrectTokens()
        {
            var parser = new Parser();
            var result = parser.Splitting("(* (+ 1 1) 2)");
            string[] expected = { "(", "*", "(", "+", "1", "1", ")", "2", ")" };
            Assert.That(result, Is.EquivalentTo(expected));
        }
    }
}
