using System.Collections.Generic;

namespace BowlingBall.Interfaces
{
    public interface IFrameHelper
    {
        List<Frame> GetFrames(int[] rolls);
    }
}
