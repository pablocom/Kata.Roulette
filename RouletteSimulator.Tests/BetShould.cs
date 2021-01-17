using System.Linq;
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
            var player = new Player();
            player.AddMoney(16.55);
            player.CreateBetFor(betNumber, 16.55);

            Assert.That(((NumberBet) player.CurrentBets.First()).BetNumber, Is.EqualTo(betNumber));
            Assert.That(player.CurrentBets.First().Colour, Is.EqualTo(expectedColour));
        }
    }
}