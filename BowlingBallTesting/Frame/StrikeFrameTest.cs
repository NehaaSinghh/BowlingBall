
using BowlingBall;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBallTesting
{
    [TestClass]
    public class StrikeFrameTest: TestBase
    {
        [TestMethod]
        public void Strike_Bonus_Calculation_Provided_Next_Normal_Frames()
        {
            var nextRoll = GetRandomPins(0, 9);
            var nextToNextRoll = GetRandomPins(0, nextRoll);
            var strikeFrame = new StrikeFrame();
            var calculatedBonus = strikeFrame.CalculateBonus(nextRoll, nextToNextRoll);

            var actualBonus = nextRoll + nextToNextRoll;

            Assert.AreEqual(actualBonus, calculatedBonus);
        }

        [TestMethod]
        public void Strike_Bonus_Calculation_Provided_Next_Spare_Frames()
        {
            var nextRoll = GetRandomPins(0, 9);
            var nextToNextRoll = 10 - nextRoll;
            var strikeFrame = new StrikeFrame();
            var calculatedBonus = strikeFrame.CalculateBonus(nextRoll, nextToNextRoll);

            var actualBonus = nextRoll + nextToNextRoll;

            Assert.AreEqual(actualBonus, calculatedBonus);
        }

        [TestMethod]
        public void Strike_Bonus_Calculation_Provided_Next_Strike_Frames()
        {
            var nextRoll = 10;
            var nextToNextRoll = 10;
            var strikeFrame = new StrikeFrame();
            var calculatedBonus = strikeFrame.CalculateBonus(nextRoll, nextToNextRoll);

            var actualBonus = nextRoll + nextToNextRoll;

            Assert.AreEqual(actualBonus, calculatedBonus);
        }

        [TestMethod]
        public void Strike_Bonus_Calculation_Provided_Next_Mixed_Frames()
        {
            var nextRoll = 10;
            var nextToNextRoll = GetRandomPins(0, 10);
            var strikeFrame = new StrikeFrame();
            var calculatedBonus = strikeFrame.CalculateBonus(nextRoll, nextToNextRoll);

            var actualBonus = nextRoll + nextToNextRoll;

            Assert.AreEqual(actualBonus, calculatedBonus);
        }
    }
}
