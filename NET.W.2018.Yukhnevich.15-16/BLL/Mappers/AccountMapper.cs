using System;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Provides methods for mapping Account class instances
    /// </summary>
    public class AccountMapper
    {
        /// <summary>
        /// Maps information from instance of Account from business layer to data layer
        /// </summary>
        /// <param name="account">The business layer account</param>
        /// <returns>The data layer account</returns>
        public static Account MapToData(Interface.Entities.Account account)
        {
            return new Account(
                account.AccountNumber, 
                ParseOwner(account.AccountOwner), 
                AccountTypeMapper.GetDataAccountType(account.AccountType))
            {
                BonusCount = account.BonusCount
            };
        }

        /// <summary>
        /// Maps information from instance of Account from data layer to business layer
        /// </summary>
        /// <param name="account">The data layer account</param>
        /// <returns>The business layer account</returns>
        public static Interface.Entities.Account MapToBusiness(Account account)
        {
            return new Interface.Entities.Account(
                account.AccountNumber,
                account.AccountOwner.ToString(),
                AccountTypeMapper.GetBusinessAccountType(account.AccountType))
            {
                BonusCount = account.BonusCount
            };
        }

        /// <summary>
        /// Parse owner string to the instance of Owner class
        /// </summary>
        /// <param name="ownerStr">The owner string</param>
        /// <returns>The instance of Owner class</returns>
        private static Owner ParseOwner(string ownerStr)
        {
            string separator = " ";
            string[] ownerNameParts = ownerStr.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (ownerNameParts.Length < 2)
            {
                throw new ArgumentException("Owner must have first and last names separeted by space");
            }

            string[] secondNameParts = new string[ownerNameParts.Length - 1];
            Array.Copy(ownerNameParts, 1, secondNameParts, 0, secondNameParts.Length);
            string secondName = string.Join(separator, secondNameParts);
            return new Owner(ownerNameParts[0], secondName);
        }
    }
}
