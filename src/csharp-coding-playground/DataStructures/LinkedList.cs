using System;
using csharp_coding_playground.Infrastructure;

namespace csharp_coding_playground.DataStructures
{
    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;

        /// <summary>
        /// The first element of the linked list.
        /// </summary>
        public T Head
        {
            get
            {
                return head != null ? head.Value : default;
            }
        }

        /// <summary>
        /// The last element of the linked list.
        /// </summary>
        public T Tail
        {
            get
            {
                return tail != null ? tail.Value : default;
            }
        }


        /// <summary>
        /// The number of elements in the linked list.
        /// </summary>
        public int Length { get; private set; } = 0;


        /// <summary>
        /// Returns true if the linked list is empty; false otherwise.
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
                throw new Exception("Index out of bounds");

            var node = head;
            while (index > 0)
            {
                node = node.Next;
                index--;
            }

            return node.Value;
        }


        /// <summary>
        /// Adds the element at the beginning of the linked list.
        /// </summary>
        /// <param name="value"></param>
        public void PushFront(T value)
        {
            var newNode = new LinkedListNode<T>();
            newNode.Value = value;
            newNode.Next = head;

            if (Length == 0)
            {
                tail = newNode;
            }

            head = newNode;
            Length++;
        }


        /// <summary>
        /// Removes and returns the first element of the linked list.
        /// </summary>
        /// <returns></returns>
        public T PopFront()
        {
            if (Length == 0)
                throw new Exception("Linked List is empty");

            var node = head;

            head = head.Next;
            Length--;

            if (Length <= 1)
            {
                tail = head;
            }

            return node.Value;
        }

        /// <summary>
        /// Adds the element at the end of the linked list.
        /// </summary>
        /// <param name="value"></param>
        public void PushBack(T value)
        {
            var newNode = new LinkedListNode<T>();
            newNode.Value = value;
            newNode.Next = null;

            if (Length == 0)
            {
                head = newNode;
            }
            else
            {
                tail.Next = newNode;
            }

            tail = newNode;
            Length++;
        }

        /// <summary>
        /// Returns and removes the last element of the linked list.
        /// </summary>
        /// <returns></returns>
        public T PopBack()
        {
            if (Length == 0)
                throw new Exception("Linked List is empty");

            var node = tail;
            LinkedListNode<T> prevNode = null;
            var currNode = head;

            while (currNode.Next != null)
            {
                prevNode = currNode;
                currNode = currNode.Next;
            }

            tail = prevNode;
            if (tail != null) tail.Next = null;
            Length--;

            if (Length <= 1)
            {
                head = tail;
            }

            return node.Value;
        }


        /// <summary>
        /// Returns the first element of the linked list.
        /// </summary>
        /// <returns></returns>
        public T Front()
        {
            if (Length == 0)
                throw new Exception("Linked List is empty");

            return head.Value;
        }

        /// <summary>
        /// Returns the last element of the linked list.
        /// </summary>
        /// <returns></returns>
        public T Back()
        {
            if (Length == 0)
                throw new Exception("Linked List is empty");

            return tail.Value;
        }

        /// <summary>
        /// Updates the value of the element at the given index of the linked list.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Set(int index, T value)
        {
            if (index >= Length || index < 0)
                throw new Exception("Index out of bounds");

            var node = head;
            while (index > 0)
            {
                node = node.Next;
                index--;
            }

            node.Value = value;
        }


        /// <summary>
        /// Inserts the element at the given index of the linked list.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, T value)
        {
            if (index != 0 && (index >= Length || index < 0))
                throw new Exception("Index out of bounds");
            
            if (index == 0)
            {
                PushFront(value);
                return;
            }

            var node = head;
            LinkedListNode<T> prevNode = null;
            while (index > 0)
            {
                prevNode = node;
                node = node.Next;
                index--;
            }

            var newNode = new LinkedListNode<T>();
            newNode.Value = value;
            newNode.Next = node;
            if (prevNode != null) prevNode.Next = newNode;
            Length++;
        }

        /// <summary>
        /// Removes the element at the given index of the linked list.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index >= Length || index < 0)
                throw new Exception("Index out of bounds");

            if (index == 0)
            {
                PopFront();
                return;
            }

            if (index == Length - 1)
            {
                PopBack();
                return;
            }

            LinkedListNode<T> prevNode = null;
            var node = head;

            while (index > 0)
            {
                prevNode = node;
                node = node.Next;
                index--;
            }

            prevNode.Next = node.Next;
            Length--;
        }


        /// <summary>
        /// Removes all the occurences of the given value from the linked list.
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            var node = head;
            LinkedListNode<T> prev = null;

            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    if (prev != null)
                    {
                        prev.Next = node.Next;
                        Length--;
                        if (node.Next == null) tail = prev;
                    }
                    else
                    {
                        PopFront();
                    }
                }

                prev = node;
                node = node.Next;
            }


        }

        /// <summary>
        /// Returns the value of the node at nth position from the end of the linked list.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public T NthValueFromEnd(int n)
        {
            if (n >= Length || n < 0)
                throw new Exception("Index out of bounds");

            return ElementAt(Length - 1 - n);
        }


        /// <summary>
        /// Reverses the linked list.
        /// </summary>
        public void Reverse()
        {
            var newTail = head;

            var node = head;
            LinkedListNode<T> prev = null;
            while (node != null)
            {
                var next = node.Next;
                node.Next = prev;
                prev = node;
                node = next;
            }

            head = prev;
            tail = newTail;
        }
    }
}
