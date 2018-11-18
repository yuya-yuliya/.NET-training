using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueLibrary
{
    /// <summary>
    /// Represents queue of elements of T type
    /// </summary>
    /// <typeparam name="T">Type of elements</typeparam>
    public class Queue<T> : IEnumerable<T>, IEnumerable, ICollection
    {
        /// <summary>
        /// Default start count of elements in queue
        /// </summary>
        private const int DefaultCount = 4;

        /// <summary>
        /// Queue grow multiplier
        /// </summary>
        private const int Grow = 2;

        /// <summary>
        /// Index of queue head
        /// </summary>
        private int _head = 0;

        /// <summary>
        /// Index next after last queue item
        /// </summary>
        private int _tail = 0;

        /// <summary>
        /// Inner array of elements
        /// </summary>
        private T[] _items;

        /// <summary>
        /// Initialize new instance of Queue class
        /// </summary>
        public Queue()
        {
            _items = new T[0];
        }

        /// <summary>
        /// Initialize new instance of Queue class with given items
        /// </summary>
        /// <param name="items">Items for queue</param>
        public Queue(IEnumerable<T> items)
        {
            _items = new T[DefaultCount];
            foreach (var item in items)
            {
                Enqueue(item);
            }
        }

        /// <summary>
        /// Initialize new instance of Queue class with current capacity
        /// </summary>
        /// <param name="capacity"></param>
        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
        }

        /// <summary>
        /// Count of elements in queue
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Returns synchronization element
        /// </summary>
        public object SyncRoot => _items.SyncRoot;

        /// <summary>
        /// Gets is the queue is thread safe 
        /// </summary>
        public bool IsSynchronized => false;

        /// <summary>
        /// Add item in queue tail
        /// </summary>
        /// <param name="item">Item for adding</param>
        public void Enqueue(T item)
        {
            if (Count == _items.Length)
            {
                Resize(Count == 0 ? DefaultCount : Count * Grow);
            }

            Count++;
            _items[_tail % _items.Length] = item;
            _tail = (_tail + 1) % _items.Length;
        }

        /// <summary>
        /// Remove item from queue head 
        /// </summary>
        /// <returns>Head item</returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            Count--;
            T item = _items[_head];
            _items[_head] = default(T);
            _head = (_head + 1) % _items.Length;
            return item;
        }

        /// <summary>
        /// Copy part of queue in array
        /// </summary>
        /// <param name="array">Destination array</param>
        /// <param name="index">Copy start index</param>
        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length <= index)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (array.Length - index < Count)
            {
                throw new ArithmeticException("Invalid capacity");
            }

            if (_head < _tail)
            {
                Array.Copy(_items, _head, array, index, Count);
            }
            else
            {
                Array.Copy(_items, _head, array, index, _items.Length - _head);
                Array.Copy(_items, 0, array, index + _items.Length - _head, _tail);
            }
        }

        /// <summary>
        /// Gets the enumerator of current queue
        /// </summary>
        /// <returns>The enumerator of current queue</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        /// <summary>
        /// Gets the enumerator of current queue
        /// </summary>
        /// <returns>The enumerator of current queue</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Clear the queue
        /// </summary>
        public void Clear()
        {
            if (_head < _tail)
            {
                Array.Clear(_items, _head, Count);
            }
            else
            {
                Array.Clear(_items, _head, _items.Length - _head);
                Array.Clear(_items, 0, _tail);
            }

            Count = 0;
            _head = 0;
            _tail = 0;
        }

        /// <summary>
        /// Checks if the queue contains given element
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if the queue contains given element, otherwise false</returns>
        public bool Contains(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < Count; i++)
            {
                if (comparer.Equals(_items[(_head + i) % _items.Length], item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the head queue element without removing
        /// </summary>
        /// <returns>Current head element</returns>
        public T Peek()
        {
            return _items[_head];
        }

        /// <summary>
        /// Transform the queue to array
        /// </summary>
        /// <returns>The array representation of current queue</returns>
        public T[] ToArray()
        {
            T[] array = new T[Count];
            CopyTo(array, 0);
            return array;
        }

        /// <summary>
        /// Trim not using space
        /// </summary>
        public void TrimExcess()
        {
            if (Count != _items.Length)
            {
                Resize(Count);
            }
        }

        /// <summary>
        /// Resize current queue
        /// </summary>
        /// <param name="capacity">New queue capacity</param>
        private void Resize(int capacity)
        {
            T[] newArray = new T[capacity];
            if (Count > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_items, _head, newArray, 0, Count);
                }
                else
                {
                    Array.Copy(_items, _head, newArray, 0, _items.Length - _head);
                    Array.Copy(_items, 0, newArray, _items.Length - _head, _tail);
                }
            }

            _items = newArray;
            _head = 0;
            _tail = _tail == 0 ? 0 : Count - 1;
        }

        /// <summary>
        /// Represents the enumerator of Queue class instance
        /// </summary>
        private class QueueEnumerator : IEnumerator<T>, IEnumerator
        {
            /// <summary>
            /// Queue for enumeration
            /// </summary>
            private Queue<T> queue;

            /// <summary>
            /// Index of the current queue element 
            /// </summary>
            private int index;

            /// <summary>
            /// Initialize new instance of QueueEnumerator class with enumeration through current queue
            /// </summary>
            /// <param name="queue">The queue to enumerate</param>
            public QueueEnumerator(Queue<T> queue)
            {
                this.queue = queue;
                index = -1;
            }

            /// <summary>
            /// Gets value of current item
            /// </summary>
            public T Current
            {
                get
                {
                    if (index != -1)
                    {
                        return queue._items[(queue._head + index) % queue.Count];
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            /// <summary>
            /// Gets value of current item
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            /// <summary>
            /// Dispose current instance
            /// </summary>
            public void Dispose()
            {
            }

            /// <summary>
            /// Moves to next queue element 
            /// </summary>
            /// <returns>True if the next element is exist, otherwise false</returns>
            public bool MoveNext()
            {
                if (index < queue.Count - 1)
                {
                    index++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Returns to queue start
            /// </summary>
            public void Reset()
            {
                index = -1;
            }
        }
    }
}
