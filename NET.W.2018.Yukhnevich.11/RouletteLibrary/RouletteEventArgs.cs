using System;

namespace RouletteLibrary
{
    /// <summary>
    /// Represents roulette combination for event handlers
    /// </summary>
    public class RouletteEventArgs : EventArgs
    {
        /// <summary>
        /// Roulette combination
        /// </summary>
        public readonly RouletteCombination Combination;

        /// <summary>
        /// Initialize new instance of RouletteEventArgs with given number and color of roulette combination
        /// </summary>
        /// <param name="number">Number of roulette combination</param>
        /// <param name="color">Color of current roulette combination</param>
        public RouletteEventArgs(int number, Roulette.Color color) : base()
        {
            this.Combination = new RouletteCombination(number, color);
        }

        /// <summary>
        /// Initialize new instance of RouletteEventArgs with given number and color of roulette combination
        /// </summary>
        /// <param name="combination">Tuple of number and color of roulette combination</param>
        public RouletteEventArgs(Tuple<int, Roulette.Color> combination) : this(combination.Item1, combination.Item2)
        {
        }

        /// <summary>
        /// Initialize new instance of RouletteEventArgs with given roulette combination
        /// </summary>
        /// <param name="combination">Roulette combination</param>
        public RouletteEventArgs(RouletteCombination combination)
        {
            this.Combination = combination;
        }
    }
}
