using DSLib;

namespace DSLibTests
{
    public class TrieTest
    {

        [Fact]
        public void CreateTrieTest()
        {
            Trie trie = new();

            Assert.NotNull(trie);
        }

        [Fact]
        public void InsertAndSearchTest()
        {
            Trie trie = new();
            Assert.NotNull(trie);

            trie.Insert("word");

            Assert.True(trie.ContainsWord("word"));
            Assert.False(trie.ContainsWord("work"));
            Assert.False(trie.ContainsWord("wo"));
        }

        [Fact]
        public void PrefixSearchTest()
        {
            Trie trie = new();
            Assert.NotNull(trie);

            trie.Insert("word");

            Assert.True(trie.ContainsWord("word"));
            Assert.True(trie.ContainsPrefix("wor"));

            Assert.False(trie.ContainsPrefix("o"));
        }

        [Fact]
        public void PrefixPossibleWordsTest()
        {
            Trie trie = new();
            Assert.NotNull(trie);

            List<string> words = new() { "word", "work", "worked" }; ;

            foreach (string word in words)
            {
                trie.Insert(word);
            }

            Assert.True(trie.ContainsWord("word"));
            Assert.True(trie.ContainsPrefix("wo"));

            Assert.Empty(trie.PossiblePrefixWords("a"));

            Assert.NotEmpty(trie.PossiblePrefixWords("w"));

            List<string> results = trie.PossiblePrefixWords("wo");
            Assert.Equal(words, results);

            results = trie.PossiblePrefixWords("wor");
            Assert.Equal(words, results);
        }

        [Fact]
        public void DeleteWordTest()
        {
            Trie trie = new();
            Assert.NotNull(trie);

            List<string> words = new() { "word", "work" };
            
            foreach (string word in words)
            {
                trie.Insert(word);
            }

            Assert.True(trie.ContainsWord("word"));
            Assert.True(trie.ContainsWord("work"));

            var results = trie.PossiblePrefixWords("w");
            Assert.Equal(words, results);

            trie.Delete("work");
            results = trie.PossiblePrefixWords("w");
            Assert.NotEqual(words, results);

            words.Remove("work");
            Assert.Equal(words, results);
        }
    }
}
