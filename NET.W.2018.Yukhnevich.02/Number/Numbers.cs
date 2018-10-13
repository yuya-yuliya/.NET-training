using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number
{
    /// <summary>
    /// Class provides method to insert range of bits from other 32-bits number 
    /// </summary>
    public class Numbers
    {

        private const int BitsInByte = 8;

        /// <summary>
        /// Insert range of bits from one number to other
        /// </summary>
        /// <param name="numberSource">Source of insert bits</param>
        /// <param name="numberIn">Number for insert in</param>
        /// <param name="startBit">Start range of bits</param>
        /// <param name="endBit">End range of bits</param>
        /// <returns>Number with insert bits</returns>
        public static int InsertNumber(int numberSource, int numberIn, int startBit, int endBit)
        {
            if (endBit < startBit)
            {
                throw new ArgumentException("Value of endBit mustn't be less than startBit");
            }
            if (endBit >= sizeof(int) * BitsInByte || startBit >= sizeof(int) * BitsInByte || endBit < 0 || startBit < 0 )
            {
                throw new ArgumentException("Start and end bits must be positive and less than " + sizeof(int) * BitsInByte);
            }
            for (int i = startBit; i <= endBit; i++)
            {
                numberSource = numberSource & ~(1 << i) | ((numberIn & 1) << i);
                numberIn >>= 1;
            }

            return numberSource;
        }
    }
}
