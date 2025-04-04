namespace LZWAlgorithm.Tests
{
    public class TrieTests
    {
        [Test]
        public void Initialization_ShouldCreate256Nodes()
        {
            var trie = new Trie();
            Assert.That(trie.RootChildrenCount, Is.EqualTo(256));
        }

        [Test]
        public void TryMoveNextOrAdd_ShouldReturnTrueAndUpdateCurrent()
        {
            var trie = new Trie();
            byte existingByte = 65;

            bool result = trie.TryMoveNextOrAdd(existingByte, out int code);

            Assert.Multiple(() =>
            { 
                Assert.That(result, Is.True);
                Assert.That(code, Is.EqualTo(-1));
                Assert.That(trie.CurrentCode, Is.EqualTo(existingByte));
            });
        }

        [Test]
        public void TryMoveNextOrAdd_ShouldReturnFalseAndAddNewCode()
        {
            var trie = new Trie();
            trie.TryMoveNextOrAdd(65, out _);
            byte newByte = 66;

            bool result = trie.TryMoveNextOrAdd(newByte, out int code);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.False);
                Assert.That(code, Is.EqualTo(65));
                Assert.That(trie.CurrentCode, Is.EqualTo(newByte));
            });
        }
    }
}
