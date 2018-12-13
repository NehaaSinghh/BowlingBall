using BowlingBall.Constants;
using BowlingBall.Enums;

namespace BowlingBall
{
    public class StrikeFrame: Frame
    {
        public StrikeFrame() : base(FrameConstants.MAX_PIN_POINTS, type: FrameTypeEnum.Strike)
        {
            Roll1 = FrameConstants.MAX_PIN_POINTS;
            Roll2 = null;
        }

        public override int CalculateBonus(int? nextRoll = null, int? nextToNextRoll = null)
        {
            // Points of next two rolls
            return nextRoll.GetValueOrDefault(0) + nextToNextRoll.GetValueOrDefault(0);
        }
    }
}
