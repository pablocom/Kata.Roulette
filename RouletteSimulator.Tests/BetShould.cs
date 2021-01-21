using NUnit.Framework;

namespace RouletteSimulator.Tests
{
    [TestFixture]
    public class BetShould
    {
        [TestCase(0, Colour.Green)]
        [TestCase(1, Colour.Red)]
        [TestCase(14, Colour.Red)]
        [TestCase(9, Colour.Red)]
        [TestCase(23, Colour.Red)]
        [TestCase(25, Colour.Red)]
        [TestCase(2, Colour.Black)]
        [TestCase(13, Colour.Black)]
        [TestCase(22, Colour.Black)]
        [TestCase(35, Colour.Black)]
        public void CreateBetColourForGivenBetNumber(int betNumber, Colour expectedColour)  
        {
            var bet = NumberBet.CreateNumberBet(betNumber, 1);
            
            Assert.That(bet.BetNumber, Is.EqualTo(betNumber));
        }
        
        [Test]
        public void CalculateAwardCorrectlyForNumberBet()
        {
            var betNumber = 5;
            var amountOnBet = 10;
            var bet = NumberBet.CreateNumberBet(betNumber, amountOnBet);

            var result = bet.CalculateAward(betNumber);
            
            Assert.That(result, Is.EqualTo(amountOnBet * 36));
        }
        
        [Test]
        public void CalculateAwardCorrectlyForColourBet()
        {
            var betColour = Colour.Black;
            var amountOnBet = 10;
            var bet = ColourBet.CreateColourBet(betColour, amountOnBet);

            var blackColouredNumber = 2;
            var result = bet.CalculateAward(blackColouredNumber);
            
            Assert.That(result, Is.EqualTo(amountOnBet * 2));
        }
    }
}