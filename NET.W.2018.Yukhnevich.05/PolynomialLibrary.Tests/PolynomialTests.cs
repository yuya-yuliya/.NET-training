using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace PolynomialLibrary.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        static IEnumerable<Tuple<bool, Polynomial, Polynomial>> EqualsTestData()
        {
            double[] coefficients = { 0, 1, 2, 3, 4, 5 };
            Polynomial polynomial1 = new Polynomial(coefficients);
            Polynomial polynomial2 = new Polynomial(coefficients);
            Polynomial polynomial3 = new Polynomial( 1, 2, 3, 4, 5, 6 );
            Polynomial polynomial4 = new Polynomial( 0, 1, 2 );
            Polynomial polynomial5 = new Polynomial();
            yield return new Tuple<bool, Polynomial, Polynomial>(true, polynomial1, polynomial2);
            yield return new Tuple<bool, Polynomial, Polynomial>(false, polynomial1, polynomial3);
            yield return new Tuple<bool, Polynomial, Polynomial>(false, polynomial1, polynomial4);
            yield return new Tuple<bool, Polynomial, Polynomial>(false, polynomial1, polynomial5);
        }

        [TestCaseSource(nameof(EqualsTestData))]
        public void Equals_test(Tuple<bool, Polynomial, Polynomial> testTuple)
        {
            Assert.AreEqual(testTuple.Item1, testTuple.Item2.Equals(testTuple.Item3));
        }

        [TestCaseSource(nameof(EqualsTestData))]
        public void GetHashCode_test(Tuple<bool, Polynomial, Polynomial> testTuple)
        {
            Assert.AreEqual(testTuple.Item1, testTuple.Item2.GetHashCode() == testTuple.Item3.GetHashCode());
        }

        [Test]
        public void Addition_PolinomPolinom_test()
        {
            Polynomial pol1 = new Polynomial(1, 2, 3);
            Polynomial pol2 = new Polynomial(2, 3, 4);
            Polynomial expected = new Polynomial(3, 5, 7);

            Assert.AreEqual(expected, pol1 + pol2);
        }

        [Test]
        public void Subtraction_PolinomPolinom_test()
        {
            Polynomial pol1 = new Polynomial(1, 2, 3);
            Polynomial pol2 = new Polynomial(2, 3, 4);
            Polynomial expected = new Polynomial(-1, -1, -1);

            Assert.AreEqual(expected, pol1 - pol2);
        }

        [Test]
        public void Multiplication_ValuePolinom_test()
        {
            Polynomial pol = new Polynomial(1, 2, 3);
            double value = 2;
            Polynomial expected = new Polynomial(2, 4, 6);

            Assert.AreEqual(expected, value * pol);
        }

        [Test]
        public void Multiplication_PolinomValue_test()
        {
            Polynomial pol = new Polynomial(1, 2, 3);
            double value = 2;
            Polynomial expected = new Polynomial(2, 4, 6);

            Assert.AreEqual(expected, pol * value);
        }

        [Test]
        public void Multiplication_PolinomPolinom_test()
        {
            Polynomial pol = new Polynomial(1, 2);
            Polynomial expected = new Polynomial(1, 4, 4);

            Assert.AreEqual(expected, pol * pol);
        }

        [Test]
        public void Division_PolinomValue_test()
        {
            Polynomial pol = new Polynomial(2, 4, 6);
            double value = 2;
            Polynomial expected = new Polynomial(1, 2, 3);

            Assert.AreEqual(expected, pol / value);
        }
    }
}
