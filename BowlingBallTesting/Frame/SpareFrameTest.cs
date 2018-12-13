using BowlingBall;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBallTesting
{
    [TestClass]
    public class SpareFrameTest: TestBase
    {
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

        [TestMethod]
        public void Spare_Bonus_Calculation_Provided_Two_Next_Roll()
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
