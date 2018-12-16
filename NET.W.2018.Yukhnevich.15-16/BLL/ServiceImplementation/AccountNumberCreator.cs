using System;
using System.Security.Cryptography;
using System.Text;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Provides method for generate account number
    /// </summary>
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        /// <summary>
        /// Gets account number
        /// </summary>
        /// <returns>String represent account number</returns>
        public string GetNumber()
        {
            return GetHash(DateTime.Now.ToString());
        }

        /// <summary>
        /// Gets hash SHA-1 of the string
        /// </summary>
        /// <param name="str">String for hashing</param>
        /// <returns>Hash string</returns>
        private string GetHash(string str)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hashBytes = sha1.ComputeHash(Encoding.ASCII.GetBytes(str));
                return HexStringFromBytes(hashBytes);
            }
        }

        /// <summary>
        /// Gets string of 16 base numbers from bytes array
        /// </summary>
        /// <param name="bytes">The array of bytes</param>
        /// <returns>The string of 16 base numbers</returns>
        private string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }

            return sb.ToString();
        }
    }
}
