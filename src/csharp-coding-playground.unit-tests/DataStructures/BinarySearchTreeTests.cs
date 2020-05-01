using System;
using csharp_coding_playground.DataStructures;
using csharp_coding_playground.Infrastructure;
using NUnit.Framework;

namespace csharp_coding_playground.unit_tests.DataStructures
{
    public class BinarySearchTreeTests
    {
        [Test]
        public void ShouldAddElementAtCorrectPositionOnInsert()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            var array = bst.DFS(DFSStrategy.InOrder);

            Assert.AreEqual(0, array.ElementAt(0));
            Assert.AreEqual(1, array.ElementAt(1));
            Assert.AreEqual(2, array.ElementAt(2));
            Assert.AreEqual(3, array.ElementAt(3));
            Assert.AreEqual(4, array.ElementAt(4));
            Assert.AreEqual(5, array.ElementAt(5));
            Assert.AreEqual(6, array.ElementAt(6));
            Assert.AreEqual(7, array.ElementAt(7));
            Assert.AreEqual(8, array.ElementAt(8));
            Assert.AreEqual(9, array.ElementAt(9));
            Assert.AreEqual(10, array.ElementAt(10));
            Assert.AreEqual(11, array.ElementAt(11));
            Assert.AreEqual(12, array.ElementAt(12));
        }

        [Test]
        public void ShouldReturnCorrectResultOnBFS()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            var array = bst.BFS();

            Assert.AreEqual(7, array.ElementAt(0));
            Assert.AreEqual(4, array.ElementAt(1));
            Assert.AreEqual(9, array.ElementAt(2));
            Assert.AreEqual(3, array.ElementAt(3));
            Assert.AreEqual(5, array.ElementAt(4));
            Assert.AreEqual(8, array.ElementAt(5));
            Assert.AreEqual(11, array.ElementAt(6));
            Assert.AreEqual(2, array.ElementAt(7));
            Assert.AreEqual(6, array.ElementAt(8));
            Assert.AreEqual(10, array.ElementAt(9));
            Assert.AreEqual(12, array.ElementAt(10));
            Assert.AreEqual(1, array.ElementAt(11));
            Assert.AreEqual(0, array.ElementAt(12));
        }

        [Test]
        public void ShouldReturnCorrectResultOnDFSWhenStrategyInOrder()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            var array = bst.DFS(DFSStrategy.InOrder);

            Assert.AreEqual(0, array.ElementAt(0));
            Assert.AreEqual(1, array.ElementAt(1));
            Assert.AreEqual(2, array.ElementAt(2));
            Assert.AreEqual(3, array.ElementAt(3));
            Assert.AreEqual(4, array.ElementAt(4));
            Assert.AreEqual(5, array.ElementAt(5));
            Assert.AreEqual(6, array.ElementAt(6));
            Assert.AreEqual(7, array.ElementAt(7));
            Assert.AreEqual(8, array.ElementAt(8));
            Assert.AreEqual(9, array.ElementAt(9));
            Assert.AreEqual(10, array.ElementAt(10));
            Assert.AreEqual(11, array.ElementAt(11));
            Assert.AreEqual(12, array.ElementAt(12));
        }

        [Test]
        public void ShouldReturnCorrectResultOnDFSWhenStrategyPreOrder()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            var array = bst.DFS(DFSStrategy.PreOrder);

            Assert.AreEqual(7, array.ElementAt(0));
            Assert.AreEqual(4, array.ElementAt(1));
            Assert.AreEqual(3, array.ElementAt(2));
            Assert.AreEqual(2, array.ElementAt(3));
            Assert.AreEqual(1, array.ElementAt(4));
            Assert.AreEqual(0, array.ElementAt(5));
            Assert.AreEqual(5, array.ElementAt(6));
            Assert.AreEqual(6, array.ElementAt(7));
            Assert.AreEqual(9, array.ElementAt(8));
            Assert.AreEqual(8, array.ElementAt(9));
            Assert.AreEqual(11, array.ElementAt(10));
            Assert.AreEqual(10, array.ElementAt(11));
            Assert.AreEqual(12, array.ElementAt(12));
        }

        [Test]
        public void ShouldReturnCorrectResultOnDFSWhenStrategyPostOrder()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(0);

            var array = bst.DFS(DFSStrategy.PostOrder);

            Assert.AreEqual(0, array.ElementAt(0));
            Assert.AreEqual(1, array.ElementAt(1));
            Assert.AreEqual(2, array.ElementAt(2));
            Assert.AreEqual(3, array.ElementAt(3));
            Assert.AreEqual(6, array.ElementAt(4));
            Assert.AreEqual(5, array.ElementAt(5));
            Assert.AreEqual(4, array.ElementAt(6));
            Assert.AreEqual(8, array.ElementAt(7));
            Assert.AreEqual(10, array.ElementAt(8));
            Assert.AreEqual(12, array.ElementAt(9));
            Assert.AreEqual(11, array.ElementAt(10));
            Assert.AreEqual(9, array.ElementAt(11));
            Assert.AreEqual(7, array.ElementAt(12));
        }
    }
}