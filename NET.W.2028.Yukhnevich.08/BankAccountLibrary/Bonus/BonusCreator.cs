using System;
using System.Collections.Generic;

namespace BankAccountLibrary.Bonus
{
    /// <summary>
    /// Class provides method to cteate bonus of bank account with start amount
    /// </summary>
    public class BonusCreator
    {
        /// <summary>
        /// Cteate bonus of bank account with start amount
        /// </summary>
        /// <param name="bonusType">Type of bonus</param>
        /// <param name="bonusCount">Start bonus amount</param>
        /// <returns>Instance of account bonus</returns>
        /// <exception cref="ArgumentException">No such type of bonus</exception>
        public static IBonus Create(string bonusType, int bonusCount)
        {
            Dictionary<string, IBonus> pairs = new Dictionary<string, IBonus>
            {
                [typeof(BaseBonus).ToString()] = new BaseBonus(bonusCount),
                [typeof(GoldBonus).ToString()] = new GoldBonus(bonusCount),
                [typeof(PlatinumBonus).ToString()] = new PlatinumBonus(bonusCount)
            };
            if (pairs.TryGetValue(bonusType, out IBonus bonus))
            {
                return bonus;
            }
            throw new ArgumentException($"There is no {bonusType} type of bonus");
        }
    }
}
