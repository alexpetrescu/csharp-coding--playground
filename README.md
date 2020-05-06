# C# Coding Playground
![pipeline](https://github.com/alexpetrescu/csharp-coding-playground/workflows/pipeline/badge.svg)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/e1170d8482ea448e9acf288d3dcfe964)](https://app.codacy.com/manual/alexpetrescu1996/csharp-coding-playground?utm_source=github.com&utm_medium=referral&utm_content=alexpetrescu/csharp-coding-playground&utm_campaign=Badge_Grade_Dashboard)
![Codacy Badge](https://img.shields.io/codacy/coverage/a7c41f5ce6904ba089f9807bf8e135c1)
![license](https://img.shields.io/github/license/alexpetrescu/csharp-coding-playground)
## Data Structures 
### ResizeableArray   
- [x] Automatically resizing array
- [x] Length - Returns the number of elements in the array.
- [x] Capacity  - Returns the number of elements that the array can hold.
- [x] IsEmpty() - Returns true if the array is empty; false otherwise.
- [x] ElementAt(int) - Returns the element at the given index.
- [x] Add(T) - Adds the element at the end of array.
- [x] Insert(int, T) - Inserts the element at the given index.
- [x] Prepend(T) - Adds an element at the beginning of the array.
- [x] Pop() - Removes and returns the last element of the array.
- [x] RemoveAt(int) - Removes the element at the given index of the array.
- [x] Remove(T) - Removes all the occurences of the given value from the linked list.
- [x] Find(T) - Returns the index of the first element that is equal with the provided value; -1 if there is no match.
- [x] Set(int, T) - Updates the value of the element at the given index.

### Linked List
- [x] Head - The first element of the linked list.
- [x] Tail - The last element of the linked list.
- [x] Length - The number of elements in the linked list.
- [x] Empty - Returns true if the linked list is empty; false otherwise.
- [x] ElementAt(int) - Returns the element at the given index.
- [x] PushFront(T) - Adds the element at the beginning of the linked list.
- [x] PopFront() - Removes and returns the first element of the linked list.
- [x] PushBack(T) - Adds the element at the end of the linked list.
- [x] PopBack() - Returns and removes the last element of the linked list.
- [x] Front() - Returns the first element of the linked list.
- [x] Back() - Returns the last element of the linked list.
- [x] Set(int, T) - Updates the value of the element at the given index of the linked list.
- [x] Insert(int, T) - Inserts the element at the given index of the linked list.
- [x] RemoveAt(int) - Removes the element at the given index of the linked list.
- [x] Remove(T) - Removes all the occurences of the given value from the linked list.
- [x] NthValueFromEnd(int) - Returns the value of the node at nth position from the end of the linked list.
- [x] Reverse() - Reverses the linked list.

### Stack
- [x] Length - Returns the number of elements in the stack.
- [x] IsEmpty - Returns true if the array is empty; false otherwise.
- [x] Push(T) - Adds the element on top of the stack.
- [x] Pop() - Removes and returns the top of the stack.
- [x] Peek() - Returns the top of the stack.

### Queue
- [x] Length - Returns the number of elements in the queue.
- [x] IsEmpty - Returns true if the queue is empty; false otherwise.
- [x] Enqueue(T) - Adds value at the end of the queue.
- [x] Dequeue() - Returns and removes the first element in the queue.

### HashTable
- [x] Add(K, T) - Adds value for the provided key; if key already exists, updates value.
- [x] ContainsKey(K) - Returns if the key is present in the hash table.
- [x] Get(K) - Returns the value for the give key.
- [x] Remove(K) - Removes the given key from the hash table.

### Binary Search Tree
- [x] Insert(T) - Inserts a new node with the given value in the tree.
- [x] Search(T) - Searches for the given value in the tree.
- [x] Remove(T) - Removes value from the tree.
- [x] BFS() - Performs BFS on the tree.
- [x] DFS(Strategy) - Performs DFS on the tree with the given strategy.
- [x] Length - The number of nodes in the tree.
- [x] Height - Returns the height of the tree. 
- [x] Successor(T) - Returns highest value after the given value.
- [x] Min() - Returns the min value of the tree.
- [x] Max() - Returns the max value of the tree.

## Algorithms
### Binary Search
- Performs search on a sorted array for a given value. 
### Merge Sort
- Performs merge sort on a given array.
### Quick Sort
- Performs quick sort on a given array.
### Heap Sort
- Performs heap sort on a given array.
