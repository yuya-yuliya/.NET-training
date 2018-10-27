namespace BankAccountLibrary.Bonus
{
    public class BaseBonus : IBonus
    {
        public int BonusCount { get; internal set; }
        private int additionCount = 5;
        private int subtitutionCount = 3;

        public BaseBonus()
        { }

        internal BaseBonus(int bonusCount)
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
            BaseBonus bonus = new BaseBonus();
            bonus.BonusCount = BonusCount;
            return bonus;
        }

        public override string ToString()
        {
            return "Base";
        }
    }
}
