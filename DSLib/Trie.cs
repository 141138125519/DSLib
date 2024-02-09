namespace DSLib
{
    public class Trie
    {
        private Trie[] Children;
        private bool IsWord;
        private char Value;

        public Trie()
        {
            Children = new Trie[26];
            IsWord = false;
        }

        public Trie(char value)
        {
            Children = new Trie[26];
            IsWord = false;
            Value = value;
        }

        public void Insert(string word)
        {
            Trie node = this;

            for (int i = 0; i < word.Length; i++)
            {
                int index = word[i] - 'a';

                if (node.Children[index] == null)
                {
                    node.Children[index] = new(word[i]);
                }

                node = node.Children[index];
            }

            node.IsWord = true;
        }

        public bool ContainsWord(string word)
        {
            Trie node = this;

            foreach (char c in word)
            {
                int index = c - 'a';

                if (node.Children[index] == null)
                {
                    return false;
                }

                node = node.Children[index];
            }

            return node.IsWord;
        }

        public bool ContainsPrefix(string prefix)
        {
            Trie node = this;

            foreach (char c in prefix)
            {
                int index = c - 'a';

                if (node.Children[index] == null)
                {
                    return false;
                }

                node = node.Children[index];
            }

            return true;
        }

        public List<string> PossiblePrefixWords(string prefix)
        {
            Trie node = this;
            List<string> possibleWords = new();

            // Follow prefix
            foreach (char c in prefix)
            {
                int index = c - 'a';

                if (node.Children[index] == null)
                {
                    return possibleWords;
                }

                node = node.Children[index];
            }

            possibleWords = SearchForWords(node, prefix[..^1].ToList(), possibleWords);

            return possibleWords;
        }

        private List<string> SearchForWords(Trie trie, List<char> chars, List<string> words)
        {
            chars.Add(trie.Value);

            if (trie.IsWord)
            {
                words.Add(new string(chars.ToArray()));
            }

            foreach (var child in trie.Children)
            {
                if (child != null)
                {
                    SearchForWords(child, chars, words);
                }
            }

            chars.RemoveAt(chars.Count - 1);

            return words;
        }

        public void Delete(string word)
        {
            Trie trie = this;
            Remove(trie, word, 0);
        }

        private static Trie Remove(Trie node, string word, int depth)
        {
            if (node == null)
                return node;

            if (depth == word.Length)
            {
                if (node.IsWord)
                {
                    node.IsWord = false;
                }

                if (IsEmpty(node))
                {
                    node = null;
                }

                return node;
            }

            int index = word[depth] - 'a';
            node.Children[index] = Remove(node.Children[index], word, depth + 1);

            if (IsEmpty(node) && !node.IsWord)
            {
                node = null;
            }

            return node;
        }

        private static bool IsEmpty(Trie trie)
        {
            foreach (var child in trie.Children)
            {
                if (child != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
