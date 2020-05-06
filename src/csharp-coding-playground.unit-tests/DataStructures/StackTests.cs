using csharp_coding_playground.DataStructures;
using csharp_coding_playground.Infrastructure;
using NUnit.Framework;

namespace csharp_coding_playground.unit_tests.DataStructures
{
    public class StackTests
    {
        [Test]
        public void ShouldReturnTrueOnIsEmptyWhenStackIsEmpty()
        {
            var stack = new Stack<int>();

            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void ShouldReturnFalseOnIsEmptyWhenStackHasElements()
        {
            var stack = new Stack<int>();
            Assert.IsTrue(stack.IsEmpty);

            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty);
        }

        [Test]
        public void ShouldReturnCorrectLengthWhenStackIsEmpty()
        {
            var stack = new Stack<int>();

            Assert.AreEqual(0, stack.Length);
        }

        [Test]
        public void ShouldReturnCorrectLengthWhenStackHasElements()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(0, stack.Length);

            stack.Push(1);
            Assert.AreEqual(1, stack.Length);

            stack.Push(2);
            Assert.AreEqual(2, stack.Length);
        }

        [Test]
        public void ShouldAddElementOnTopOfStackOnPush()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(0, stack.Length);

            stack.Push(1);
            Assert.AreEqual(1, stack.Length);
            Assert.AreEqual(1, stack.Peek());

            stack.Push(2);
            Assert.AreEqual(2, stack.Length);
            Assert.AreEqual(2, stack.Peek());
        }

        [Test]
        public void ShouldThrowExceptionOnPopWhenStackIsEmpty()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(0, stack.Length);

            Assert.Throws<ValidationException>(() => stack.Pop());
        }

        [Test]
        public void ShouldReturnAndRemoveTopElementOnPop()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(0, stack.Length);

            stack.Push(1);
            Assert.AreEqual(1, stack.Length);
            Assert.AreEqual(1, stack.Peek());

            stack.Push(2);
            Assert.AreEqual(2, stack.Length);
            Assert.AreEqual(2, stack.Peek());

            var last = stack.Pop();
            Assert.AreEqual(2, last);
            Assert.AreEqual(1, stack.Length);
            Assert.AreEqual(1, stack.Peek());

            last = stack.Pop();
            Assert.AreEqual(1, last);
            Assert.AreEqual(0, stack.Length);
        }

        [Test]
        public void ShouldThrowExceptionOnPeekWhenStackIsEmpty()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(0, stack.Length);

            Assert.Throws<ValidationException>(() => stack.Peek());
        }

        [Test]
        public void ShouldReturnTopElementOnPeek()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(0, stack.Length);

            stack.Push(1);
            Assert.AreEqual(1, stack.Length);
            Assert.AreEqual(1, stack.Peek());

            stack.Push(2);
            Assert.AreEqual(2, stack.Length);
            Assert.AreEqual(2, stack.Peek());

            var last = stack.Peek();
            Assert.AreEqual(2, last);
            Assert.AreEqual(2, stack.Length);

            stack.Pop();

            last = stack.Peek();
            Assert.AreEqual(1, last);
            Assert.AreEqual(1, stack.Length);
        }

    }
}