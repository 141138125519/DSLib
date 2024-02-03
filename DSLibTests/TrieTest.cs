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

        [Fact] public void InsertAndSearchTest()
        {
            Trie trie = new();
            Assert.NotNull(trie);

            trie.Insert("word");

            Assert.True(trie.Search("word"));
            Assert.False(trie.Search("work"));
            Assert.False(trie.Search("wo"));
        }
    }
}
