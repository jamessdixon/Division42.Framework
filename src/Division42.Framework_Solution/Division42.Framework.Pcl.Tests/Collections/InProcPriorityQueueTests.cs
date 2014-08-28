using System;
using Division42.Framework.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Division42.Framework.Pcl.Tests.Collections
{
    [TestClass]
    public class InProcPriorityQueueTests
    {
        [TestMethod]
        public void ConstructorWithNoArguments_ReturnsInstance()
        {
            IPriorityQueue<String> instance = new InProcPriorityQueue<String>();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void EnqueueWithSingleArgument_ReturnsSameItem()
        {
            IPriorityQueue<String> instance = new InProcPriorityQueue<String>();
            String expected = "One";
            String actual = String.Empty;
            instance.Enqueue(expected);

            actual = instance.Dequeue();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnqueueWithTwoItems_ReturnsFirstItem()
        {
            IPriorityQueue<String> instance = new InProcPriorityQueue<String>();
            String expected = "One";
            String actual = String.Empty;
            instance.Enqueue(expected);
            instance.Enqueue("Two");

            actual = instance.Dequeue();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnqueueWithThreeItems_ReturnsAllInOrder()
        {
            IPriorityQueue<String> instance = new InProcPriorityQueue<String>();
            String expected1 = "One";
            String expected2 = "Two";
            String expected3 = "Three";
            String actual1 = String.Empty;
            String actual2= String.Empty;
            String actual3 = String.Empty;
            
            instance.Enqueue(expected1);
            instance.Enqueue(expected2);
            instance.Enqueue(expected3);

            actual1 = instance.Dequeue();
            actual2 = instance.Dequeue();
            actual3 = instance.Dequeue();

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }

        [TestMethod]
        public void EnqueueWithThreeItemsMove2To1_ReturnsAllInNewOrder()
        {
            IPriorityQueue<String> instance = new InProcPriorityQueue<String>();
            String expected1 = "One";
            String expected2 = "Two";
            String expected3 = "Three";
            String actual1 = String.Empty;
            String actual2 = String.Empty;
            String actual3 = String.Empty;

            instance.Enqueue(expected1);
            instance.Enqueue(expected2);
            instance.Enqueue(expected3);

            instance.MoveUp(expected2);

            actual1 = instance.Dequeue();
            actual2 = instance.Dequeue();
            actual3 = instance.Dequeue();

            // New order should be 2,1,3 because #2 got moved up.
            Assert.AreEqual(expected2, actual1);
            Assert.AreEqual(expected1, actual2);
            Assert.AreEqual(expected3, actual3);
        }

        [TestMethod]
        public void EnqueueWithThreeItemsMove2To3_ReturnsAllInNewOrder()
        {
            IPriorityQueue<String> instance = new InProcPriorityQueue<String>();
            String expected1 = "One";
            String expected2 = "Two";
            String expected3 = "Three";
            String actual1 = String.Empty;
            String actual2 = String.Empty;
            String actual3 = String.Empty;

            instance.Enqueue(expected1);
            instance.Enqueue(expected2);
            instance.Enqueue(expected3);

            instance.MoveDown(expected2);

            actual1 = instance.Dequeue();
            actual2 = instance.Dequeue();
            actual3 = instance.Dequeue();

            // New order should be 2,1,3 because #2 got moved up.
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected3, actual2);
            Assert.AreEqual(expected2, actual3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EnqueueMoveUpWhenAlreadyAtTop_ThrowInvalidOperationException()
        {
            IPriorityQueue<String> instance = new InProcPriorityQueue<String>();
            String expected = "One";

            instance.Enqueue(expected);

            instance.MoveUp(expected);

            Assert.Fail("Should have thrown an InvalidOperationException.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EnqueueMoveUpWhenAlreadyAtBottom_ThrowInvalidOperationException()
        {
            IPriorityQueue<String> instance = new InProcPriorityQueue<String>();
            String expected = "One";

            instance.Enqueue(expected);

            instance.MoveDown(expected);

            Assert.Fail("Should have thrown an InvalidOperationException.");
        }

    }
}
