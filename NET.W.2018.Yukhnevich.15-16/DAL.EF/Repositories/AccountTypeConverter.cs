using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;

namespace DAL.EF.Repositories
{
    /// <summary>
    /// Provides methods for converting account types to database string
    /// </summary>
    internal class AccountTypeConverter
    {
        /// <summary>
        /// Dictionary for converting
        /// </summary>
        private static Dictionary<string, AccountType> accountTypeDict = new Dictionary<string, AccountType>
        {
            { "Base", AccountType.Base },
            { "Silver", AccountType.Silver },
            { "Gold", AccountType.Gold },
            { "Platinum", AccountType.Platinum }
        };

        /// <summary>
        /// Converts string from database to account type
        /// </summary>
        /// <param name="accountTypeString">The account type string</param>
        /// <returns>The type of account</returns>
        internal static AccountType StringToAccountType(string accountTypeString)
        {
            return accountTypeDict[accountTypeString];
        }

        /// <summary>
        /// Converts account type to string representation
        /// </summary>
        /// <param name="accountType">The type of account</param>
        /// <returns>The string representation of account type</returns>
        internal static string AccountTypeToString(AccountType accountType)
        {
            return accountTypeDict.FirstOrDefault(a => a.Value == accountType).Key;
        }
    }
}
