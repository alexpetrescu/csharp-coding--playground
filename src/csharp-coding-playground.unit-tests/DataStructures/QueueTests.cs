using csharp_coding_playground.DataStructures;
using csharp_coding_playground.Infrastructure;
using NUnit.Framework;

namespace csharp_coding_playground.unit_tests.DataStructures
{
    public class QueueTests
    {
        [Test]
        public void ShouldReturnTrueOnIsEmptyWhenQueueIsEmpty()
        {
            var queue = new Queue<int>();

            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void ShouldReturnFalseOnIsEmptyWhenQueueHasElements()
        {
            var queue = new Queue<int>();
            Assert.IsTrue(queue.IsEmpty);

            queue.Enqueue(1);
            Assert.IsFalse(queue.IsEmpty);
        }

        [Test]
        public void ShouldReturnCorrectLengthWhenQueueIsEmpty()
        {
            var queue = new Queue<int>();

            Assert.AreEqual(0, queue.Length);
        }

        [Test]
        public void ShouldReturnCorrectLengthWhenQueueHasElements()
        {
            var queue = new Queue<int>();
            Assert.AreEqual(0, queue.Length);

            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Length);

            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Length);
        }

        [Test]
        public void ShouldAddElementAtTheEndOfQueueOnEnqueue()
        {
            var queue = new Queue<int>();
            Assert.AreEqual(0, queue.Length);

            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Length);
            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Length);
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Length);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Length);
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(1, queue.Length);
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(0, queue.Length);
        }

        [Test]
        public void ShouldThrowExceptionOnEnqueueWhenQueueIsEmpty()
        {
            var queue = new Queue<int>();

            Assert.Throws<ValidationException>(() => queue.Dequeue());
        }

        [Test]
        public void ShouldRemoveFirstElementOnDequeue()
        {
            var queue = new Queue<int>();
            Assert.AreEqual(0, queue.Length);

            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Length);
            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Length);
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Length);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Length);
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(1, queue.Length);
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(0, queue.Length);
        }
    }
}