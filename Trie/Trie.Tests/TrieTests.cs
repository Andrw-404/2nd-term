namespace TrieTests
{
    public class Tests
    {
        private static readonly string[] TestWords = ["banana", "bank", "bar", "dog", "cat", "car"];

        private static Trie InitializationTrie()
        {
            var trie = new Trie();
            foreach (var word in TestWords)
            {
                trie.Add(word);
            }
            return trie;
        }

        [Test]
        public void Add_ShouldReturnTrueAndIncreasedSize()
        {
            Trie trie = new Trie();
            Assert.Multiple(() =>
            {
                Assert.That(trie.Size, Is.EqualTo(0));
                Assert.That(trie.Add(TestWords[0]), Is.True);
                Assert.That(trie.Size, Is.EqualTo(1));
            });
        }

        [Test]
        public void Contains_ShouldReturnTrueForAddedWords()
        {
            Trie trie = InitializationTrie();
            foreach (var word in TestWords)
            {
                Assert.That(trie.Contains(word), Is.True);
            }
        }

        [Test]
        public void Contains_ShouldReturnFalseForNonIncomingWords()
        {
            Trie trie = new Trie();
            Assert.Multiple(() =>
            {
                Assert.That(trie.Contains("carting"), Is.False);
                Assert.That(trie.Contains("barfds"), Is.False);
                Assert.That(trie.Contains("dogo"), Is.False);
            });
        }

        [Test]
        public void HowManyStartsWithPrefix_ShouldReturnCorrectCount()
        {
            Trie trie = InitializationTrie();
            Assert.Multiple(() =>
            {
                Assert.That(trie.HowManyStartsWithPrefix("ban"), Is.EqualTo(2));
                Assert.That(trie.HowManyStartsWithPrefix("ba"), Is.EqualTo(3));
                Assert.That(trie.HowManyStartsWithPrefix("c"), Is.EqualTo(2));
                Assert.That(trie.HowManyStartsWithPrefix("ca"), Is.EqualTo(2));
                Assert.That(trie.HowManyStartsWithPrefix("d"), Is.EqualTo(1));
                Assert.That(trie.HowManyStartsWithPrefix("q"), Is.EqualTo(0));
                Assert.That(trie.HowManyStartsWithPrefix("mo"), Is.EqualTo(0));
            });
        }

        [Test]
        public void Remove_ShouldDeleteWordsAndReturnTrue()
        {
            Trie trie = InitializationTrie();
            Assert.That(trie.Size, Is.EqualTo(6));
            Assert.Multiple(() =>
            {
                Assert.That(trie.Remove("banana"), Is.True);
                Assert.That(trie.Remove("cat"), Is.True);
                Assert.That(trie.Contains("car"), Is.True);
                Assert.That(trie.Remove("dog"), Is.True);
                Assert.That(trie.Size, Is.EqualTo(3));
                Assert.That(trie.Remove("bar"), Is.True);
                Assert.That(trie.Remove("bank"), Is.True);
                Assert.That(trie.Remove("car"), Is.True);
            });
        }

        [Test]
        public void Remove_ShouldReturnFalseFoNonIncomingWords()
        {
            Trie trie = InitializationTrie();
            Assert.Multiple(() =>
            {
                Assert.That(trie.Remove("ndsa"), Is.False);
                Assert.That(trie.Remove("card"), Is.False);
                Assert.That(trie.Size, Is.EqualTo(6));
            });
        }
    }
}
