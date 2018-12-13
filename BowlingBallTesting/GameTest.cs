using BowlingBall;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBallTesting
{
    [TestClass]
    public class GameTest: TestBase
    {
        [TestMethod]
        public void Random_Input_Test()
        {
            int[] rolls = { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            var game = GetService<Game>();

            var frames = game.GetFrames(rolls);
            var totalScore = game.GetScore();

            Assert.AreEqual(10, frames.Count);
            Assert.AreEqual(187, totalScore);
        }

        [TestMethod]
        public void Perfect_Game_Test()
        {
            int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};
            var game = GetService<Game>();

            var frames = game.GetFrames(rolls);
            var totalScore = game.GetScore();

            Assert.AreEqual(10, frames.Count);
            Assert.AreEqual(300, totalScore);
        }

        [TestMethod]
        public void Gutter_Game_Test()
        {
            int[] rolls = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var game = GetService<Game>();

            var frames = game.GetFrames(rolls);
            var totalScore = game.GetScore();

            Assert.AreEqual(10, frames.Count);
            Assert.AreEqual(0, totalScore);
        }
    }
}
