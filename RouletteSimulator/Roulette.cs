using System;
using System.Linq;

namespace RouletteSimulator
{
    public class Roulette
    {
        private readonly IResultGenerator resultGenerator;
        public Player Player { get; }

        public Roulette(IResultGenerator resultGenerator, double initialMoney)
        {
            this.resultGenerator = resultGenerator;
            
            Player = new Player();
            Player.AddMoney(initialMoney);
        }

        public void ProcessPlay(string input)
        {
            var inputAmount = input.Split(' ')[1];
            var inputBet = input.Split(' ')[0];

            if (double.TryParse(inputAmount, out var amount))
            {
                if (int.TryParse(inputBet, out var betNumber))
                    Player.CreateBetFor(betNumber, amount);
                else if (inputBet.Equals("red"))
                    Player.CreateBetFor(Colour.Red, amount);
                else if (inputBet.Equals("black"))
                    Player.CreateBetFor(Colour.Black, amount);
            }
            
            Play();
        }

        private void Play()
        {
            var result = resultGenerator.GenerateRandomResult();

            var moneyBack = Player.CurrentBets.Sum(bet => bet.CalculateAward(result));

            PrintResult(result);
            Player.AddMoney(moneyBack);
            Player.ClearBets();
        }

        private void PrintResult(int result) 
            => Console.WriteLine($"RESULT OF GAME: {ColourByNumberMapper.ColourByNumber(result)} - {result}");
    }
}