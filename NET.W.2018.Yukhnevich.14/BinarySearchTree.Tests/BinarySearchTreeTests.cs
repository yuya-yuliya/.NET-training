using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BinarySearchTreeLibrary.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        public static BinarySearchTree<int> GetIntTree(IComparer<int> comparer)
        {
            BinarySearchTree<int> tree;
            if (comparer == null)
            {
                tree = new BinarySearchTree<int>();
            }
            else
            {
                tree = new BinarySearchTree<int>(comparer);
            }

            int[] array = { 2, 4, -3, 5, 3, 0 };
            foreach (var item in array)
            {
                tree.Add(item);
            }
            return tree;
        }

        public static BinarySearchTree<string> GetStringTree(IComparer<string> comparer)
        {
            BinarySearchTree<string> tree;
            if (comparer == null)
            {
                tree = new BinarySearchTree<string>();
            }
            else
            {
                tree = new BinarySearchTree<string>(comparer);
            }

            string[] array = { "G", "B", "K", "I", "Z", "A" };
            foreach (var item in array)
            {
                tree.Add(item);
            }
            return tree;
        }

        public static BinarySearchTree<Book> GetBookTree(IComparer<Book> comparer)
        {
            BinarySearchTree<Book> tree;
            if (comparer == null)
            {
                tree = new BinarySearchTree<Book>();
            }
            else
            {
                tree = new BinarySearchTree<Book>(comparer);
            }

            Book[] array = {
                new Book("C", "B"),
                new Book("C", "C"),
                new Book("B", "D"),
                new Book("F", "A")
            };
            foreach (var item in array)
            {
                tree.Add(item);
            }
            return tree;
        }

        public static BinarySearchTree<Point> GetPointTree(IComparer<Point> comparer)
        {
            BinarySearchTree<Point> tree;
            if (comparer == null)
            {
                tree = new BinarySearchTree<Point>();
            }
            else
            {
                tree = new BinarySearchTree<Point>(comparer);
            }

            Point[] array = {
                new Point(1, 1),
                new Point(-5, 3),
                new Point(5, 11),
                new Point(4, 4)
            };
            foreach (var item in array)
            {
                tree.Add(item);
            }
            return tree;
        }

        public static IEnumerable<ITester> DefaultComparerPreorderTestCases()
        {
            yield return new Tester<int>(new int[] { 2, -3, 0, 4, 3, 5 }, GetIntTree(null).Preorder, null);
            yield return new Tester<string>(new string[] { "G", "B", "A", "K", "I", "Z" }, GetStringTree(null).Preorder, null);
            yield return new Tester<Book>(new Book[] {
                new Book("C", "B"),
                new Book("B", "D"),
                new Book("C", "C"),
                new Book("F", "A")
            }, GetBookTree(null).Preorder, null);
        }

        [TestCaseSource(nameof(DefaultComparerPreorderTestCases))]
        public void Preorder_DefaultComparer(ITester tester)
        {
            tester.Test();
        }

        public static IEnumerable<ITester> DefaultComparerInorderTestCases()
        {
            yield return new Tester<int>(new int[] { -3, 0, 2, 3, 4, 5 }, GetIntTree(null).Inorder, null);
            yield return new Tester<string>(new string[] { "A", "B", "G", "I", "K", "Z" }, GetStringTree(null).Inorder, null);
            yield return new Tester<Book>(new Book[] {
                new Book("B", "D"),
                new Book("C", "B"),
                new Book("C", "C"),
                new Book("F", "A")
            }, GetBookTree(null).Inorder, null);
        }

        [TestCaseSource(nameof(DefaultComparerInorderTestCases))]
        public void Inorder_DefaultComparer(ITester tester)
        {
            tester.Test();
        }

        public static IEnumerable<ITester> DefaultComparerPostorderTestCases()
        {
            yield return new Tester<int>(new int[] { 0, -3, 3, 5, 4, 2 }, GetIntTree(null).Postorder, null);
            yield return new Tester<string>(new string[] { "A", "B", "I", "Z", "K", "G" }, GetStringTree(null).Postorder, null);
            yield return new Tester<Book>(new Book[] {
                new Book("B", "D"),
                new Book("F", "A"),
                new Book("C", "C"),
                new Book("C", "B")               
            }, GetBookTree(null).Postorder, null);
        }

        [TestCaseSource(nameof(DefaultComparerPostorderTestCases))]
        public void Postorder_DefaultComparer(ITester tester)
        {
            tester.Test();
        }

        public static IEnumerable<ITester> CustomComparerPreorderTestCases()
        {
            yield return new Tester<int>(new int[] { 2, 4, 5, 3, -3, 0 }, GetIntTree(new IntComparer()).Preorder, new IntComparer());
            yield return new Tester<string>(new string[] { "G", "K", "Z", "I", "B", "A" }, GetStringTree(new StringComparer()).Preorder, new StringComparer());
            yield return new Tester<Book>(new Book[] {
                new Book("C", "B"),
                new Book("F", "A"),
                new Book("C", "C"),
                new Book("B", "D")
            }, GetBookTree(new BookComparer()).Preorder, new BookComparer());
            yield return new Tester<Point>(new Point[] {
                new Point(1, 1),
                new Point(-5, 3),
                new Point(5, 11),
                new Point(4, 4)
            }, GetPointTree(new PointComparer()).Preorder, new PointComparer());
        }

        [TestCaseSource(nameof(CustomComparerPreorderTestCases))]
        public void Preorder_CustomComparer(ITester tester)
        {
            tester.Test();
        }

        public static IEnumerable<ITester> CustomComparerInorderTestCases()
        {
            yield return new Tester<int>(new int[] { 5, 4, 3, 2, 0, -3 }, GetIntTree(new IntComparer()).Inorder, new IntComparer());
            yield return new Tester<string>(new string[] { "Z", "K", "I", "G", "B", "A" }, GetStringTree(new StringComparer()).Inorder, new StringComparer());
            yield return new Tester<Book>(new Book[] {
                new Book("F", "A"),
                new Book("C", "B"),
                new Book("C", "C"),
                new Book("B", "D")
            }, GetBookTree(new BookComparer()).Inorder, new BookComparer());
            yield return new Tester<Point>(new Point[] {
                new Point(-5, 3),
                new Point(1, 1),
                new Point(4, 4),
                new Point(5, 11)
            }, GetPointTree(new PointComparer()).Inorder, new PointComparer());
        }

        [TestCaseSource(nameof(CustomComparerInorderTestCases))]
        public void Inorder_CustomComparer(ITester tester)
        {
            tester.Test();
        }

        public static IEnumerable<ITester> CustomComparerPostorderTestCases()
        {
            yield return new Tester<int>(new int[] { 5, 3, 4, 0, -3, 2 }, GetIntTree(new IntComparer()).Postorder, new IntComparer());
            yield return new Tester<string>(new string[] { "Z", "I", "K", "A", "B", "G" }, GetStringTree(new StringComparer()).Postorder, new StringComparer());
            yield return new Tester<Book>(new Book[] {
                new Book("F", "A"),
                new Book("B", "D"),
                new Book("C", "C"),
                new Book("C", "B")
            }, GetBookTree(new BookComparer()).Postorder, new BookComparer());
            yield return new Tester<Point>(new Point[] {
                new Point(-5, 3),
                new Point(4, 4),
                new Point(5, 11),
                new Point(1, 1)
            }, GetPointTree(new PointComparer()).Postorder, new PointComparer());
        }

        [TestCaseSource(nameof(CustomComparerPostorderTestCases))]
        public void Postorder_CustomComparer(ITester tester)
        {
            tester.Test();
        }
    }

    public class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public int CompareTo(Book other)
        {
            if (Title == other.Title)
            {
                return Author.CompareTo(other.Author);
            }
            else
            {
                return Title.CompareTo(other.Title);
            }
        }

        public override string ToString()
        {
            return $"\"{Title}\" {Author}";
        }
    }

    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }

    class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return y.CompareTo(x);
        }
    }

    class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Author.CompareTo(y.Author);
        }
    }

    class PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return x.X - y.X;
        }
    }

    public interface ITester
    {
        void Test();
    }

    public class Tester<T> : ITester
    {
        private T[] _expected;
        private Func<IEnumerable<T>> _func;
        private IComparer<T> _comparer;

        public Tester(T[] expected, Func<IEnumerable<T>> func, IComparer<T> comparer)
        {
            _expected = expected;
            _func = func;
            if (comparer == null)
            {
                _comparer = Comparer<T>.Default;
            }
            else
            {
                _comparer = comparer;
            }
        }

        public void Test()
        {
            List<T> result = new List<T>(_func());
            Assert.AreEqual(_expected.Length, result.Count);
            for(int i = 0; i < _expected.Length; i++)
            {
                Assert.AreEqual(0, _comparer.Compare(_expected[i], result[i]), "Expected {0}, but was {1} at index {2}", _expected[i], result[i], i);
            }
        }

        public override string ToString()
        {
            return _func.Target.ToString();
        }
    }
}
