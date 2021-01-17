namespace RouletteSimulator
{
    public class ColourBet : Bet
    {
        public ColourBet(Colour colour, double moneyBet) : base(moneyBet)
        {
            Colour = colour;
        }

        public override double CalculateAward(int result)
        {
            if (ColourByNumberMapper.GetColourByNumber(result) == Colour)
                return MoneyBet * 2;
            
            return 0;
        }
    }
}