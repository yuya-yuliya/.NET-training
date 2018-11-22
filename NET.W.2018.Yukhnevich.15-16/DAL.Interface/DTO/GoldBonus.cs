using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Provides methods for counting gold bonus
    /// </summary>
    public class GoldBonus : BaseBonus, IBonus
    {
        /// <summary>
        /// Initialize new instance of GoldBonus class
        /// </summary>
        public GoldBonus()
        {
            this._multiplier = 50;
        }
    }
}
