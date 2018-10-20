using System;
using System.Linq;
using System.Text;

namespace PolynomialLibrary
{
    /// <summary>
    /// Class provides methods to create and work with Polynomial expressions
    /// </summary>
    public class Polynomial
    {
        private double[] coefficients;

        /// <summary>
        /// Create new object of class Polynomial with coefficients
        /// </summary>
        /// <param name="coefficients">Array of coefficients</param>
        public Polynomial(params double[] coefficients)
        {
            this.coefficients = new double[coefficients.Length];
            for (int i = 0;  i < coefficients.Length; i++)
            {
                this.coefficients[i] = coefficients[i];
            }
        }

        /// <summary>
        /// Calculate value of polynomial expression 
        /// </summary>
        /// <param name="x">Parameter value</param>
        /// <returns>Value of polynom</returns>
        public double Calculate(double x)
        {
            double value = 0;
            for (int i = 0; i < coefficients.Length; i++)
            {
                value += coefficients[i] * Math.Pow(x, i);
            }
            return value;
        }

        /// <summary>
        /// Get array of polynomial coefficients
        /// </summary>
        public double[] Coefficients
        {
            get
            {
                var coeff = new double[coefficients.Length];
                Array.Copy(coefficients, coeff, coefficients.Length);
                return coeff;
            }
        }

        /// <summary>
        /// Compare polynomials content
        /// </summary>
        /// <param name="pol1">First polynom</param>
        /// <param name="pol2">Second polynom</param>
        /// <returns>True if content is equal, folse otherwise</returns>
        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            return pol1.Equals(pol2);
        }

        /// <summary>
        /// Compare polynomials content
        /// </summary>
        /// <param name="pol1">First polynom</param>
        /// <param name="pol2">Second polynom</param>
        /// <returns>True if content is not equal, folse otherwise</returns>
        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            return !pol1.Equals(pol2);
        }

        /// <summary>
        /// Performs addition of two polynomials
        /// </summary>
        /// <param name="pol1">First polynom</param>
        /// <param name="pol2">Second polynom</param>
        /// <returns>New polynomial with addition results</returns>
        public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
        {
            return AddSubOperation((x, y) => x + y, pol1, pol2);
        }

        /// <summary>
        /// Performs subtraction of two polynomials
        /// </summary>
        /// <param name="pol1">First polynom</param>
        /// <param name="pol2">Second polynom</param>
        /// <returns>New Polynomial with subtraction results</returns>
        public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
        {
            return AddSubOperation((x, y) => x - y, pol1, pol2);
        }

        /// <summary>
        /// Perform operation with coefficients on the same positiond
        /// </summary>
        /// <param name="operation">Operation to perform</param>
        /// <param name="pol1">First polynom</param>
        /// <param name="pol2">Second polynom</param>
        /// <returns>New polynomial with result of operation</returns>
        private static Polynomial AddSubOperation(Func<double, double, double> operation, Polynomial pol1, Polynomial pol2)
        {
            double[] coeff1 = pol1.coefficients;
            double[] coeff2 = pol2.coefficients;
            double[] resultCoeff = new double[Math.Max(coeff1.Length, coeff2.Length)];
            for (int i = 0; i < resultCoeff.Length; i++)
            {
                resultCoeff[i] = operation(i < coeff1.Length ? coeff1[i] : 0, i < coeff2.Length ? coeff2[i] : 0);
            }
            return new Polynomial(resultCoeff);
        }

        /// <summary>
        /// Performs multiplication of two polynomials
        /// </summary>
        /// <param name="pol1">First polynom</param>
        /// <param name="pol2">Second polynom</param>
        /// <returns>New polynomial with multiplication results</returns>
        public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
        {
            double[] coeff1 = pol1.coefficients;
            double[] coeff2 = pol2.coefficients;
            double[] resultCoeff = new double[coeff1.Length + coeff2.Length - 1];
            for (int i = 0; i < coeff1.Length; i++)
            {
                for (int j = 0; j < coeff2.Length; j++)
                {
                    resultCoeff[i + j] += coeff1[i] * coeff2[j];
                }
            }
            return new Polynomial(resultCoeff);
        }

        /// <summary>
        /// Performs multiplication of polynomial and constant value
        /// </summary>
        /// <param name="value">Value to multiply</param>
        /// <param name="pol">Polinomial</param>
        /// <returns>New polynomial with multiplication results</returns>
        public static Polynomial operator *(double value, Polynomial pol)
        {
            return CoefficientsModify((x) => value * x, pol);
        }

        /// <summary>
        /// Performs multiplication of polynomial and constant value
        /// </summary>
        /// <param name="pol">Polinomial</param>
        /// <param name="value">Value to multiply</param>
        /// <returns>New polynomial with multiplication results</returns>
        public static Polynomial operator *(Polynomial pol, double value)
        {
            return value * pol;
        }

        /// <summary>
        /// Performs division of polynomial on constant value
        /// </summary>
        /// <param name="pol">Polinomial</param>
        /// <param name="value">Value to divide</param>
        /// <returns>New polynomial with divition results</returns>
        public static Polynomial operator /(Polynomial pol, double value)
        {
            return CoefficientsModify((x) => x / value, pol);
        }

        /// <summary>
        /// Perform operation with coefficients of polynomial
        /// </summary>
        /// <param name="operation">Operation on coefficients</param>
        /// <param name="pol">Polynomial</param>
        /// <returns>New polynomial with operation results</returns>
        private static Polynomial CoefficientsModify(Func<double, double> operation, Polynomial pol)
        {
            double[] oldCoeff = pol.coefficients;
            double[] resultCoeff = new double[oldCoeff.Length];
            for (int i = 0; i < resultCoeff.Length; i++)
            {
                resultCoeff[i] = operation(oldCoeff[i]);
            }
            return new Polynomial(resultCoeff);
        }

        /// <summary>
        /// Compare contents of current polynomial and some object
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if contents of current polynomial and object are equal, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if ((object)this == obj)
            {
                return true;
            }
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            Polynomial polynomial = (Polynomial)obj;
            return coefficients.SequenceEqual(polynomial.coefficients);
        }

        /// <summary>
        /// Get hash code of current object
        /// </summary>
        /// <returns>Object hash code</returns>
        public override int GetHashCode()
        {
            int hash = 1;
            int hashBase = 31;
            unchecked
            {
                foreach (int coefficient in coefficients)
                {
                    hash = hash * hashBase + coefficient;
                }
            }
            return hash;
        }

        /// <summary>
        /// Get string format of current polynomial
        /// </summary>
        /// <returns>Polynomial string</returns>
        public override string ToString()
        {
            StringBuilder polynomStrBuilder = new StringBuilder();
            for (int i = 0; i < coefficients.Length; i++)
            {
                if (i == 0)
                {
                    polynomStrBuilder.Append($"{coefficients[i]}");
                }
                else
                {
                    polynomStrBuilder.Append($"+{coefficients[i]}x^{i}");
                }
            }
            return polynomStrBuilder.ToString();
        }
    }
}
