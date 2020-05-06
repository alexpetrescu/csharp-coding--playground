using csharp_coding_playground.Infrastructure;

namespace csharp_coding_playground.DataStructures
{
    public class Queue<T>
    {
        private readonly LinkedList<T> linkedList = new LinkedList<T>();

        /// <summary>
        /// Returns the number of elements in the queue.
        /// </summary>
        public int Length
        {
            get
            {
                return linkedList.Length;
            }
        }

        /// <summary>
        /// Returns true if the queue is empty; false otherwise.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Length == 0;
            }
        }

        /// <summary>
        /// Adds value at the end of the queue.
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            linkedList.PushBack(value);
        }

        /// <summary>
        /// Returns and removes the first element in the queue.
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new ValidationException("Queue is empty");
            }

            return linkedList.PopFront();
        }
    }
}