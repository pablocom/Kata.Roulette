using System;

namespace RouletteSimulator
{
    public class NumberBet : Bet
    {
        public int BetNumber { get; }

        private NumberBet(int betNumber, double moneyBet) : base(moneyBet)
        {
            if (betNumber < 0 || betNumber > 36)
                throw new ArgumentException("Number you tried to bet for is out of range");
            
            BetNumber = betNumber;
            Colour = ColourByNumberMapper.ColourByNumber(betNumber);
        }
        
        public static NumberBet CreateNumberBet(int betNumber, double amount)
        {
            return new(betNumber, amount);
        }

        public override double CalculateAward(int result)
        {
            if (BetNumber == result)
                return MoneyBet * 36;
            
            return 0;
        }
    }
}