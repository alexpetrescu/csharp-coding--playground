using System;
using csharp_coding_playground.Infrastructure;

namespace csharp_coding_playground.DataStructures
{
    public class ResizeableArray<T>
    {
        private const int MIN_CAPACITY = 16;

        /// <summary>
        /// Returns the number of elements in the array.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Returns the number of elements that the array can hold.
        /// </summary>
        public int Capacity { get; private set; } = MIN_CAPACITY;

        private T[] data = new T[MIN_CAPACITY];

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
        /// Returns the element at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T ElementAt(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new ValidationException("Index out of bounds");
            }

            return data[index];
        }

        /// <summary>
        /// Adds the element at the end of array.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            data[Length] = item;
            Length++;

            if (Length == Capacity)
            {
                Resize(Capacity * 2);
            }
        }

        /// <summary>
        /// Inserts the element at the given index.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public void Insert(T item, int index)
        {
            if (index != 0 && (index >= Length || index < 0))
            {
                throw new ValidationException("Index out of bounds");
            }

            ShiftRight(index);
            Length++;
            data[index] = item;

            if (Length == Capacity)
            {
                Resize(Capacity * 2);
            }
        }

        /// <summary>
        /// Adds an element at the beginning of the array.
        /// </summary>
        /// <param name="item"></param>
        public void Prepend(T item)
        {
            Insert(item, 0);
        }

        /// <summary>
        /// Removes the element at the given index of the array.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new ValidationException("Index out of bounds");
            }

            ShiftLeft(index);
            Length--;

            if (Length == Capacity / 4)
            {
                Resize(Capacity / 2);
            }
        }

        /// <summary>
        /// Removes all the occurences of the given value from the linked list.
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            int i = 0;
            while (i < Length)
            {
                if (item.Equals(data[i]))
                {
                    RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        /// <summary>
        /// Removes and returns the last element of the array.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (Length == 0)
            {
                throw new ValidationException("The array is empty");
            }

            var element = data[Length - 1];
            Length--;

            if (Length == Capacity / 4)
            {
                Resize(Capacity / 2);
            }

            return element;
        }

        /// <summary>
        /// Returns the index of the first element that is equal with the provided value; -1 if there is no match.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Find(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (item.Equals(data[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Updates the value of the element at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Set(int index, T item)
        {
            if (index >= Length || index < 0)
            {
                throw new ValidationException("Index out of bounds");
            }


            data[index] = item;
        }

        /// <summary>
        /// Set the capacity of the array.
        /// </summary>
        /// <param name="size"></param>
        private void Resize(int size)
        {
            size = Math.Max(size, MIN_CAPACITY);
            if (Capacity == size)
            {
                return;
            }

            int newCapacity = size;
            Capacity = newCapacity;
            T[] newData = new T[newCapacity];

            for (int i = 0; i < Length; i++)
            {
                newData[i] = data[i];
            }

            data = newData;
        }

        /// <summary>
        /// Shifts all elements to right from the given index.
        /// </summary>
        /// <param name="index"></param>
        private void ShiftRight(int index)
        {
            for (int i = Length; i > index; i--)
            {
                data[i] = data[i - 1];
            }
        }

        /// <summary>
        /// Shifts all elements to left from the given index.
        /// </summary>
        /// <param name="index"></param>
        private void ShiftLeft(int index)
        {
            for (int i = index; i < Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
        }
    }
}