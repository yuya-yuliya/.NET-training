namespace BankAccountLibrary.Bonus
{
    /// <summary>
    /// Class represents bonus of base account
    /// </summary>
    public class BaseBonus : IBonus
    {
        private int additionCount = 5;
        private int subtitutionCount = 3;

        /// <summary>
        /// Initialize a new instance of bonus
        /// </summary>
        public BaseBonus()
        {
        }

        /// <summary>
        /// Initialize a new instance with start count of bonus
        /// </summary>
        /// <param name="bonusCount">Start count of bonus</param>
        internal BaseBonus(int bonusCount)
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
            return "Base";
        }
    }
}
