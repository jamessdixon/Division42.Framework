using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Division42.Framework.Collections
{
    /// <summary>
    /// Interface for a queue which is reorderable.
    /// </summary>
    /// <typeparam name="TItem">The type of object that will be stored in the queue.</typeparam>
    /// <threadsafety static="true" instance="true"/>
    public interface IPriorityQueue<TItem> : IEnumerable<TItem> where TItem : class
    {
        /// <summary>
        /// Enqueues an item.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="item"/> is null.</exception>
        void Enqueue(TItem item);
        
        /// <summary>
        /// Takes the next available item from the queue.
        /// </summary>
        /// <returns>The next available item.</returns>
        /// <exception cref="EmptyQueueException">If the queue is currently empty.</exception>
        TItem Dequeue();

        /// <summary>
        /// Previews the next available item from the queue without removing it from the queue.
        /// </summary>
        /// <returns>A preview of the next available item.</returns>
        /// <exception cref="EmptyQueueException">If the queue is currently empty.</exception>
        TItem Peek();

        /// <summary>
        /// Moves the specified <paramref name="item"/> up one position in the queue.
        /// </summary>
        /// <param name="item">The item to move.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="item"/> is null.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="item"/> is already the first item.</exception>
        void MoveUp(TItem item);
        
        /// <summary>
        /// Moves the specified <paramref name="item"/> down on position in the queue.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException">If <paramref name="item"/> is null.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="item"/> is already the last item.</exception>
        void MoveDown(TItem item);
    }
}
