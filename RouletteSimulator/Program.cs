using System;

namespace RouletteSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO ROULETTE SIMULATOR!");
            Console.WriteLine();

            var roulette = new Roulette();
            while (roulette.Player.ActualMoney > 0)
            {
                Console.WriteLine($"Current money: {roulette.Player.ActualMoney:N} euros");
                Console.WriteLine("What is going to be your next bet? (Red, Black, 6, 17...)");
                Console.WriteLine("Format -> {number or colour} {amount}");
                
                try
                {
                    var input = Console.ReadLine();
                    roulette.ProcessPlay(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Something went wrong, please try again with the correct format.");
                }
                
                Console.WriteLine("-----------------------------------------------------");
            }
        }
    }
}