using System;
using csharp_coding_playground.DataStructures;
using NUnit.Framework;

namespace csharp_coding_playground.unit_tests.DataStructures
{
    public class LinkedListTests
    {
        [Test]
        public void ShouldReturnTrueOnIsEmptyWhenLenghtIs0()
        {
            var linkedList = new LinkedList<int>();

            Assert.AreEqual(0, linkedList.Length);
            Assert.True(linkedList.IsEmpty);
        }

        [Test]
        public void ShouldReturnFlaseOnIsEmptyWhenLenghtIsGreaterThan0()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);
            linkedList.PushFront(9);

            Assert.AreEqual(2, linkedList.Length);
            Assert.False(linkedList.IsEmpty);
        }

        [Test]
        public void ShouldReturnCorrectElementOnElementAtWhenLinkedListIsNotEmpty()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);
            linkedList.PushFront(0);

            Assert.AreEqual(0, linkedList.ElementAt(0));
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(2, linkedList.Length);
        }

        [Test]
        public void ShouldThrowExceptionOnElementAtWhenLinkedListIsEmpty()
        {
            var linkedList = new LinkedList<int>();

            Assert.Throws<Exception>(() => linkedList.ElementAt(10));
        }

        [Test]
        public void ShouldThrowExceptionOnElementAtWhenIndexOutOfBounds()
        {
            var linkedList = new LinkedList<int>();

            Assert.Throws<Exception>(() => linkedList.ElementAt(10));
            Assert.Throws<Exception>(() => linkedList.ElementAt(0));
            linkedList.PushFront(10);
            linkedList.PushFront(11);
            Assert.Throws<Exception>(() => linkedList.ElementAt(2));
        }

        [Test]
        public void ShouldAddElementAtStartOnPushFront()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);

            Assert.AreEqual(10, linkedList.ElementAt(0));
            Assert.AreEqual(1, linkedList.Length);

            linkedList.PushFront(20);

            Assert.AreEqual(20, linkedList.ElementAt(0));
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);
            Assert.AreEqual(2, linkedList.Length);
        }

        [Test]
        public void ShouldSetCorrectHeadAndTailOnPushFront()
        {
            var linkedList = new LinkedList<int>();

            Assert.AreEqual(0, linkedList.Length);
            Assert.AreEqual(default(int), linkedList.Head);
            Assert.AreEqual(default(int), linkedList.Tail);

            linkedList.PushFront(10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.PushFront(20);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.PushFront(30);
            Assert.AreEqual(3, linkedList.Length);
            Assert.AreEqual(30, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);
        }

        [Test]
        public void ShouldRemoveFirstElementOnPopFront()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);

            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(10, linkedList.ElementAt(0));

            linkedList.PushFront(20);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(20, linkedList.ElementAt(0));
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(20, linkedList.PopFront());
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(10, linkedList.ElementAt(0));
        }

        [Test]
        public void ShouldThrowExceptionOnPopFrontWhenListIsEmpty()
        {
            var linkedList = new LinkedList<int>();

            Assert.Throws<Exception>(() => linkedList.PopFront());
        }

        [Test]
        public void ShouldSetCorrectHeadAndTailOnPopFrontWhenOneElement()
        {
            var linkedList = new LinkedList<int>();
            Assert.AreEqual(0, linkedList.Length);
            Assert.AreEqual(default(int), linkedList.Head);
            Assert.AreEqual(default(int), linkedList.Tail);

            linkedList.PushFront(10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            Assert.AreEqual(10, linkedList.PopFront());
            Assert.AreEqual(0, linkedList.Length);
            Assert.AreEqual(default(int), linkedList.Head);
            Assert.AreEqual(default(int), linkedList.Tail);
        }

        [Test]
        public void ShouldAddElementAtStartOnPushBack()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushBack(10);

            Assert.AreEqual(10, linkedList.ElementAt(0));
            Assert.AreEqual(1, linkedList.Length);

            linkedList.PushBack(20);

            Assert.AreEqual(10, linkedList.ElementAt(0));
            Assert.AreEqual(20, linkedList.ElementAt(1));
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(20, linkedList.Tail);
            Assert.AreEqual(2, linkedList.Length);
        }

        [Test]
        public void ShouldSetCorrectHeadAndTailOnPushBack()
        {
            var linkedList = new LinkedList<int>();

            Assert.AreEqual(0, linkedList.Length);
            Assert.AreEqual(default(int), linkedList.Head);
            Assert.AreEqual(default(int), linkedList.Tail);

            linkedList.PushBack(10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.PushBack(20);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(20, linkedList.Tail);

            linkedList.PushBack(30);
            Assert.AreEqual(3, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(30, linkedList.Tail);
        }

        [Test]
        public void ShouldRemoveLastElementOnPopBack()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);

            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(10, linkedList.ElementAt(0));

            linkedList.PushFront(20);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(20, linkedList.ElementAt(0));
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(10, linkedList.PopBack());
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(20, linkedList.ElementAt(0));
        }

        [Test]
        public void ShouldThrowExceptionOnPopBackWhenListIsEmpty()
        {
            var linkedList = new LinkedList<int>();

            Assert.Throws<Exception>(() => linkedList.PopBack());
        }

        [Test]
        public void ShouldSetCorrectHeadAndTailOnPopBackWhenOneElement()
        {
            var linkedList = new LinkedList<int>();
            Assert.AreEqual(0, linkedList.Length);
            Assert.AreEqual(default(int), linkedList.Head);
            Assert.AreEqual(default(int), linkedList.Tail);

            linkedList.PushFront(10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            Assert.AreEqual(10, linkedList.PopBack());
            Assert.AreEqual(0, linkedList.Length);
            Assert.AreEqual(default(int), linkedList.Head);
            Assert.AreEqual(default(int), linkedList.Tail);
        }

        [Test]
        public void ShouldReturnFirstElementOnFront()
        {
            var linkedList = new LinkedList<int>();
            Assert.AreEqual(0, linkedList.Length);

            linkedList.PushFront(10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Front());

            linkedList.PushFront(20);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.Front());
        }

        [Test]
        public void ShouldThrowExceptionOnFrontWhenArrayIsEmpty()
        {
            var linkedList = new LinkedList<int>();

            Assert.Throws<Exception>(() => linkedList.Front());
        }

        [Test]
        public void ShouldReturnLastElementOnBack()
        {
            var linkedList = new LinkedList<int>();
            Assert.AreEqual(0, linkedList.Length);

            linkedList.PushFront(10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Back());

            linkedList.PushFront(20);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(10, linkedList.Back());
        }

        [Test]
        public void ShouldThrowExceptionOnBackWhenArrayIsEmpty()
        {
            var linkedList = new LinkedList<int>();

            Assert.Throws<Exception>(() => linkedList.Back());
        }

        [Test]
        public void ShouldThrowExceptionOnInsertWhenIndexOutOfBounds()
        {
            var linkedList = new LinkedList<int>();

            Assert.Throws<Exception>(() => linkedList.Insert(10, 20));
        }

        [Test]
        public void ShouldInsertAtTheStartOnInsertWhenLinkedListIsEmpty()
        {
            var linkedList = new LinkedList<int>();

            linkedList.Insert(0, 10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(0));
        }

        [Test]
        public void ShouldInsertAtCorrectIndexOnInsert()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(0));

            linkedList.PushFront(20);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.ElementAt(0));
            Assert.AreEqual(10, linkedList.ElementAt(1));

            linkedList.PushFront(30);
            Assert.AreEqual(3, linkedList.Length);
            Assert.AreEqual(30, linkedList.ElementAt(0));
            Assert.AreEqual(20, linkedList.ElementAt(1));
            Assert.AreEqual(10, linkedList.ElementAt(2));

            linkedList.Insert(1, 5);
            Assert.AreEqual(4, linkedList.Length);
            Assert.AreEqual(30, linkedList.ElementAt(0));
            Assert.AreEqual(5, linkedList.ElementAt(1));
            Assert.AreEqual(20, linkedList.ElementAt(2));
            Assert.AreEqual(10, linkedList.ElementAt(3));
        }

        [Test]
        public void ShouldSetCorrectHeadAndTailOnInsert()
        {
            var linkedList = new LinkedList<int>();
            Assert.AreEqual(0, linkedList.Length);
            Assert.AreEqual(default(int), linkedList.Head);
            Assert.AreEqual(default(int), linkedList.Tail);

            linkedList.Insert(0, 10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.Insert(0, 20);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.Insert(1, 30);
            Assert.AreEqual(3, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);
        }

        [Test]
        public void ShouldThrowExceptionOnRemoveAtWhenIndexOutOfBounds()
        {
            var linkedList = new LinkedList<int>();

            Assert.Throws<Exception>(() => linkedList.RemoveAt(100));
        }

        [Test]
        public void ShouldRemoveHeadOnRemoveAtWhenIndexIsZero()
        {
            var linkedList = new LinkedList<int>();
            Assert.AreEqual(0, linkedList.Length);
            Assert.AreEqual(default(int), linkedList.Head);
            Assert.AreEqual(default(int), linkedList.Tail);

            linkedList.Insert(0, 10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.Insert(0, 20);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.Insert(1, 30);
            Assert.AreEqual(3, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.RemoveAt(0);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(30, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);
        }

        [Test]
        public void ShouldRemoveTailOnRemoveAtWhenIndexIsLengthMinusOne()
        {
            var linkedList = new LinkedList<int>();
            Assert.AreEqual(0, linkedList.Length);
            Assert.AreEqual(default(int), linkedList.Head);
            Assert.AreEqual(default(int), linkedList.Tail);

            linkedList.Insert(0, 10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.Insert(0, 20);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.Insert(1, 30);
            Assert.AreEqual(3, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.RemoveAt(2);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(30, linkedList.Tail);
        }

        [Test]
        public void ShouldRemoveCorrectIndexOnRemoveAt()
        {
            var linkedList = new LinkedList<int>();
            Assert.AreEqual(0, linkedList.Length);
            Assert.AreEqual(default(int), linkedList.Head);
            Assert.AreEqual(default(int), linkedList.Tail);

            linkedList.Insert(0, 10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(0));

            linkedList.Insert(0, 20);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.ElementAt(0));
            Assert.AreEqual(10, linkedList.ElementAt(1));

            linkedList.Insert(1, 30);
            Assert.AreEqual(3, linkedList.Length);
            Assert.AreEqual(20, linkedList.ElementAt(0));
            Assert.AreEqual(30, linkedList.ElementAt(1));
            Assert.AreEqual(10, linkedList.ElementAt(2));

            linkedList.Insert(1, 40);
            Assert.AreEqual(4, linkedList.Length);
            Assert.AreEqual(20, linkedList.ElementAt(0));
            Assert.AreEqual(40, linkedList.ElementAt(1));
            Assert.AreEqual(30, linkedList.ElementAt(2));
            Assert.AreEqual(10, linkedList.ElementAt(3));

            linkedList.RemoveAt(1);
            Assert.AreEqual(3, linkedList.Length);
            Assert.AreEqual(20, linkedList.ElementAt(0));
            Assert.AreEqual(30, linkedList.ElementAt(1));
            Assert.AreEqual(10, linkedList.ElementAt(2));

            linkedList.RemoveAt(1);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.ElementAt(0));
            Assert.AreEqual(10, linkedList.ElementAt(1));
        }

        [Test]
        public void ShouldSetCorrectHeadAndTailOnRemoveAt()
        {
            var linkedList = new LinkedList<int>();
            Assert.AreEqual(0, linkedList.Length);
            Assert.AreEqual(default(int), linkedList.Head);
            Assert.AreEqual(default(int), linkedList.Tail);

            linkedList.Insert(0, 10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.Insert(0, 20);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.Insert(1, 30);
            Assert.AreEqual(3, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.RemoveAt(1);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);
        }

        [Test]
        public void ShouldRemoveCorrectIndexesOnRemoveWhenValueAtTheStart()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);
            linkedList.PushFront(20);
            linkedList.PushFront(30);

            Assert.AreEqual(3, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(2));
            Assert.AreEqual(20, linkedList.ElementAt(1));
            Assert.AreEqual(30, linkedList.ElementAt(0));

            linkedList.Remove(30);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(20, linkedList.ElementAt(0));
        }

        [Test]
        public void ShouldRemoveCorrectIndexesOnRemoveWhenValueAtTheEnd()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);
            linkedList.PushFront(20);
            linkedList.PushFront(30);

            Assert.AreEqual(3, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(2));
            Assert.AreEqual(20, linkedList.ElementAt(1));
            Assert.AreEqual(30, linkedList.ElementAt(0));

            linkedList.Remove(10);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.ElementAt(1));
            Assert.AreEqual(30, linkedList.ElementAt(0));
        }

        [Test]
        public void ShouldRemoveCorrectIndexesOnRemoveMultipleValues()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);
            linkedList.PushFront(20);
            linkedList.PushFront(10);
            linkedList.PushFront(30);
            linkedList.PushFront(10);

            Assert.AreEqual(5, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(4));
            Assert.AreEqual(20, linkedList.ElementAt(3));
            Assert.AreEqual(10, linkedList.ElementAt(2));
            Assert.AreEqual(30, linkedList.ElementAt(1));
            Assert.AreEqual(10, linkedList.ElementAt(0));

            linkedList.Remove(10);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.ElementAt(1));
            Assert.AreEqual(30, linkedList.ElementAt(0));
        }

        [Test]
        public void ShouldSetCorrectHeadAndTailOnRemoveMultipleValues()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);
            linkedList.PushFront(20);
            linkedList.PushFront(10);
            linkedList.PushFront(30);
            linkedList.PushFront(10);

            Assert.AreEqual(5, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(4));
            Assert.AreEqual(20, linkedList.ElementAt(3));
            Assert.AreEqual(10, linkedList.ElementAt(2));
            Assert.AreEqual(30, linkedList.ElementAt(1));
            Assert.AreEqual(10, linkedList.ElementAt(0));
            Assert.AreEqual(10, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.Remove(10);
            Assert.AreEqual(2, linkedList.Length);
            Assert.AreEqual(20, linkedList.ElementAt(1));
            Assert.AreEqual(30, linkedList.ElementAt(0));
            Assert.AreEqual(30, linkedList.Head);
            Assert.AreEqual(20, linkedList.Tail);
        }

        [Test]
        public void ShouldThrowExceptionOnNthValueFromEndWhenIndexOutOfBounds()
        {
            var linkedList = new LinkedList<int>();

            Assert.Throws<Exception>(() => linkedList.NthValueFromEnd(10));
        }

        [Test]
        public void ShouldReturnTailOnNthValueFromEndWhenNIsZero()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);
            linkedList.PushFront(20);
            linkedList.PushFront(10);
            linkedList.PushFront(30);

            Assert.AreEqual(4, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(3));
            Assert.AreEqual(20, linkedList.ElementAt(2));
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(30, linkedList.ElementAt(0));
            Assert.AreEqual(30, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            Assert.AreEqual(10, linkedList.NthValueFromEnd(0));
        }

        [Test]
        public void ShouldReturnHeadOnNthValueFromEndWhenNIsLengthMinusOne()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);
            linkedList.PushFront(20);
            linkedList.PushFront(10);
            linkedList.PushFront(30);

            Assert.AreEqual(4, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(3));
            Assert.AreEqual(20, linkedList.ElementAt(2));
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(30, linkedList.ElementAt(0));
            Assert.AreEqual(30, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            Assert.AreEqual(30, linkedList.NthValueFromEnd(3));
        }

        [Test]
        public void ShouldReturnCorrectIndexOnNthValueFromEnd()
        {
            var linkedList = new LinkedList<int>();

            linkedList.PushFront(10);
            linkedList.PushFront(20);
            linkedList.PushFront(10);
            linkedList.PushFront(30);

            Assert.AreEqual(4, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(3));
            Assert.AreEqual(20, linkedList.ElementAt(2));
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(30, linkedList.ElementAt(0));
            Assert.AreEqual(30, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            Assert.AreEqual(10, linkedList.NthValueFromEnd(0));
            Assert.AreEqual(20, linkedList.NthValueFromEnd(1));
            Assert.AreEqual(10, linkedList.NthValueFromEnd(2));
            Assert.AreEqual(30, linkedList.NthValueFromEnd(3));
        }

        [Test]
        public void ShouldReverseLinkedListOnReverse()
        {
            var linkedList = new LinkedList<int>();
            linkedList.PushFront(10);
            linkedList.PushFront(20);
            linkedList.PushFront(10);
            linkedList.PushFront(30);

            Assert.AreEqual(4, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(3));
            Assert.AreEqual(20, linkedList.ElementAt(2));
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(30, linkedList.ElementAt(0));
            Assert.AreEqual(30, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.Reverse();
            Assert.AreEqual(4, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(0));
            Assert.AreEqual(20, linkedList.ElementAt(1));
            Assert.AreEqual(10, linkedList.ElementAt(2));
            Assert.AreEqual(30, linkedList.ElementAt(3));
            Assert.AreEqual(30, linkedList.Tail);
            Assert.AreEqual(10, linkedList.Head);
        }

        [Test]
        public void ShouldThrowExceptionOnSetWhenIndexOutofBounds()
        {
            var linkedList = new LinkedList<int>();
            Assert.Throws<Exception>(() => linkedList.Set(0, 10));

            linkedList.PushFront(10);
            Assert.AreEqual(1, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(0));

            Assert.Throws<Exception>(() => linkedList.Set(1, 10));
            Assert.Throws<Exception>(() => linkedList.Set(3, 20));
            Assert.Throws<Exception>(() => linkedList.Set(-1, 20));
        }

        [Test]
        public void ShouldUpdateElementAtCorrectIndexOnSet()
        {
            var linkedList = new LinkedList<int>();
            linkedList.PushFront(10);
            linkedList.PushFront(20);
            linkedList.PushFront(10);
            linkedList.PushFront(30);

            Assert.AreEqual(4, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(3));
            Assert.AreEqual(20, linkedList.ElementAt(2));
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(30, linkedList.ElementAt(0));
            Assert.AreEqual(30, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.Set(0, 130);
            Assert.AreEqual(4, linkedList.Length);
            Assert.AreEqual(10, linkedList.ElementAt(3));
            Assert.AreEqual(20, linkedList.ElementAt(2));
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(130, linkedList.ElementAt(0));
            Assert.AreEqual(130, linkedList.Head);
            Assert.AreEqual(10, linkedList.Tail);

            linkedList.Set(3, 110);
            Assert.AreEqual(4, linkedList.Length);
            Assert.AreEqual(110, linkedList.ElementAt(3));
            Assert.AreEqual(20, linkedList.ElementAt(2));
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(130, linkedList.ElementAt(0));
            Assert.AreEqual(130, linkedList.Head);
            Assert.AreEqual(110, linkedList.Tail);

            linkedList.Set(2, 120);
            Assert.AreEqual(4, linkedList.Length);
            Assert.AreEqual(110, linkedList.ElementAt(3));
            Assert.AreEqual(120, linkedList.ElementAt(2));
            Assert.AreEqual(10, linkedList.ElementAt(1));
            Assert.AreEqual(130, linkedList.ElementAt(0));
            Assert.AreEqual(130, linkedList.Head);
            Assert.AreEqual(110, linkedList.Tail);

            linkedList.Set(1, 140);
            Assert.AreEqual(4, linkedList.Length);
            Assert.AreEqual(110, linkedList.ElementAt(3));
            Assert.AreEqual(120, linkedList.ElementAt(2));
            Assert.AreEqual(140, linkedList.ElementAt(1));
            Assert.AreEqual(130, linkedList.ElementAt(0));
            Assert.AreEqual(130, linkedList.Head);
            Assert.AreEqual(110, linkedList.Tail);
        }
    }
}
