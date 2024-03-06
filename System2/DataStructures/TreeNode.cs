namespace System2.DataStructures
{
    public class TreeNode<T>
    {
        public T CurrentNode { get; set; }
        public TreeNode<T>[] ChildNodes { get; set; }

        public TreeNode() { }

        public TreeNode(T currentNode)
        {
            CurrentNode = currentNode;
        }

        public TreeNode(T currentNode, TreeNode<T>[] childNodes)
        {
            CurrentNode = currentNode;
            ChildNodes = childNodes;
        }
    }
}
