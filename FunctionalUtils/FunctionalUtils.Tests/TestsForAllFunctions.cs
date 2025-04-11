namespace FunctionalUtils.Tests
{
    public class Tests
    {
        private List<int> testNumbers;

        [SetUp]
        public void Setup()
        {
            testNumbers = new List<int> { 1, 2, 3, 4, 5 };
        }

        [Test]
        public void Map_CorrectInput_ShouldReturnCorrectList()
        {
            List<int> expectedList = new List<int> { 10, 20, 30, 40, 50 };
            var result = HaveMap.Map(testNumbers, x => x * 10);

            Assert.That(result, Is.EqualTo(expectedList));
        }

        [Test]
        public void Filter_CorrectInput_ShouldReturnCorrectList()
        {
            List<int> expectedList = new List<int> { 2, 4 };
            var result = HaveFilter.Filter(testNumbers, x => x % 2 == 0);

            Assert.That(result, Is.EqualTo(expectedList));
        }

        [Test]
        public void Fold_CorrectInput_ShouldReturnCorrectNumber()
        { 
            var result = HaveFold.Fold(testNumbers, 1, (acc, el) => acc + el);

            Assert.That(result, Is.EqualTo(16));
        }
    }
}
