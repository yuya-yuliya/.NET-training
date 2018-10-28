namespace BankAccountLibrary.Bonus
{
    /// <summary>
    /// Class represents bonus of platinum account
    /// </summary>
    public class PlatinumBonus : IBonus
    {
        /// <summary>
        /// Count of bonus
        /// </summary>
        public int BonusCount { get; internal set; }
        private int additionCount = 20;
        private int subtitutionCount = 15;

        /// <summary>
        /// Initialize a new instance of bonus
        /// </summary>
        public PlatinumBonus()
        { }

        /// <summary>
        /// Initialize a new instance with start count of bonus
        /// </summary>
        /// <param name="bonusCount">Start count of bonus</param>
        internal PlatinumBonus(int bonusCount)
        {
            BonusCount = bonusCount;
        }

        /// <summary>
        /// Add bonus points
        /// </summary>
        public void AddBonus()
        {
            BonusCount += additionCount;
        }

        /// <summary>
        /// Subtract bonus points
        /// </summary>
        public void SubBonus()
        {
            BonusCount -= subtitutionCount;
        }

        /// <summary>
        /// Get string representation
        /// </summary>
        /// <returns>Name of account bonus</returns>
        public override string ToString()
        {
            return "Platinum";
        }
    }
}
