using BowlingBall.Enums;
using BowlingBall.Interfaces;

namespace BowlingBall
{
    /// <summary>
    /// The Frame.
    /// </summary>
    /// <seealso cref="BowlingBall.Interfaces.IFrame" />
    public class Frame : IFrame
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first roll points.
        /// </summary>
        /// <value>
        /// The first roll points.
        /// </value>
        public int? Roll1 { get; set; }

        /// <summary>
        /// Gets or sets the second roll points.
        /// </summary>
        /// <value>
        /// The second roll points.
        /// </value>
        public int? Roll2 { get; set; }

        /// <summary>
        /// Gets or sets the third roll points.
        /// </summary>
        /// <value>
        /// The third roll points.
        /// </value>
        public int? Roll3 { get; set; }

        /// <summary>
        /// Gets or sets the frame score.
        /// </summary>
        /// <value>
        /// The frame score.
        /// </value>
        public int FrameScore { get; set; }

        /// <summary>
        /// Gets or sets the frame bonus.
        /// </summary>
        /// <value>
        /// The frame bonus.
        /// </value>
        public int Bonus { get; set; }

        /// <summary>
        /// Gets or sets the type of the frame.
        /// </summary>
        /// <value>
        /// The type of the frame.
        /// </value>
        public FrameTypeEnum FrameType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Frame"/> class.
        /// </summary>
        public Frame()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Frame"/> class.
        /// </summary>
        /// <param name="roll1">The first roll.</param>
        /// <param name="roll2">The second roll.</param>
        /// <param name="roll3">The third roll.</param>
        /// <param name="type">The frame type.</param>
        public Frame(int roll1, int? roll2 = null, int? roll3 = null, FrameTypeEnum type = FrameTypeEnum.Normal)
        {
            Roll1 = roll1;
            Roll2 = roll2;
            Roll3 = roll3;
            FrameType = type;
        }

        ///<inheritdoc />
        public virtual int CalculateBonus(int? nextRoll = null, int? nextToNextRoll = null)
        {
            return 0;
        }
    }
}
