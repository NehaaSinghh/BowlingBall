using BowlingBall.Enums;
using System.Collections.Generic;

namespace BowlingBall
{
    public class SpareFrame: Frame
    {
        public SpareFrame(int roll1, int roll2): base(roll1, roll2, type: FrameTypeEnum.Spare)
        {
            Roll1 = roll1;
            Roll2 = roll2;
        }

        public override int CalculateBonus(int? nextRoll = null, int? nextToNextRoll = null)
        {
            // Points of next one roll
            return nextRoll.GetValueOrDefault(0);
        }
    }
}
