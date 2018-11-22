using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Provides methods for counting silver bonus
    /// </summary>
    public class SilverBonus : BaseBonus, IBonus
    {
        /// <summary>
        /// Initialize new instance of SilverBonus class
        /// </summary>
        public SilverBonus()
        {
            this._multiplier = 20;
        }
    }
}
