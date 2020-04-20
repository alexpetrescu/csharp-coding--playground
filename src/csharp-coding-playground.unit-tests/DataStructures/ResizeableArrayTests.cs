using System;
using csharp_coding_playground.DataStructures;
using NUnit.Framework;

namespace csharp_coding_playground.unit_tests.DataStructures
{
    public class ResizeableArrayTests
    {
        [Test]
        public void ShouldReturnTrueOnIsEmptyWhenLenghtIs0()
        {
            var array = new ResizeableArray<int>();

            Assert.AreEqual(0, array.Length);
            Assert.True(array.IsEmpty);
        }

        [Test]
        public void ShouldReturnFlaseOnIsEmptyWhenLenghtIsGreaterThan0()
        {
            var array = new ResizeableArray<int>();

            array.Add(10);
            array.Add(9);

            Assert.AreEqual(2, array.Length);
            Assert.False(array.IsEmpty);
        }

        [Test]
        public void ShouldReturnCorrectElementOnElementAtWhenArrayIsNotEmpty()
        {
            var array = new ResizeableArray<int>();

            array.Add(10);
            array.Add(0);

            Assert.AreEqual(10, array.ElementAt(0));
            Assert.AreEqual(0, array.ElementAt(1));
            Assert.AreEqual(2, array.Length);
        }

        [Test]
        public void ShouldThrowExceptionOnElementAtWhenArrayIsEmpty()
        {
            var array = new ResizeableArray<int>();

            Assert.Throws<Exception>(() => array.ElementAt(10));
        }

        [Test]
        public void ShouldThrowExceptionOnElementAtWhenIndexOutOfBounds()
        {
            var array = new ResizeableArray<int>();

            Assert.Throws<Exception>(() => array.ElementAt(10));
            Assert.Throws<Exception>(() => array.ElementAt(0));
            array.Add(10);
            array.Add(11);
            Assert.Throws<Exception>(() => array.ElementAt(2));
        }

        [Test]
        public void ShouldAddElementAtTheEndOfArrayOnAdd()
        {
            var array = new ResizeableArray<int>();

            array.Add(12);
            array.Add(16);
            array.Add(122);

            Assert.False(array.IsEmpty);
            Assert.AreEqual(3, array.Length);
            Assert.AreEqual(12, array.ElementAt(0));
            Assert.AreEqual(16, array.ElementAt(1));
            Assert.AreEqual(122, array.ElementAt(2));
        }

        [Test]
        public void ShouldIncreseCapacityOnAddWhenMaxCapacityIsReached()
        {
            var array = new ResizeableArray<int>();

            Assert.AreEqual(16, array.Capacity);

            for (int i = 0; i < 20; i++)
            {
                array.Add(i);
            }

            for (int i = 0; i < 20; i++)
            {
                Assert.AreEqual(i, array.ElementAt(i));
            }
            Assert.AreEqual(32, array.Capacity);
        }

        [Test]
        public void ShouldAddElementAtCorrectIndexOnInsert()
        {
            var array = new ResizeableArray<int>();

            array.Add(10);
            array.Add(15);
            array.Add(20);
            array.Insert(25, 1);

            Assert.AreEqual(10, array.ElementAt(0));
            Assert.AreEqual(25, array.ElementAt(1));
            Assert.AreEqual(15, array.ElementAt(2));
            Assert.AreEqual(20, array.ElementAt(3));
        }

        [Test]
        public void ShouldThrowExceptionOnInsertWhenIndexOutOfBounds()
        {
            var array = new ResizeableArray<int>();

            Assert.Throws<Exception>(() => array.Insert(1, 1));
        }

        [Test]
        public void ShouldNotThrowExceptionOnInsertWhenIndexIsZero()
        {
            var array = new ResizeableArray<int>();

            array.Insert(1, 0);

            Assert.AreEqual(1, array.Length);
            Assert.AreEqual(1, array.ElementAt(0));
        }

        [Test]
        public void ShouldNotThrowExceptionOnPrependWhenArrayIsEmpty()
        {
            var array = new ResizeableArray<int>();

            array.Prepend(1);

            Assert.AreEqual(1, array.Length);
            Assert.AreEqual(1, array.ElementAt(0));
        }

