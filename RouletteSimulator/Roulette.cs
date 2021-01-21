using System;
using System.Linq;

namespace RouletteSimulator
{
    public class Roulette
    {
        public Player Player { get; }

        public Roulette()
        {
            Player = new Player();
            Player.AddMoney(60);
        }

        public void ProcessPlay(string input)
        {
            var inputAmount = input.Split(' ')[1];
            var inputBet = input.Split(' ')[0];

            if (double.TryParse(inputAmount, out var amount))
            {
                if (int.TryParse(inputBet, out var betNumber))
                    Player.CreateBetFor(betNumber, amount);
                else if (inputBet.Equals("Red", StringComparison.InvariantCultureIgnoreCase))
                    Player.CreateBetFor(Colour.Red, amount);
                else if (inputBet.Equals("Black", StringComparison.InvariantCultureIgnoreCase))
                    Player.CreateBetFor(Colour.Black, amount);
            }
            
            Play();
        }

        private void Play()
        {
            var result = GenerateRandomResult();

            var moneyBack = Player.CurrentBets.Sum(bet => bet.CalculateAward(result));

            PrintResult(result);
            Player.AddMoney(moneyBack);
            Player.ClearBets();
        }

        private static int GenerateRandomResult() => new Random().Next(0, 36);

        private void PrintResult(int result) 
            => Console.WriteLine($"RESULT OF GAME: {ColourByNumberMapper.ColourByNumber(result)} - {result}");
    }
}