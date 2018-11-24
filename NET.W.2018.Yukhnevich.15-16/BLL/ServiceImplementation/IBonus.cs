namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Provides methods for counting bonus
    /// </summary>
    public interface IBonus
    {
        /// <summary>
        /// Gets bonus score for adding
        /// </summary>
        /// <param name="amount">The deposit amount</param>
        /// <returns>The bonus score</returns>
        int GetAddBonus(decimal amount);

        /// <summary>
        /// Gets bonus score for subtracting
        /// </summary>
        /// <param name="amount">The withdraw amount</param>
        /// <returns>The bonus score</returns>
        int GetSubBonus(decimal amount);
    }
}