        [Test]
        public void ShouldIncreseCapacityOnInsertWhenMaxCapacityIsReached()
        {
            var array = new ResizeableArray<int>();

            Assert.AreEqual(16, array.Capacity);

            for (int i = 0; i < 15; i++)
            {
                array.Add(i);
            }

            Assert.AreEqual(16, array.Capacity);
            array.Insert(200, 4);
            Assert.AreEqual(32, array.Capacity);

            for (int i = 0; i < 16; i++)
            {
                if (i < 4) Assert.AreEqual(i, array.ElementAt(i));
                if (i == 4) Assert.AreEqual(200, array.ElementAt(i));
                if (i > 4) Assert.AreEqual(i - 1, array.ElementAt(i));
            }
        }

        [Test]
        public void ShouldAddElementAtStartOfArrayOnPreprend()
        {
            var array = new ResizeableArray<int>();

            array.Add(10);
            array.Add(15);
            array.Add(20);
            array.Prepend(25);

            Assert.AreEqual(25, array.ElementAt(0));
            Assert.AreEqual(10, array.ElementAt(1));
            Assert.AreEqual(15, array.ElementAt(2));
            Assert.AreEqual(20, array.ElementAt(3));
        }

        [Test]
        public void ShouldIncreseCapacityOnPrependWhenMaxCapacityIsReached()
        {
            var array = new ResizeableArray<int>();

            Assert.AreEqual(16, array.Capacity);

            for (int i = 0; i < 15; i++)
            {
                array.Add(i);
            }

            Assert.AreEqual(16, array.Capacity);
            array.Prepend(200);
            Assert.AreEqual(32, array.Capacity);

            Assert.AreEqual(200, array.ElementAt(0));
            for (int i = 1; i < 16; i++)
            {
                Assert.AreEqual(i-1, array.ElementAt(i));
            }
        }

        [Test]
        public void ShouldRemoveElementAtCorrectIndexOnRemoveAt()
        {
            var array = new ResizeableArray<int>();

            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.AreEqual(3, array.Length);

            array.RemoveAt(1);
            Assert.AreEqual(2, array.Length);
            Assert.AreEqual(1, array.ElementAt(0));
            Assert.AreEqual(3, array.ElementAt(1));
        }

        [Test]
        public void ShouldDecreaseCapacityOnRemoveAt()
        {
            var array = new ResizeableArray<int>();

            Assert.AreEqual(16, array.Capacity);

            for (int i = 0; i < 16; i++)
            {
                array.Add(i);
            }

            Assert.AreEqual(32, array.Capacity);
            Assert.AreEqual(16, array.Length);

            for (int i = 0; i < 8; i++)
            {
                array.RemoveAt(0);
            }

            Assert.AreEqual(16, array.Capacity);
            Assert.AreEqual(8, array.Length);

            for(int i = 0; i < 6; i++)
            {
                array.RemoveAt(0);
            }

            Assert.AreEqual(2, array.Length);
            Assert.AreEqual(16, array.Capacity);
        }

        [Test]
        public void ShouldThorwExceptionOnPopWhenIndexOutOfBounds()
        {
            var array = new ResizeableArray<int>();

            Assert.AreEqual(0, array.Length);
            Assert.Throws<Exception>(() => array.RemoveAt(1));
        }

        [Test]
        public void ShouldRemoveAllOccurencesOnRemove()
        {
            var array = new ResizeableArray<int>();

            array.Add(12);
            array.Add(1);
            array.Add(2);
            array.Add(13);
            array.Add(1);

            Assert.AreEqual(5, array.Length);
            Assert.AreEqual(12, array.ElementAt(0));
            Assert.AreEqual(1, array.ElementAt(1));
            Assert.AreEqual(2, array.ElementAt(2));
            Assert.AreEqual(13, array.ElementAt(3));
            Assert.AreEqual(1, array.ElementAt(4));

            array.Remove(1);

            Assert.AreEqual(3, array.Length);
            Assert.AreEqual(12, array.ElementAt(0));
            Assert.AreEqual(2, array.ElementAt(1));
            Assert.AreEqual(13, array.ElementAt(2));
        }

