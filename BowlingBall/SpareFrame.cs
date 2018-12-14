using BowlingBall.Enums;
using System.Collections.Generic;

namespace BowlingBall
{
    /// <summary>
    /// The Spare frame.
    /// </summary>
    /// <seealso cref="BowlingBall.Frame" />
    public class SpareFrame: Frame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpareFrame"/> class.
        /// </summary>
        /// <param name="roll1">The first roll points.</param>
        /// <param name="roll2">The second roll points.</param>
        public SpareFrame(int roll1, int roll2): base(roll1, roll2, type: FrameTypeEnum.Spare)
        {
            Roll1 = roll1;
            Roll2 = roll2;
        }
        
        /// <inheritdoc />
        public override int CalculateBonus(int? nextRoll = null, int? nextToNextRoll = null)
        {
            // Points of next one roll
            return nextRoll.GetValueOrDefault(0);
        }
    }
}
