using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IBonus
    {
        int BonusScore { get; }
        void AddBonus(decimal addAmount);
        void SubBonus(decimal subAmount);
    }
}
