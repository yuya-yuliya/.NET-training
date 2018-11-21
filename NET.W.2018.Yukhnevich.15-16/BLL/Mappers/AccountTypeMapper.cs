using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

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
        private Dictionary<AccountType, IBonus> bonusMap = new Dictionary<AccountType, IBonus>
        {
            [AccountType.Base] = new BaseBonus(),
            [AccountType.Silver] = new SilverBonus(),
            [AccountType.Gold] = new GoldBonus(),
            [AccountType.Platinum] = new PlatinumBonus()
        };

        /// <summary>
        /// Creates instance of class implemented IBonus interface that's match the account type
        /// </summary>
        /// <param name="accountType">Type of account</param>
        /// <returns>Instance of class implemented IBonus interface if for current account type bonus exists, otherwise null</returns>
        public IBonus CreateBonus(AccountType accountType)
        {
            try
            {
                return bonusMap[accountType];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}
