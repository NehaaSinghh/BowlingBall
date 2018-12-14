using BowlingBall.Constants;
using BowlingBall.Enums;

namespace BowlingBall
{
    /// <summary>
    /// The strike frame.
    /// </summary>
    /// <seealso cref="BowlingBall.Frame" />
    public class StrikeFrame: Frame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StrikeFrame"/> class.
        /// </summary>
        public StrikeFrame() : base(FrameConstants.MAX_PIN_POINTS, type: FrameTypeEnum.Strike)
        {
            Roll1 = FrameConstants.MAX_PIN_POINTS;
            Roll2 = null;
        }

        /// <inheritdoc />
        public override int CalculateBonus(int? nextRoll = null, int? nextToNextRoll = null)
        {
            // Points of next two rolls
            return nextRoll.GetValueOrDefault(0) + nextToNextRoll.GetValueOrDefault(0);
        }
    }
}
