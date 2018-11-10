using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleExtensionLibrary
{
    /// <summary>
    /// Class provides extension method for double class that converts double value to binary string
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Converts double value to binary string (IEEE 745)
        /// </summary>
        /// <param name="value">Double value to convert</param>
        /// <returns>Binary string (IEEE 745)</returns>
        public static string ConvertDoubleToBinaryString(this double value)
        {
            string signBitStr = GetSignBitStr(value);
            string exponentaStr = GetExponentString(value, out double normalizedValue);
            string mantissaStr = GetMantissaString(normalizedValue);

            return signBitStr + exponentaStr + mantissaStr;
        }

        /// <summary>
        /// Get byte string of value sign
        /// </summary>
        /// <param name="value">Double value</param>
        /// <returns>Byte string of value sign</returns>
        private static string GetSignBitStr(double value)
        {
            if (value > 0 || (value == 0 && 1 / value > 0))
            {
                // Positive
                return "0";
            }
            else
            {
                // Negative
                return "1";
            }
        }

        /// <summary>
        /// Get byte string of exponent and normalize double value
        /// </summary>
        /// <param name="value">Double value</param>
        /// <param name="normalizedValue">Normalized double value</param>
        /// <returns>Byte string of exponent</returns>
        private static string GetExponentString(double value, out double normalizedValue)
        {
            const int ExponentBase = 2;
            const int InfinityExponent = 1024;
            const int DenormalizedExponent = -1022;

            value = Math.Abs(value);
            int exponenta = 0;
            if (double.IsInfinity(value))
            {
                // Infinity
                value = 0;
                exponenta = InfinityExponent;
            }
            else if (double.IsNaN(value))
            {
                // NaN
                exponenta = InfinityExponent;
            }
            else
            {
                // Count exponent
                if (value > 1)
                {
                    // Positive exponent
                    while (value > ExponentBase)
                    {
                        exponenta++;
                        value /= ExponentBase;
                    }
                }
                else
                {
                    // Negative exponent
                    while (value < 1)
                    {
                        exponenta--;
                        if (exponenta < DenormalizedExponent)
                        {
                            break;
                        }

                        value *= ExponentBase;
                    }
                }
            }

            normalizedValue = value;
            return ExponentaToString(exponenta);
        }

        /// <summary>
        /// Convert exponent count to binary sting
        /// </summary>
        /// <param name="exponenta">Exponent count</param>
        /// <returns>Binary string of exponent</returns>
        private static string ExponentaToString(int exponenta)
        {
            const int Bias = 1023;
            const int ExponentaFieldLength = 11;

            exponenta += Bias;
            StringBuilder exponentaStringBuilder = new StringBuilder();
            for (int i = 0; i < ExponentaFieldLength; i++)
            {
                exponentaStringBuilder.Insert(0, exponenta & 1);
                exponenta >>= 1;
            }

            return exponentaStringBuilder.ToString();
        }

        /// <summary>
        /// Get binary string of mantissa of normalized double value or denormalize if normalization isn't possible
        /// </summary>
        /// <param name="normalizedValue">Normalized double value or denormalize if normalization doesn't possible</param>
        /// <returns>Binary string of mantissa</returns>
        private static string GetMantissaString(double normalizedValue)
        {
            const int MantissaFieldLength = 52;
            const int Base = 2;

            if (normalizedValue >= Base || normalizedValue < 0)
            {
                throw new ArgumentOutOfRangeException("Argument must be positive normalized value");
            }

            bool isDenormalized = false;
            bool isNaN = false;
            StringBuilder mantissaStringBuilder = new StringBuilder();

            // Denormalize check
            if (normalizedValue < 1 && normalizedValue != 0)
            {
                isDenormalized = true;
            }
            else if (double.IsNaN(normalizedValue))
            {
                // Is NaN
                isNaN = true;
            }

            // Transform value to binary string
            normalizedValue -= 1;
            for (int i = 0; i < MantissaFieldLength; i++)
            {
                normalizedValue *= Base;
                if (normalizedValue >= 1 || (isNaN && i == 0) || (isDenormalized && i == MantissaFieldLength - 1))
                {
                    mantissaStringBuilder.Append(1);
                    if (normalizedValue >= 1)
                    {
                        normalizedValue -= 1;
                    }
                }
                else
                {
                    mantissaStringBuilder.Append(0);
                }
            }

            return mantissaStringBuilder.ToString();
        }
    }
}
