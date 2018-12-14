using System.Collections.Generic;

namespace BowlingBall.Interfaces
{
    /// <summary>
    /// The interface for frame helper.
    /// </summary>
    public interface IFrameHelper
    {
        /// <summary>
        /// Gets the frames.
        /// </summary>
        /// <param name="rolls">The rolls.</param>
        /// <returns>Collection of frames.</returns>
        List<Frame> GetFrames(int[] rolls);
    }
}
