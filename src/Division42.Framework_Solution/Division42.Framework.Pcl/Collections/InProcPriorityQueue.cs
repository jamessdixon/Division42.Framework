using System;
using System.Collections;
using System.Collections.Generic;

namespace Division42.Framework.Collections
{
    /// <summary>
    /// An in-memory/in-process priority queue.
    /// </summary>
    /// <typeparam name="TItem">The type of object that will be stored in the queue.</typeparam>
    /// <threadsafety static="true" instance="true"/>
    public class InProcPriorityQueue<TItem> : IPriorityQueue<TItem> where TItem : class
    {
        /// <summary>
        /// Enqueues an item.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="item"/> is null.</exception>
        public void Enqueue(TItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            _innerList.Add(item);
        }

        /// <summary>
        /// Takes the next available item from the queue.
        /// </summary>
        /// <returns>The next available item.</returns>
        /// <exception cref="EmptyQueueException">If the queue is currently empty.</exception>
        public TItem Dequeue()
        {
            lock (_queueLock)
            {
                if (_innerList.Count > 0)
                {
                    TItem item = _innerList[0];
                    _innerList.Remove(item);
                    return item;
                }

                throw new EmptyQueueException("The queue is empty.");
            }
        }

        /// <summary>
        /// Previews the next available item from the queue without removing it from the queue.
        /// </summary>
        /// <returns>A preview of the next available item.</returns>
        /// <exception cref="EmptyQueueException">If the queue is currently empty.</exception>
        public TItem Peek()
        {
            if (_innerList.Count > 0)
            {
                return _innerList[0];
            }

            throw new EmptyQueueException("The queue is empty.");
        }

        /// <summary>
        /// Moves the specified <paramref name="item"/> up one position in the queue.
        /// </summary>
        /// <param name="item">The item to move.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="item"/> is null.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="item"/> is already the first item.</exception>
        public void MoveUp(TItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            lock (_queueLock)
            {
                Int32 oldIndex = _innerList.IndexOf(item);

                if (oldIndex == 0)
                    throw new InvalidOperationException("Item is already the first item in the queue.");

                Int32 newIndex = oldIndex-1;

                _innerList.RemoveAt(oldIndex);
                _innerList.Insert(newIndex, item);
            }
        }

        /// <summary>
        /// Moves the specified <paramref name="item"/> down on position in the queue.
        /// </summary>
        /// <param name="item">The item to be moved.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="item"/> is null.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="item"/> is already the last item.</exception>
        public void MoveDown(TItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            lock (_queueLock)
            {
                Int32 oldIndex = _innerList.IndexOf(item);

                if (oldIndex > _innerList.Count -1)
                    throw new InvalidOperationException("Item is already the last item in the queue.");

                Int32 newIndex = oldIndex+1;

                if (newIndex> _innerList.Count-1)
                    throw new InvalidOperationException("Item is already the last item in the queue.");

                _innerList.RemoveAt(oldIndex);
                _innerList.Insert(newIndex, item);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection
        /// </summary>
        public IEnumerator<TItem> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private List<TItem> _innerList = new List<TItem>();
        private static Object _queueLock = new Object();
    }
}