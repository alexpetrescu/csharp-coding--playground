using csharp_coding_playground.Infrastructure;

namespace csharp_coding_playground.DataStructures
{
    public class Stack<T>
    {
        private readonly LinkedList<T> linkedList = new LinkedList<T>();

        /// <summary>
        /// Returns the number of elements in the stack.
        /// </summary>
        public int Length
        {
            get
            {
                return linkedList.Length;
            }
        }

        /// <summary>
        /// Returns true if the array is empty; false otherwise.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Length == 0;
            }
        }

        /// <summary>
        /// Adds the element on top of the stack.
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            linkedList.PushFront(value);
        }

        /// <summary>
        /// Removes and returns the top of the stack.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new ValidationException("Stack is empty");
            }

            return linkedList.PopFront();
        }

        /// <summary>
        /// Returns the top of the stack.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new ValidationException("Stack is empty");
            }

            return linkedList.Front();
        }
    }
}