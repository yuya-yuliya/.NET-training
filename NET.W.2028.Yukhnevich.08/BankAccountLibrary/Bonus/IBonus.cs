using System;

namespace BankAccountLibrary.Bonus
{
    /// <summary>
    /// Represents bonus of bank account
    /// </summary>
    public interface IBonus
    {
        /// <summary>
        /// Count of bonus
        /// </summary>
        int BonusCount { get; }

        /// <summary>
        /// Add bonus points
        /// </summary>
        void AddBonus();

        /// <summary>
        /// Subtract bonus points
        /// </summary>
        void SubBonus();
    }
}
