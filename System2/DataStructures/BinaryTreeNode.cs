using System;

namespace System2.DataStructures
{
    public class BinaryTreeNode<T>
        where T : IComparable<T>
    {
        public T CurrentNode { get; set; }
        public BinaryTreeNode<T> LeftChild { get; set; }
        public BinaryTreeNode<T> RightChild { get; set; }

        public BinaryTreeNode() { }

        public BinaryTreeNode(T currentNode)
        {
            CurrentNode = currentNode;
        }

        public BinaryTreeNode(
            T currentNode,
            BinaryTreeNode<T> leftChild,
            BinaryTreeNode<T> rightChild
        )
        {
            CurrentNode = currentNode;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }
}
