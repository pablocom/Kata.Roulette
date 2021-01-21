using System;
using System.Collections.Generic;

namespace RouletteSimulator
{
    public class Player
    {
        public ICollection<Bet> CurrentBets { get; private set; } = new List<Bet>();
        public double ActualMoney { get; private set; }

        public Player()
        {
        }

        public void AddMoney(double amount)
        {
            ActualMoney += amount;
        }

        public void CreateBetFor(int betNumber, double amount)
        {
            if (amount > ActualMoney)
                throw new ArgumentException("Actual money is less than requested to bet");
            
            var bet = NumberBet.CreateNumberBet(betNumber, amount);
            CurrentBets.Add(bet);
            
            ActualMoney -= amount;
        }
        
        public void CreateBetFor(Colour colour, double amount)
        {
            if (amount > ActualMoney)
                throw new ArgumentException("Actual money is less than requested to bet");

            var bet = new ColourBet(colour, amount);
            CurrentBets.Add(bet);
            
            ActualMoney -= amount;
        }

        public void ClearBets()
        {
            CurrentBets.Clear();
        }
    }
}