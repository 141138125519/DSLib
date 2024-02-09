using DSLib;

namespace DSLibTests
{
    public class BTreeTest
    {
        BTree tree;

        int[] nums;

        public BTreeTest()
        {
            tree = new(3);
            nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        [Fact]
        public void CreateBTreeTest()
        {
            Assert.NotNull(tree);
        }

        [Fact]
        public void InsertAndSearchBTreeTest()
        {
            Assert.NotNull(tree);

            foreach (var num in nums)
            {
                tree.Insert(num);
            }

            Assert.NotNull(tree.SearchForKey(5));
            Assert.NotNull(tree.SearchForKey(10));
            Assert.Null(tree.SearchForKey(15));

        }
    }
}
