using BowlingBall;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBallTesting
{
    /// <summary>
    /// Normal frame test class.
    /// </summary>
    /// <seealso cref="BowlingBallTesting.TestBase" />
    [TestClass]
    public class NormalFrameTest: TestBase
    {
        /// <summary>
        /// Normal frame bonus calculation should be zero.
        /// </summary>
        [TestMethod]
        public void Normal_Frame_Bonus_Calculation_Should_Be_Zero()
        {
            var roll1 = GetRandomPins(0, 9);
            var roll2 = 0;
            var normalFrame = new Frame(roll1, roll2);
            var calculatedBonus = normalFrame.CalculateBonus();

            var actualBonus = 0;

            Assert.AreEqual(actualBonus, calculatedBonus);
        }

        /// <summary>
        /// Normal frame bonus calculation even when next rolls are provided.
        /// </summary>
        [TestMethod]
        public void Normal_Frame_Bonus_Calculation_Provided_Next_Rolls()
        {
            var roll1 = GetRandomPins(0, 9);
            var roll2 = GetRandomPins(0, roll1 - 1);
            var roll3 = GetRandomPins(0, 10);
            var roll4 = GetRandomPins(0, 10);
            var normalFrame = new Frame(roll1, roll2);
            var calculatedBonus = normalFrame.CalculateBonus(roll3, roll4);

            var actualBonus = 0;

            Assert.AreEqual(actualBonus, calculatedBonus);
        }
    }
}
