using System;

namespace RouletteSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var roulette = new Roulette();
            
            Console.WriteLine("WELCOME TO ROULETTE SIMULATOR!");
            Console.WriteLine();

            while (roulette.Player.ActualMoney > 0)
            {
                Console.WriteLine($"Current money: {roulette.Player.ActualMoney:N} euros");
                Console.WriteLine("What is going to be your next bet? (Red, Black, 6, 17...)");
                Console.WriteLine("Format -> {number or colour} {amount}");
                var input = Console.ReadLine();

                var inputAmount = input.Split(' ')[1];
                var inputBet = input.Split(' ')[0];

                if (double.TryParse(inputAmount, out double amount))
                {
                    if (int.TryParse(inputBet, out int betNumber))
                    {
                        roulette.Player.CreateBetFor(betNumber, amount);
                    }
                    else if (inputBet.Equals("Red", StringComparison.InvariantCultureIgnoreCase))
                    {
                        roulette.Player.CreateBetFor(Colour.Red, amount);
                    }
                    
                    else if (inputBet.Equals("Black", StringComparison.InvariantCultureIgnoreCase))
                    {
                        roulette.Player.CreateBetFor(Colour.Black, amount);
                    }
                }
                
                roulette.Play();
                
                Console.WriteLine("-----------------------------------------------------");
            }
        }
    }
}