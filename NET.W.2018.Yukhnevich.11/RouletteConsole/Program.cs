using System;
using RouletteLibrary;

namespace RouletteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");
            Player player3 = new Player("Player3");
            Player player4 = new Player("Player4", new Tuple<int, Roulette.Color>(5, Roulette.Color.Black));

            Roulette roulette = new Roulette();
            roulette.Bet += player4.Bet;
            roulette.BetOnBlack += player1.BetOnBlack;
            roulette.BetOnRed += player2.BetOnRed;
            roulette.BetOnZero += player3.BetOnZero;

            for (int i = 0; i < 5; i++)
            {
                Tuple<int, Roulette.Color> bet = roulette.SpinWheel();
                Console.WriteLine($"Won the bet {bet.Item1} {bet.Item2}");
            }
            Console.ReadLine();
        }
    }
}
