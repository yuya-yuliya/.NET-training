using System.Collections.Generic;

namespace BinarySearchTreeLibrary
{
    /// <summary>
    /// Represents binary search tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T>
    {
        /// <summary>
        /// Comparer for values of tree node
        /// </summary>
        private IComparer<T> _comparer;

        /// <summary>
        /// Root node of tree
        /// </summary>
        private BinaryTreeNode<T> _root;

        /// <summary>
        /// Initialize new instance of BinarySearchTree class with current value comparer
        /// </summary>
        /// <param name="comparer">Comparer for values of tree node</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            _comparer = comparer;
            _root = null;
        }

        /// <summary>
        /// Initialize new instance of BinarySearchTree class
        /// </summary>
        public BinarySearchTree() : this(Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Adds value in binary search tree
        /// </summary>
        /// <param name="value">Value to add</param>
        public void Add(T value)
        {
            BinaryTreeNode<T> node = _root;
            if (node == null)
            {
                node = _root = new BinaryTreeNode<T>();
            }
            else
            {
                while (node != null)
                {
                    if (_comparer.Compare(node.Value, value) < 0)
                    {
                        if (node.Right == null)
                        {
                            node.Right = new BinaryTreeNode<T>();
                            node = node.Right;
                            break;
                        }
                        else
                        {
                            node = node.Right;
                        }
                    }
                    else
                    {
                        if (node.Left == null)
                        {
                            node.Left = new BinaryTreeNode<T>();
                            node = node.Left;
                            break;
                        }
                        else
                        {
                            node = node.Left;
                        }
                    }
                }
            }

            node.Value = value;
        }

        /// <summary>
        /// Pre-order traversal of binary search tree
        /// </summary>
        /// <returns>Values of visited nodes</returns>
        public IEnumerable<T> Preorder()
        {
            BinaryTreeNode<T> node;
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            if (_root != null)
            {
                stack.Push(_root);
                while (stack.Count != 0)
                {
                    node = stack.Pop();
                    yield return node.Value;
                    if (node.Right != null)
                    {
                        stack.Push(node.Right);
                    }

                    if (node.Left != null)
                    {
                        stack.Push(node.Left);
                    }
                }
            }
        }

        /// <summary>
        /// In-order traversal of binary search tree
        /// </summary>
        /// <returns>Values of visited nodes</returns>
        public IEnumerable<T> Inorder()
        {
            BinaryTreeNode<T> node = _root;
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            while (node != null || stack.Count != 0)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }

        /// <summary>
        /// Post-order traversal of binary search tree
        /// </summary>
        /// <returns>Values of visited nodes</returns>
        public IEnumerable<T> Postorder()
        {
            BinaryTreeNode<T> node = _root;
            BinaryTreeNode<T> lastNode = null;
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            while (node != null || stack.Count != 0)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    BinaryTreeNode<T> peekNode = stack.Peek();
                    if (peekNode.Right != null && lastNode != peekNode.Right)
                    {
                        node = peekNode.Right;
                    }
                    else
                    {
                        yield return peekNode.Value;
                        lastNode = stack.Pop();
                    }
                }
            }
        }
    }
}
