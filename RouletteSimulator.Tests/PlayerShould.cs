using System;
using System.Linq;
using NUnit.Framework;

namespace RouletteSimulator.Tests
{
    public class PlayerShould
    {
        [Test]
        public void AddSomeMoneyToRoulette()
        {
            var money = 50.58;

            var player = new Player();
            player.AddMoney(money);
            
            Assert.That(player.ActualMoney, Is.EqualTo(money));
        }

        [Test]
        public void MakeANumberBet()
        {
            var betNumber = 23;
            var amount = 18.56;

            var player = new Player();
            player.AddMoney(amount);
            player.CreateBetFor(betNumber, amount);

            Assert.That(((NumberBet) player.CurrentBets.First()).BetNumber, Is.EqualTo(betNumber));
            Assert.That(player.CurrentBets.First().MoneyBet, Is.EqualTo(amount));
        }
        
        [Test]
        public void MakeAColourBet()
        {
            var colourBet = Colour.Red;
            var amount = 18.56;

            var player = new Player();
            player.AddMoney(amount);
            player.CreateBetFor(colourBet, amount);

            Assert.That(((ColourBet) player.CurrentBets.First()).Colour, Is.EqualTo(Colour.Red));
            Assert.That(player.CurrentBets.First().MoneyBet, Is.EqualTo(amount));
        }

        [TestCase(-1)]
        [TestCase(37)]
        public void ThrowExceptionIfTriesToBetNotValidNumber(int outOfRangeNumber)
        {
            var player = new Player();
            player.AddMoney(16.52);
            
            TestDelegate testDelegate = () => player.CreateBetFor(outOfRangeNumber, 16.52);
            
            Assert.Throws<ArgumentException>(testDelegate, "Number you tried to bet for is out of range");
        }
        
        [Test]
        public void ThrowExceptionIfTriesToBetMoreMoneyThanActual()
        {
            var player = new Player();
            
            TestDelegate testDelegate = () => player.CreateBetFor(5, 16.56);

            Assert.Throws<ArgumentException>(testDelegate, "Actual money is less than requested to bet");
        }
    }
}