using System;

namespace RootLibrary
{
    /// <summary>
    /// Class provides method to find Nth root of number with given precision
    /// </summary>
    public class FindRoot
    {
        /// <summary>
        /// Find Nth root of number with given precision
        /// </summary>
        /// <remarks>
        /// Use Newton's method
        /// </remarks>
        /// <param name="number">Number</param>
        /// <param name="degree">Degree of root</param>
        /// <param name="delta">Precision</param>
        /// <returns>Root of number with given precision</returns>
        public static double FindNthRoot(double number, int degree, double delta)
        {
            if (delta < 0)
            {
                throw new ArgumentOutOfRangeException("Delta must be positive number");
            }

            if (degree < 0)
            {
                throw new ArgumentOutOfRangeException("Degree must be positive integer number");
            }

            double xOld = 0, xNew = number / degree;
            do
            {
                xOld = xNew;
                xNew = (((degree - 1) * xOld) + (number / Math.Pow(xOld, degree - 1))) / degree;
            }
            while (Math.Abs(xNew - xOld) >= delta);
            
            return xNew;
        }
    }
}
