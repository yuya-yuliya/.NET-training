using System.Collections.Generic;

namespace BankAccountLibrary.Bonus
{
    public class BonusCreator
    {
        public static IBonus Create(string bonusType, int bonusCount)
        {
            Dictionary<string, IBonus> pairs = new Dictionary<string, IBonus>
            {
                [typeof(BaseBonus).ToString()] = new BaseBonus(bonusCount),
                [typeof(GoldBonus).ToString()] = new GoldBonus(bonusCount),
                [typeof(PlatinumBonus).ToString()] = new PlatinumBonus(bonusCount)
            };
            return pairs[bonusType];
        }
    }
}
