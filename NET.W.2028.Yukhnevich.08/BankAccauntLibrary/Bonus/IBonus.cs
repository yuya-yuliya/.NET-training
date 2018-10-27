using System;

namespace BankAccountLibrary.Bonus
{
    public interface IBonus : ICloneable
    {
        int BonusCount { get; }
        void AddBonus();
        void SubBonus();
    }
}
