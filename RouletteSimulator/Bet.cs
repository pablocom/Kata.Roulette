namespace RouletteSimulator
{
    public abstract class Bet
    {
        public double MoneyBet { get; }

        protected Bet(double moneyBet)
        {
            MoneyBet = moneyBet;
        }

        public abstract double CalculateAward(int result);
    }
}