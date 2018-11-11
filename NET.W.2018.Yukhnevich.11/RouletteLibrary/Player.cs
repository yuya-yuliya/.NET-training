using System;

namespace RouletteLibrary
{
    /// <summary>
    /// Represents roulette player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Initialize new instance of class Player that has name and bet combination
        /// </summary>
        /// <param name="name">Player name</param>
        /// <param name="betCombination">Start bet combination</param>
        public Player(string name, RouletteCombination betCombination)
        {
            BetCombination = betCombination;
            Name = name;
        }

        /// <summary>
        /// Initialize new instance of class Player that has name and bet combination
        /// </summary>
        /// <param name="name">Player name</param>
        /// <param name="betCombination">Start bet combination</param>
        public Player(string name, Tuple<int, Roulette.Color> betCombination) : this(name, new RouletteCombination(betCombination))
        {
        }

        /// <summary>
        /// Initialize new instance of class Player that has name and standard bet combination (Zero)
        /// </summary>
        /// <param name="name">Player name</param>
        public Player(string name) : this(name, new RouletteCombination(0, Roulette.Color.Green))
        {
        }

        /// <summary>
        /// Current players' bet combination
        /// </summary>
        public RouletteCombination BetCombination { get; set; }

        /// <summary>
        /// Name of player
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Event handler to handle win of red bet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BetOnRed(object sender, RouletteEventArgs e)
        {
            Console.WriteLine($"{Name}: Bet on red won");
        }

        /// <summary>
        /// Event handler to handle win of black bet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BetOnBlack(object sender, RouletteEventArgs e)
        {
            Console.WriteLine($"{Name}: Bet on black won");
        }

        /// <summary>
        /// Event handler to handle win of zero bet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BetOnZero(object sender, RouletteEventArgs e)
        {
            Console.WriteLine($"{Name}: Bet on zero won");
        }

        /// <summary>
        /// Event handler to handle current roulette combination
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Bet(object sender, RouletteEventArgs e)
        {
            if (e.Combination == BetCombination)
            {
                Console.WriteLine($"{Name}: Bet {e.Combination.Number}, {e.Combination.Color} won");
            }
            else
            {
                Console.WriteLine($"{Name}: Bet {BetCombination.Number}, {BetCombination.Color} didn't win");
            }
        }
    }
}
