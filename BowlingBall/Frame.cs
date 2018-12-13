using BowlingBall.Enums;
using BowlingBall.Interfaces;

namespace BowlingBall
{
    public class Frame : IFrame
    {
        public int Id { get; set; }
        public int? Roll1 { get; set; }
        public int? Roll2 { get; set; }
        // For Last frame
        public int? Roll3 { get; set; }
        public int FrameScore { get; set; }
        public int Bonus { get; set; }
        public FrameTypeEnum FrameType { get; set; }

        public Frame()
        {
        }

        public Frame(int roll1, int? roll2 = null, int? roll3 = null, FrameTypeEnum type = FrameTypeEnum.Normal)
        {
            Roll1 = roll1;
            Roll2 = roll2;
            Roll3 = roll3;
            FrameType = type;
        }

        public virtual int CalculateBonus(int? nextRoll = null, int? nextToNextRoll = null)
        {
            return 0;
        }
    }
}
