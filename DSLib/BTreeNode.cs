namespace DSLib
{
    public class BTreeNode
    {
        internal bool Leaf;
        internal int[] Keys;
        internal BTreeNode[] Children;
        internal int MinDegree;
        internal int KeyCount;

        public BTreeNode(int minDegree, bool leaf)
        {
            MinDegree = minDegree;
            Leaf = leaf;
            Keys = new int[2 * minDegree - 1];
            Children = new BTreeNode[2 * minDegree];
            KeyCount = 0;
        }

        public void Traverse()
        {
            int i;
            for (i = 0; i < KeyCount; i++)
            {
                if (!Leaf)
                {
                    Children[i].Traverse();
                }
                Console.Write(Keys[i] + " ");
            }

            if (!Leaf)
            {
                Children[i].Traverse();
            }
        }

        public BTreeNode? Search(int key)
        {
            int i = 0;
            while (i < KeyCount && key > Keys[i])
            {
                i++;
            }

            if (Keys[i] == key)
            {
                return this;
            }

            if (Leaf)
            {
                return null;
            }

            return Children[i].Search(key);
        }

        public void InsertNonFull(int key)
        {
            int i = KeyCount - 1;

            if (Leaf)
            {
                while (i >= 0 && Keys[i] > key)
                {
                    Keys[i + i] = Keys[i];
                    i--;
                }
                Keys[i + 1] = key;
                KeyCount++;
            }
            else
            {
                while (i >= 0 && Keys[i] > key)
                {
                    i--;
                }
                if (Children[i + 1].KeyCount == 2 * MinDegree - 1)
                {
                    SplitChild(i + 1, Children[i + 1]);
                    if (Keys[i + 1] < key)
                    {
                        i++;
                    }
                }
                Children[i + 1].InsertNonFull(key);
            }
        }

        public void SplitChild(int index, BTreeNode node)
        {
            var newNode = new BTreeNode(node.MinDegree, node.Leaf);
            newNode.KeyCount = MinDegree - 1;

            for (int j = 0; j < MinDegree - 1; j++)
            {
                newNode.Keys[j] = node.Keys[j + MinDegree];
            }

            if (!node.Leaf)
            {
                for (int j = 0; j < MinDegree; j++)
                {
                    newNode.Children[j] = node.Children[j + MinDegree];
                }
            }
            node.KeyCount = MinDegree - 1;

            for (int j = KeyCount; j > index; j--)
            {
                Children[j + 1] = node.Children[j + MinDegree];
            }
            Children[index + 1] = newNode;

            for (int j = KeyCount - 1; j > index - 1; j--)
            {
                Keys[j + 1] = Keys[j];
            }
            Keys[index] = node.Keys[MinDegree - 1];
            KeyCount++;
        }
    }
}
