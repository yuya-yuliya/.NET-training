using System.Collections.Generic;
using NUnit.Framework;

namespace QueueLibrary.Tests
{
    [TestFixture]
    public class QueueTests
    {
        public static string[][] stringArray = { new string[] { "A", "B", "C" } };

        [TestCase(new int[] { 1, 2, 3 })]
        public void Dequeue_ValueType(int[] array)
        {
            Dequeue(array);
        }

        [TestCaseSource(nameof(stringArray))]
        public void Dequeue_RefType(string[] array)
        {
            Dequeue(array);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void GetEnumerator_foreach_ValueType(int[] array)
        {
            GetEnumerator_foreach(array);
        }

        [TestCaseSource(nameof(stringArray))]
        public void GetEnumerator_foreach_RefType(string[] array)
        {
            GetEnumerator_foreach(array);
        }

        [TestCase(1)]
        [TestCase("A")]
        public void Enqueue<T>(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            Queue<T> queue = new Queue<T>();
            queue.Enqueue(item);
            Assert.IsTrue(comparer.Equals(item, queue.Dequeue()));
        }

        [TestCase(1)]
        [TestCase("A")]
        public void Peek<T>(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            Queue<T> queue = new Queue<T>();
            queue.Enqueue(item);
            Assert.IsTrue(comparer.Equals(queue.Peek(), item));
            Assert.AreEqual(1, queue.Count);
        }

        public static void GetEnumerator_foreach<T>(T[] array)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            Queue<T> queue = new Queue<T>(array);
            List<T> valueList = new List<T>(array);
            foreach (var item in queue)
            {
                Assert.IsTrue(valueList.Remove(item));
            }

            Assert.AreEqual(0, valueList.Count);
        }

        public static void Dequeue<T>(T[] array)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            Queue<T> queue = new Queue<T>(array);
            T item = queue.Dequeue();
            Assert.IsTrue(comparer.Equals(item, array[0]));
            Assert.AreEqual(array.Length - 1, queue.Count);
        }
    }
}
