using System.Collections.Generic;
using System.Linq;

namespace BLL.Mappers
{
    /// <summary>
    /// Provides method for mapping account type to bonus type
    /// </summary>
    public class AccountTypeMapper
    {
        /// <summary>
        /// Dictionary of account type mapping
        /// </summary>
        private static Dictionary<DAL.Interface.DTO.AccountType, Interface.Entities.AccountType> typeMap = new Dictionary<DAL.Interface.DTO.AccountType, Interface.Entities.AccountType>
        {
            [DAL.Interface.DTO.AccountType.Base] = Interface.Entities.AccountType.Base,
            [DAL.Interface.DTO.AccountType.Silver] = Interface.Entities.AccountType.Silver,
            [DAL.Interface.DTO.AccountType.Gold] = Interface.Entities.AccountType.Gold,
            [DAL.Interface.DTO.AccountType.Platinum] = Interface.Entities.AccountType.Platinum
        };

        /// <summary>
        /// Gets business later account type corresponding to data layer account type
        /// </summary>
        /// <param name="accountType">Data layer account type</param>
        /// <returns>Business layer account type</returns>
        public static Interface.Entities.AccountType GetBusinessAccountType(DAL.Interface.DTO.AccountType accountType)
        {
            if (typeMap.TryGetValue(accountType, out Interface.Entities.AccountType bonus))
            {
                return bonus;
            }
            else
            {
                return Interface.Entities.AccountType.Unknown;
            }
        }

        /// <summary>
        /// Gets data later account type corresponding to business layer account type
        /// </summary>
        /// <param name="accountType">Business layer account type</param>
        /// <returns>Data layer account type</returns>
        public static DAL.Interface.DTO.AccountType GetDataAccountType(Interface.Entities.AccountType accountType)
        {
            return typeMap.FirstOrDefault(t => t.Value == accountType).Key;
        }
    }
}
