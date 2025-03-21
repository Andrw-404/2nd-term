namespace LZWAlgorithm.Tests
{
    public class TrieTests
    {
        [Test]
        public void Initialization_Create256Nodes()
        {
            var trie = new Trie();
            Assert.That(trie.RootChildrenCount, Is.EqualTo(256));
        }
    }
}
