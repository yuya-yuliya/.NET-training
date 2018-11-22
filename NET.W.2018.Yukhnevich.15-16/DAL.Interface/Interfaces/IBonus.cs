namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Provides methods for counting bonus
    /// </summary>
    public interface IBonus
    {
        /// <summary>
        /// Gets current bonus score
        /// </summary>
        int BonusScore { get; }

        /// <summary>
        /// Add bonus
        /// </summary>
        /// <param name="addAmount">The amount that was deposit to the account</param>
        void AddBonus(decimal addAmount);

        /// <summary>
        /// Subtract bonus
        /// </summary>
        /// <param name="subAmount">The amount that was withdraw to the account</param>
        void SubBonus(decimal subAmount);
    }
}
