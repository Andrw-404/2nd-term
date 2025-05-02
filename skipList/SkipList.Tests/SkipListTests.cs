using SkipList;

namespace SkipList.Tests
{
    public class SkipListTests
    {
        [Test]
        public void Count_SequentialAddition_ShouldReturnCorrectQuantity()
        {
            var testSkipList = new SkipList<int>();
            testSkipList.Add(10);
            Assert.That(testSkipList.Count, Is.EqualTo(1));
            testSkipList.Add(20);
            Assert.That(testSkipList.Count, Is.EqualTo(2));
        }
    }
}
