using System;
using csharp_coding_playground.Infrastructure;

namespace csharp_coding_playground.DataStructures
{
    public class BinarySearchTree<T>
        where T : IComparable
    {
        /// <summary>
        /// The root node of the tree.
        /// </summary>
        private BinarySearchTreeNode<T> root;

        /// <summary>
        /// The number of nodes in the tree.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Returns the height of the tree.
        /// </summary>
        /// <returns></returns>
        public int Height
        {
            get
            {
                return GetHeight(root);
            }
        }

        /// <summary>
        /// Returns the height of the tree from the given node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int GetHeight(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            int lHeight = GetHeight(node.Left);
            int rHeight = GetHeight(node.Right);

            return Math.Max(lHeight, rHeight) + 1;
        }

        /// <summary>
        /// Inserts a new node with the given value in the tree.
        /// </summary>
        /// <param name="value"></param>
        public void Insert(T value)
        {
            root = Insert(value, root);
            Length++;
        }

        /// <summary>
        /// Inserts a new node in the tree from the given node.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private BinarySearchTreeNode<T> Insert(T value, BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return new BinarySearchTreeNode<T> { Value = value };
            }

            var check = node.Value.CompareTo(value);
            if (check == 0)
            {
                throw new ValidationException("Value already exists in the tree.");
            }

            if (check > 0)
            {
                node.Left = Insert(value, node.Left);
            }
            else
            {
                node.Right = Insert(value, node.Right);
            }

            return node;
        }

        /// <summary>
        /// Searches for the given value in the tree.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Search(T value)
        {
            (_, var result) = Search(value, null, root);
            if (result == null)
            {
                return default;
            }

            return result.Value;
        }

        /// <summary>
        /// Searches for the given value in the tree from the given node.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private (BinarySearchTreeNode<T> parent, BinarySearchTreeNode<T> node) Search(T value, BinarySearchTreeNode<T> parent, BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return (parent, null);
            }

            var compare = node.Value.CompareTo(value);
            if (compare == 0)
            {
                return (parent, node);
            }
            else if (compare > 0)
            {
                return Search(value, node, node.Left);
            }
            else
            {
                return Search(value, node, node.Right);
            }
        }

        /// <summary>
        /// Removes value from the tree.
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            (var parent, var node) = Search(value, null, root);
            if (node != null)
            {
                Length--;
            }

            Remove(parent, node);
        }

        /// <summary>
        /// Returns highest value after the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Successor(T value)
        {
            (var parent, var node) = Search(value, null, root);
            if (node == null)
            {
                throw new ValidationException("Value does not exist in the tree.");
            }

            if (node.Right == null && parent != null && parent.Left == node)
            {
                return parent.Value;
            }

            (_, var successor) = Min(node, node.Right);
            if (successor == null)
            {
                return node.Value;
            }

            return successor.Value;
        }

        /// <summary>
        /// Removes node from the tree.
        /// </summary>
        /// <param name="value"></param>
        private void Remove(BinarySearchTreeNode<T> parent, BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            if (node.Left == null && node.Right == null)
            {
                if (node == root)
                {
                    root = null;
                }
                else
                {
                    if (parent.Left == node)
                    {
                        parent.Left = null;
                    }

                    if (parent.Right == node)
                    {
                        parent.Right = null;
                    }
                }

                return;
            }

            if (node.Left == null)
            {
                if (node == root)
                {
                    root = node.Right;
                }
                else
                {
                    if (parent.Left == node)
                    {
                        parent.Left = node.Right;
                    }

                    if (parent.Right == node)
                    {
                        parent.Right = node.Right;
                    }
                }

                return;
            }

            if (node.Right == null)
            {
                if (node == root)
                {
                    root = node.Left;
                }
                else
                {
                    if (parent.Left == node)
                    {
                        parent.Left = node.Left;
                    }

                    if (parent.Right == node)
                    {
                        parent.Right = node.Left;
                    }
                }

                return;
            }


            (var minParent, var min) = Min(node, node.Right);
            if (node == root)
            {
                root.Value = min.Value;
                Remove(minParent, min);
            }
            else
            {
                node.Value = min.Value;
                Remove(minParent, min);
            }
        }

        /// <summary>
        /// Returns the min value of the tree.
        /// </summary>
        /// <returns></returns>
        public T Min()
        {
            (_, var min) = Min(null, root);
            if (min == null)
            {
                return default;
            }

            return min.Value;
        }

        /// <summary>
        /// Returns the max value of the tree.
        /// </summary>
        /// <returns></returns>
        public T Max()
        {
            (_, var max) = Max(null, root);
            if (max == null)
            {
                return default;
            }

            return max.Value;
        }

        /// <summary>
        /// Returns the min node from the given node.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private (BinarySearchTreeNode<T> parent, BinarySearchTreeNode<T> node) Min(BinarySearchTreeNode<T> parent, BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return (null, null);
            }

            if (node.Left == null)
            {
                return (parent, node);
            }

            return Min(node, node.Left);
        }

        /// <summary>
        /// Returns the max node from the given node.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private (BinarySearchTreeNode<T> parent, BinarySearchTreeNode<T> node) Max(BinarySearchTreeNode<T> parent, BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return (null, null);
            }

            if (node.Right == null)
            {
                return (parent, node);
            }

            return Max(node, node.Right);
        }

        /// <summary>
        /// Performs BFS on the tree.
        /// </summary>
        /// <returns></returns>
        public ResizeableArray<T> BFS()
        {
            ResizeableArray<T> result = new ResizeableArray<T>();
            Queue<BinarySearchTreeNode<T>> queue = new Queue<BinarySearchTreeNode<T>>();
            queue.Enqueue(root);

            while (!queue.IsEmpty)
            {
                var node = queue.Dequeue();

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }

                result.Add(node.Value);
            }

            return result;
        }

        /// <summary>
        /// Performs DFS InOrder on the tree.
        /// </summary>
        /// <param name="strategy"></param>
        /// <returns></returns>
        public ResizeableArray<T> DFS()
        {
            return DFS(DFSStrategy.InOrder);
        }

        /// <summary>
        /// Performs DFS on the tree with the given strategy.
        /// </summary>
        /// <param name="strategy"></param>
        /// <returns></returns>
        public ResizeableArray<T> DFS(DFSStrategy strategy)
        {
            var array = new ResizeableArray<T>();
            switch (strategy)
            {
                case DFSStrategy.InOrder:
                    DFSInOrder(root, array);
                    break;
                case DFSStrategy.PostOrder:
                    DFSPostOrder(root, array);
                    break;
                case DFSStrategy.PreOrder:
                    DFSPreOrder(root, array);
                    break;
                default:
                    throw new ValidationException("Unknown strategy");
            }

            return array;
        }

        /// <summary>
        /// Performs DFS InOrder on the tree.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="array"></param>
        private void DFSInOrder(BinarySearchTreeNode<T> node, ResizeableArray<T> array)
        {
            if (node == null)
            {
                return;
            }

            DFSInOrder(node.Left, array);
            array.Add(node.Value);
            DFSInOrder(node.Right, array);
        }

        /// <summary>
        /// Performs DFS PreOrder on the tree.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="array"></param>
        private void DFSPreOrder(BinarySearchTreeNode<T> node, ResizeableArray<T> array)
        {
            if (node == null)
            {
                return;
            }

            array.Add(node.Value);
            DFSPreOrder(node.Left, array);
            DFSPreOrder(node.Right, array);
        }

        /// <summary>
        /// Performs DFS PostOrder on the tree.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="array"></param>
        private void DFSPostOrder(BinarySearchTreeNode<T> node, ResizeableArray<T> array)
        {
            if (node == null)
            {
                return;
            }

            DFSPostOrder(node.Left, array);
            DFSPostOrder(node.Right, array);
            array.Add(node.Value);
        }
    }
}