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

            List<string> words = new();
            words.Add("word");
            words.Add("work");
            //words.Add("worked");
            words.Sort();

            trie.Insert("word");
            trie.Insert("work");
            //trie.Insert("worked");

            Assert.True(trie.ContainsWord("word"));
            Assert.True(trie.ContainsPrefix("wo"));

            Assert.Empty(trie.PossiblePrefixWords("a"));

            Assert.NotEmpty(trie.PossiblePrefixWords("w"));

            List<string> results = trie.PossiblePrefixWords("wo");
            results.Sort();
            Assert.Equal(words, results);

            results = trie.PossiblePrefixWords("wor");
            results.Sort();
            Assert.Equal(words, results);
            //Assert.Equal(words, trie.PrefixPossibleWords("wo"));
            //Assert.Equal(words, trie.PrefixPossibleWords("wor"));

        }
    }
}
