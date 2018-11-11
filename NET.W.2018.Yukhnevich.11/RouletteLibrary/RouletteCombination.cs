using System;

namespace RouletteLibrary
{
    public class RouletteCombination
    {
        /// <summary>
        /// Minimum roulette number
        /// </summary>
        public const int MinNumber = 0;

        /// <summary>
        /// Maximum roulette number
        /// </summary>
        public const int MaxNumber = 36;

        /// <summary>
        /// Color of Zero cell
        /// </summary>
        public const Roulette.Color ZeroColor = Roulette.Color.Green;

        /// <summary>
        /// Current combination number
        /// </summary>
        private int _number;

        /// <summary>
        /// Current combination color
        /// </summary>
        private Roulette.Color _color;

        /// <summary>
        /// Initialize new instance of RouletteCombination with given number and color of roulette combination
        /// </summary>
        /// <param name="number">Number of roulette combination</param>
        /// <param name="color">Color of current roulette combination</param>
        public RouletteCombination(int number, Roulette.Color color) : base()
        {
            this.Number = number;
            this.Color = color;
        }

        /// <summary>
        /// Initialize new instance of RouletteCombination with given number and color of roulette combination
        /// </summary>
        /// <param name="combination">Tuple of number and color of roulette combination</param>
        public RouletteCombination(Tuple<int, Roulette.Color> combination) : this(combination.Item1, combination.Item2)
        {
        }

        /// <summary>
        /// Number of roulette combination
        /// </summary>
        public int Number
        {
            get => this._number;
            set
            {
                if (MinNumber > value || MaxNumber < value)
                {
                    throw new RouletteCombinationException($"Roulette hasn't got {value} number", new ArgumentOutOfRangeException());
                }

                this._number = value;
            }
        }

        /// <summary>
        /// Color of roulette combination
        /// </summary>
        public Roulette.Color Color
        {
            get => this._color;
            set
            {
                if (this.Number == 0 && value != ZeroColor)
                {
                    throw new RouletteCombinationException($"Combination {Number} {value} doesn't exsist");
                }

                this._color = value;
            }
        }
    }
}