        [Test]
        public void ShouldDecreaseCapacityOnRemove()
        {
            var array = new ResizeableArray<int>();

            Assert.AreEqual(16, array.Capacity);

            for (int i = 0; i < 16; i++)
            {
                array.Add(i);
            }

            Assert.AreEqual(32, array.Capacity);
            Assert.AreEqual(16, array.Length);

            for (int i = 0; i < 8; i++)
            {
                var elem = array.ElementAt(0);
                array.Remove(elem);
            }

            Assert.AreEqual(16, array.Capacity);
            Assert.AreEqual(8, array.Length);

            for (int i = 0; i < 6; i++)
            {
                var elem = array.ElementAt(0);
                array.Remove(elem);
            }

            Assert.AreEqual(2, array.Length);
            Assert.AreEqual(16, array.Capacity);
        }

        [Test]
        public void ShouldRemoveLastElementOnPop()
        {
            var array = new ResizeableArray<int>();

            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.AreEqual(3, array.Length);

            var element = array.Pop();
            Assert.AreEqual(3, element);
            Assert.AreEqual(2, array.Length);
            Assert.AreEqual(1, array.ElementAt(0));
            Assert.AreEqual(2, array.ElementAt(1));
        }

        [Test]
        public void ShouldDecreaseCapacityOnPop()
        {
            var array = new ResizeableArray<int>();

            Assert.AreEqual(16, array.Capacity);

            for (int i = 0; i < 16; i++)
            {
                array.Add(i);
            }

            Assert.AreEqual(32, array.Capacity);
            Assert.AreEqual(16, array.Length);

            for (int i = 0; i < 8; i++)
            {
                array.Pop();
            }

            Assert.AreEqual(16, array.Capacity);
            Assert.AreEqual(8, array.Length);

            for (int i = 0; i < 6; i++)
            {
                array.Pop();
            }

            Assert.AreEqual(2, array.Length);
            Assert.AreEqual(16, array.Capacity);
        }

        [Test]
        public void ShouldThorwExceptionOnPopWhenArrayIsEmpty()
        {
            var array = new ResizeableArray<int>();

            Assert.AreEqual(0, array.Length);
            Assert.Throws<Exception>(() => array.Pop());
        }

        [Test]
        public void ShouldReturnFirstIndexOnFindWhenElementExists()
        {
            var array = new ResizeableArray<int>();

            array.Add(12);
            array.Add(16);
            array.Add(14);
            array.Add(16);
            array.Add(25);

            var index = array.Find(16);

            Assert.AreEqual(1, index);
        }

        [Test]
        public void ShouldReturnMinusOneOnFindWhenElementDoesNotExist()
        {
            var array = new ResizeableArray<int>();

            array.Add(12);
            array.Add(16);
            array.Add(14);
            array.Add(16);
            array.Add(25);

            var index = array.Find(200);

            Assert.AreEqual(-1, index);
        }

        [Test]
        public void ShouldSetCorrectAtValueAtGivenIndexOnSet()
        {
            var array = new ResizeableArray<int>();

            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Set(1, 15);

            Assert.AreEqual(3, array.Length);
            Assert.AreEqual(1, array.ElementAt(0));
            Assert.AreEqual(15, array.ElementAt(1));
            Assert.AreEqual(3, array.ElementAt(2));
        }

        [Test]
        public void ShouldThrowExceptionOnSetWhenArrayIsEmpty()
        {
            var array = new ResizeableArray<int>();

            Assert.Throws<Exception>(() => array.Set(0, 15));
        }

        [Test]
        public void ShouldThrowExceptionOnSetWhenIndexOutOfBounds()
        {
            var array = new ResizeableArray<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);

            Assert.AreEqual(3, array.Length);
            Assert.Throws<Exception>(() => array.Set(6, 15));
        }

        [Test]
        public void ShouldThrowExceptionOnPopWhenArrayIsEmpty()
        {
            var array = new ResizeableArray<int>();

            Assert.Throws<Exception>(() => array.Pop());
        }
    }
}
