namespace RouletteSimulator
{
    public class ColourBet : Bet
    {
        public Colour Colour { get; }
        
        public ColourBet(Colour colour, double moneyBet) : base(moneyBet)
        {
            Colour = colour;
        }

        public static ColourBet CreateColourBet(Colour colour, int amountOnBet)
        {
            return new(colour, amountOnBet);
        }

        public override double CalculateAward(int result)
        {
            if (ColourByNumberMapper.ColourByNumber(result) == Colour)
                return MoneyBet * 2;
            
            return 0;
        }
    }
}