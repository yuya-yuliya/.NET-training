using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLibrary
{
    public class Converter
    {
        public static string ConvertDoubleToBinaryString(double value)
        {
            string signBitStr = GetSignBitStr(value);
            string exponentaStr = GetExponentString(value, out double normalizedValue);
            string mantissaStr = GetMantissaString(normalizedValue);

            return signBitStr + exponentaStr + mantissaStr;
        }

        private static string GetSignBitStr(double value)
        {
            if (value > 0 || (value == 0 && 1 / value > 0))
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }

        private static string GetExponentString(double value, out double normalizedValue)
        {
            const int ExponentBase = 2;
            const int Bias = 1023;
            const int InfinityExponent = 1024;
            const int DenormalizedExponent = -1022;

            value = Math.Abs(value);
            int exponenta = 0;
            if (double.IsInfinity(value))
            {
                value = 0;
                exponenta = InfinityExponent;
            }
            else if (double.IsNaN(value))
            {
                exponenta = InfinityExponent;
            }
            else
            {
                if (value > 1)
                {
                    while (value > ExponentBase)
                    {
                        exponenta++;
                        value /= ExponentBase;
                    }
                }
                else
                {
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
            return ExponentaToString(exponenta + Bias);
        }

        private static string ExponentaToString(int exponenta)
        {
            const int ExponentaFieldLength = 11;

            StringBuilder exponentaStringBuilder = new StringBuilder();
            for (int i = 0; i < ExponentaFieldLength; i++)
            {
                exponentaStringBuilder.Insert(0, exponenta & 1);
                exponenta >>= 1;
            }
            return exponentaStringBuilder.ToString();
        }

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
            if (normalizedValue < 1 && normalizedValue != 0)
            {
                isDenormalized = true;
            }
            else if (double.IsNaN(normalizedValue))
            {
                isNaN = true;
            }
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
