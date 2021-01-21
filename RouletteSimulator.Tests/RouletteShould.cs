using NSubstitute;
using NUnit.Framework;

namespace RouletteSimulator.Tests
{
    [TestFixture]
    public class RouletteShould
    {
        private const double InitialAmount = 60;
        private IResultGenerator resultGenerator;
        private Roulette roulette;

        [SetUp]
        public void SetUp()
        {
            resultGenerator = Substitute.For<IResultGenerator>();
            roulette = new Roulette(resultGenerator, InitialAmount);
        }
        
        [Test]
        public void SubtractAmountFromPlayerIfLosesBet()
        {
            var betNumber = 5;
            var betAmount = 50;
            AssumeRandomResultIs(15);
            
            roulette.ProcessPlay($"{betNumber} {betAmount}");
            
            Assert.That(roulette.Player.ActualMoney, Is.EqualTo(InitialAmount - betAmount));
        }
        
        [Test]
        public void AwardPlayerIfWinsNumberBet()
        {
            var betNumber = 5;
            var betAmount = 1;
            AssumeRandomResultIs(5);
            
            roulette.ProcessPlay($"{betNumber} {betAmount}");
            
            Assert.That(roulette.Player.ActualMoney, Is.EqualTo(95d));
        }

        [Test]
        public void AwardPlayerIfWinsBlackColourBet()
        {
            var betAmount = 30;
            var betColor = "black";
            var blackColouredNumber = 2;
            AssumeRandomResultIs(blackColouredNumber);
            
            roulette.ProcessPlay($"{betColor} {betAmount}");
            
            Assert.That(roulette.Player.ActualMoney, Is.EqualTo(90d));
        }
        
        [Test]
        public void AwardPlayerIfWinsRedColourBet()
        {
            var betAmount = 30;
            var betColor = "red";
            var blackColouredNumber = 3;
            AssumeRandomResultIs(blackColouredNumber);
            
            roulette.ProcessPlay($"{betColor} {betAmount}");
            
            Assert.That(roulette.Player.ActualMoney, Is.EqualTo(90d));
        }

        private void AssumeRandomResultIs(int result)
        {
            resultGenerator.GenerateRandomResult().Returns(result);
        }
    }
}