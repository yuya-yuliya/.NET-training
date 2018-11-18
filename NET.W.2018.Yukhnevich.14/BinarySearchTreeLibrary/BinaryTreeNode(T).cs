namespace BinarySearchTreeLibrary
{
    /// <summary>
    /// Represents binary search tree node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class BinaryTreeNode<T>
    {
        /// <summary>
        /// The value of the binary tree node
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The right child of current node
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        /// <summary>
        /// The left child of current node
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }
    }
}
