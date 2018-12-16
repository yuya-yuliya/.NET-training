using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Provides methods for getting bonus
    /// </summary>
    public class BonusCounter
    {
        /// <summary>
        /// Dictionary of bonus multipliers
        /// </summary>
        private Dictionary<AccountType, int> _bonusMultipliers = new Dictionary<AccountType, int>
        {
            [AccountType.Base] = 10,
            [AccountType.Silver] = 20,
            [AccountType.Gold] = 50,
            [AccountType.Platinum] = 100
        };

        /// <summary>
        /// Gets instance of class implements IBonus interface corresponding to account type
        /// </summary>
        /// <param name="accountType">The account type</param>
        /// <returns>The instance of class implements IBonus interface</returns>
        public IBonus GetBonus(AccountType accountType)
        {
            return new Bonus(_bonusMultipliers[accountType]);
        }
    }
}
