using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class SilverBonus : BaseBonus, IBonus
    {
        public SilverBonus()
        {
            Multipluer = 20;
        }
    }
}
