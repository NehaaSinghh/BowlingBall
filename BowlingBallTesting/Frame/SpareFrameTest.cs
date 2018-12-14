using BowlingBall;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBallTesting
{
    /// <summary>
    /// Spare frame test cases.
    /// </summary>
    /// <seealso cref="BowlingBallTesting.TestBase" />
    [TestClass]
    public class SpareFrameTest: TestBase
    {
        /// <summary>
        /// Spares frame bonus calculation provided only one next roll.
        /// </summary>
        [TestMethod]
        public void Spare_Bonus_Calculation_Provided_One_Next_Roll()
        {
            var roll1 = GetRandomPins(0, 9);
            var roll2 = 10 - roll1;
            var roll3 = GetRandomPins(0, 10);
            var spareFrame = new SpareFrame(roll1, roll2);
            var calculatedBonus = spareFrame.CalculateBonus(roll3);

            var actualBonus = roll3;

            Assert.AreEqual(actualBonus, calculatedBonus);
        }

        /// <summary>
        /// Spares frame bonus calculation provided two next rolls.
        /// </summary>
        [TestMethod]
        public void Spare_Bonus_Calculation_Provided_Two_Next_Rolls()
        {
            var roll1 = GetRandomPins(0, 9);
            var roll2 = 10 - roll1;
            var roll3 = GetRandomPins(0, 10);
            var roll4 = GetRandomPins(0, 10);
            var spareFrame = new SpareFrame(roll1, roll2);
            var calculatedBonus = spareFrame.CalculateBonus(roll3, roll4);

            var actualBonus = roll3;

            Assert.AreEqual(actualBonus, calculatedBonus);
        }
    }
}
