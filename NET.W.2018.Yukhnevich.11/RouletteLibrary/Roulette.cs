using System;

namespace RouletteLibrary
{
    /// <summary>
    /// Represents the roulette
    /// </summary>
    public class Roulette
    {
        /// <summary>
        /// Count of roulette different numbers
        /// </summary>
        private const int CountNumbers = 37;

        /// <summary>
        /// Random generator of numbers
        /// </summary>
        private Random _random;

        /// <summary>
        /// Initialize new instance of Roulette class
        /// </summary>
        public Roulette()
        {
            _random = new Random();
        }

        /// <summary>
        /// Delegate for bet handling
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Current roulette combination</param>
        public delegate void BetHandler(object sender, RouletteEventArgs e);

        /// <summary>
        /// Event on change current roulette combination
        /// </summary>
        public event BetHandler Bet;

        /// <summary>
        /// Event on win bet on red
        /// </summary>
        public event BetHandler BetOnRed;

        /// <summary>
        /// Event on win bet on black
        /// </summary>
        public event BetHandler BetOnBlack;

        /// <summary>
        /// Event on win bet on zero
        /// </summary>
        public event BetHandler BetOnZero;

        /// <summary>
        /// Represents colors of roulette cells
        /// </summary>
        public enum Color
        {
            Red,
            Black,
            Green
        }

        /// <summary>
        /// Spins wheel
        /// </summary>
        /// <returns>Win roulette combination</returns>
        public virtual Tuple<int, Color> SpinWheel()
        {
            int number = GenerateNumber();
            Color color;
            if (number == 0)
            {
                color = Color.Green;
            }
            else
            {
                color = GenerateColor();
            }

            RouletteEventArgs rouletteEventArgs = new RouletteEventArgs(number, color);
            OnBet(this, rouletteEventArgs);
            switch (color)
            {
                case Color.Black:
                    OnBetOnBlack(this, rouletteEventArgs);
                    break;
                case Color.Green:
                    OnBetOnZero(this, rouletteEventArgs);
                    break;
                case Color.Red:
                    OnBetOnRed(this, rouletteEventArgs);
                    break;
            }

            return new Tuple<int, Color>(number, color);
        }

        /// <summary>
        /// Notify subscribers about changing win combination
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnBet(object sender, RouletteEventArgs e)
        {
            Bet?.Invoke(this, e);
        }

        /// <summary>
        /// Notify subscribers about win of red bet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnBetOnRed(object sender, RouletteEventArgs e)
        {
            BetOnRed?.Invoke(this, e);
        }

        /// <summary>
        /// Notify subscribers about win of black bet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnBetOnBlack(object sender, RouletteEventArgs e)
        {
            BetOnBlack?.Invoke(this, e);
        }

        /// <summary>
        /// Notify subscribers about win of zero bet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnBetOnZero(object sender, RouletteEventArgs e)
        {
            BetOnZero?.Invoke(this, e);
        }

        /// <summary>
        /// Generate new roulette number
        /// </summary>
        /// <returns></returns>
        private int GenerateNumber()
        {
            return Math.Abs(_random.Next() % CountNumbers);
        }

        /// <summary>
        /// Generate new roulette color
        /// </summary>
        /// <returns></returns>
        private Color GenerateColor()
        {
            Color[] colors = { Color.Red, Color.Black };
            return colors[Math.Abs(_random.Next() % colors.Length)];
        }
    }
}
