namespace DSLib
{
    public class BTree
    {
        private BTreeNode? Root;
        private int MinDegree;

        public BTree(int minDegree)
        {
            Root = null;
            MinDegree = minDegree;
        }

        public void PrintTree()
        {
            Root?.Traverse();
            Console.WriteLine();
        }

        public BTreeNode? SearchForKey(int key)
        {
            return Root?.Search(key);
        }

        public void Insert(int key)
        {
            if (Root == null)
            {
                Root = new(MinDegree, true);
                Root.Keys[0] = key;
                Root.KeyCount = 1;
            }
            else
            {
                if (Root.KeyCount == 2 * MinDegree - 1)
                {
                    var node = new BTreeNode(MinDegree, false);
                    node.Children[0] = Root;
                    node.SplitChild(0, Root);
                    int i = 0;
                    if (node.Keys[0] < key)
                    {
                        i++;
                    }
                    node.Children[i].InsertNonFull(key);
                    Root = node;
                }
                else
                {
                    Root.InsertNonFull(key);
                }
            }
        }
    }
}
