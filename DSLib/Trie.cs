using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLib
{
    public class Trie
    {
        private Trie[] Children;
        private bool IsWord;

        public Trie()
        {
            Children = new Trie[26];
            IsWord = false;
        }

        public void Insert(string word)
        {
            Trie node = this;

            for (int i = 0; i < word.Length; i++)
            {
                int index = word[i] - 'a';

                if (node.Children[index] == null)
                {
                    node.Children[index] = new();
                }

                node = node.Children[index];
            }

            node.IsWord = true;
        }

        public bool Search(string word)
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
    }
}
