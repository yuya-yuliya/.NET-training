using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class BaseBonus : IBonus
    {
        protected int Multipluer = 10;

        public int BonusScore { get; private set; } = 0;

        public void AddBonus(decimal addAmount)
        {
            BonusScore += (int)Math.Truncate(addAmount * Multipluer);
        }

        public void SubBonus(decimal subAmount)
        {
            BonusScore -= (int)Math.Truncate(subAmount * Multipluer);
        }
    }
}
