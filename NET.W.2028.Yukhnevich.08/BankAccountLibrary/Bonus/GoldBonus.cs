namespace BankAccountLibrary.Bonus
{
    /// <summary>
    /// Class represents bonus of gold account
    /// </summary>
    public class GoldBonus : IBonus
    {
        private int additionCount = 10;
        private int subtitutionCount = 6;

        /// <summary>
        /// Initialize a new instance of bonus
        /// </summary>
        public GoldBonus()
        {
        }

        /// <summary>
        /// Initialize a new instance with start count of bonus
        /// </summary>
        /// <param name="bonusCount">Start count of bonus</param>
        internal GoldBonus(int bonusCount)
        {
            BonusCount = bonusCount;
        }

        /// <summary>
        /// Count of bonus
        /// </summary>
        public int BonusCount { get; internal set; }

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
            return "Gold";
        }
    }
}
