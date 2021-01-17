namespace RouletteSimulator
{
    public abstract class Bet
    {
        public double MoneyBet { get; }
        public Colour Colour { get; protected set; }

        protected Bet(double moneyBet)
        {
            MoneyBet = moneyBet;
        }

        public abstract double CalculateAward(int result);
    }
}