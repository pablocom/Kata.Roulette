using System;

namespace RouletteSimulator
{
    public class Roulette
    {
        public Player Player { get; private set; }

        public Roulette()
        {
            Player = new Player();
            Player.AddMoney(60);
        }

        public void Play()
        {
            var result = GenerateRandomResult();

            var moneyBack = 0d;
            foreach (var bet in Player.CurrentBets) 
                moneyBack += bet.CalculateAward(result);

            Player.AddMoney(moneyBack);
            PrintResult(result);

            Player.ClearBets();
        }

        private void PrintResult(int result)
        {
            Console.WriteLine($"RESULT OF GAME: {ColourByNumberMapper.GetColourByNumber(result)} - {result}");
        }

        private static int GenerateRandomResult()
        {
            return new Random().Next(0, 36);
        }
    }
}