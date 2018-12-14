
using BowlingBall;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBallTesting
{
    /// <summary>
    /// Strike frame test class.
    /// </summary>
    /// <seealso cref="BowlingBallTesting.TestBase" />
    [TestClass]
    public class StrikeFrameTest: TestBase
    {
        /// <summary>
        /// Strike frame bonus calculation provided next frames are normal frames.
        /// </summary>
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

        /// <summary>
        /// Strike frame bonus calculation provided next frames are spare frames.
        /// </summary>
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

        /// <summary>
        /// Strike frame bonus calculation provided next frames are strike frames.
        /// </summary>
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

        /// <summary>
        /// Strike frame bonus calculation provided next frames are mixed frames.
        /// </summary>
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
