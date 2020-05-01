﻿using System;
using csharp_coding_playground.Infrastructure;

namespace csharp_coding_playground.DataStructures
{
    public class BinarySearchTree<T>
        where T: IComparable
    {
        /// <summary>
        /// The root node of the tree.
        /// </summary>
        private BinarySearchTreeNode<T> root = null;

        /// <summary>
        /// Inserts a new node in the tree.
        /// </summary>
        /// <param name="value"></param>
        public void Insert(T value) => root = Insert(value, root);

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
                return new BinarySearchTreeNode<T>() { Value = value };
            }

            var check = node.Value.CompareTo(value);
            if (check >= 0) node.Left = Insert(value, node.Left);
            else node.Right = Insert(value, node.Right);

            return node;
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

            while(!queue.IsEmpty)
            {
                var node = queue.Dequeue();
                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
                result.Add(node.Value);
            }

            return result;
        }

        /// <summary>
        /// Performs DFS on the tree with the given strategy.
        /// </summary>
        /// <param name="strategy"></param>
        /// <returns></returns>
        public ResizeableArray<T> DFS(DFSStrategy strategy = DFSStrategy.InOrder)
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
                    throw new Exception("Unknown strategy");
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
            if (node == null) return;

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
            if (node == null) return;

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
            if (node == null) return;

            DFSPostOrder(node.Left, array);
            DFSPostOrder(node.Right, array);
            array.Add(node.Value);
        }
    }
}     
