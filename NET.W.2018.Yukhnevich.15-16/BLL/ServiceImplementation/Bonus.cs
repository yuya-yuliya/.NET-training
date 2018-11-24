using System;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Provides methods for counting bonus score
    /// </summary>
    public class Bonus : IBonus
    {
        /// <summary>
        /// Initialize new instance of Bonus class with given multiplier
        /// </summary>
        /// <param name="multiplier">The bonus multiplier</param>
        public Bonus(int multiplier)
        {
            Multiplier = multiplier;
        }

        /// <summary>
        /// The bonus multiplier
        /// </summary>
        public int Multiplier { get; }

        /// <summary>
        /// Gets bonus score for adding
        /// </summary>
        /// <param name="amount">The deposit amount</param>
        /// <returns>The bonus score</returns>
        public int GetAddBonus(decimal amount)
        {
            return (int)Math.Truncate(amount * Multiplier);
        }

        /// <summary>
        /// Gets bonus score for subtracting
        /// </summary>
        /// <param name="amount">The withdraw amount</param>
        /// <returns>The bonus score</returns>
        public int GetSubBonus(decimal amount)
        {
            return (int)Math.Truncate(amount * Multiplier);
        }
    }
}
