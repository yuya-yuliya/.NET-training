namespace BankAccountLibrary.Bonus
{
    public class GoldBonus : IBonus
    {
        public int BonusCount { get; internal set; }
        private int additionCount = 10;
        private int subtitutionCount = 6;

        public GoldBonus()
        { }

        internal GoldBonus(int bonusCount)
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
            GoldBonus bonus = new GoldBonus();
            bonus.BonusCount = BonusCount;
            return bonus;
        }

        public override string ToString()
        {
            return "Gold";
        }
    }
}
