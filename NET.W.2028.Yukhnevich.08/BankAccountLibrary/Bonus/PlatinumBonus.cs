namespace BankAccountLibrary.Bonus
{
    public class PlatinumBonus : IBonus
    {
        public int BonusCount { get; internal set; }
        private int additionCount = 20;
        private int subtitutionCount = 15;

        public PlatinumBonus()
        { }

        internal PlatinumBonus(int bonusCount)
        {
            BonusCount = bonusCount;
        }

        public void AddBonus()
        {
            BonusCount += additionCount;
        }

        public void SubBonus()
        {
            BonusCount -= subtitutionCount;
        }

        public object Clone()
        {
            PlatinumBonus bonus = new PlatinumBonus();
            bonus.BonusCount = BonusCount;
            return bonus;
        }

        public override string ToString()
        {
            return "Platinum";
        }
    }
}
