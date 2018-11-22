using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Provides methods for counting platinum bonus
    /// </summary>
    public class PlatinumBonus : BaseBonus, IBonus
    {
        /// <summary>
        /// Initialize new instance of PlatinumBonus class
        /// </summary>
        public PlatinumBonus()
        {
            this._multiplier = 100;
        }
    }
}
