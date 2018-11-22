using System;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Provides methods for counting base bonus
    /// </summary>
    public class BaseBonus : IBonus
    {
        /// <summary>
        /// Current bonus score
        /// </summary>
        public int BonusScore { get; private set; } = 0;

        /// <summary>
        /// The amount to bonus multiplier
        /// </summary>
        protected int _multiplier { get; set; } = 10;

        /// <summary>
        /// Add bonus
        /// </summary>
        /// <param name="addAmount">The amount that was deposit to the account</param>
        public void AddBonus(decimal addAmount)
        {
            BonusScore += (int)Math.Truncate(addAmount * _multiplier);
        }

        /// <summary>
        /// Subtract bonus
        /// </summary>
        /// <param name="subAmount">The amount that was withdraw to the account</param>
        public void SubBonus(decimal subAmount)
        {
            BonusScore -= (int)Math.Truncate(subAmount * _multiplier);
        }
    }
}
