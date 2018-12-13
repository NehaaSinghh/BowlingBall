using BowlingBall.Constants;
using BowlingBall.Enums;
using BowlingBall.Interfaces;
using System.Collections.Generic;

namespace BowlingBall.Helper
{
    public class FrameHelper: IFrameHelper
    {
        public List<Frame> GetFrames(int[] rolls)
        {
            int currentFrameIndex = 0;
            int currentFrameRollsCount = 0;
            var frames = new List<Frame>();
            for (int i = 0; i < rolls.Length && currentFrameIndex <= FrameConstants.MAX_NUMBER_OF_FRAMES;)
            {
                currentFrameIndex++;
                Frame currentFrame;

                if (IsStrike(rolls[i]))
                {
                    currentFrame = new StrikeFrame();
                    currentFrameRollsCount = 1;
                }
                else if (IsSpare(rolls[i], rolls[i + 1]))
                {
                    currentFrame = new SpareFrame(rolls[i], rolls[i + 1]);
                    currentFrameRollsCount = FrameConstants.MAX_ROLLS_PER_NORMAL_FRAME;
                }
                else
                {
                    currentFrame = new Frame(rolls[i], rolls[i + 1]);
                    currentFrameRollsCount = FrameConstants.MAX_ROLLS_PER_NORMAL_FRAME;
                }

                if (IsLastFrame(currentFrameIndex) && IsBonusTypeFrame(currentFrame.FrameType))
                {
                    // Case when 10th frame is strike frame.
                    if(currentFrame.Roll2 == null)
                        currentFrame.Roll2 = rolls[i + 1];
                    currentFrame.Roll3 = rolls[i + 2];
                    currentFrameRollsCount = FrameConstants.MAX_ROLLS_FOR_LAST_FRAME;
                }

                i += currentFrameRollsCount;
                currentFrame.Id = currentFrameIndex;
                currentFrame.Bonus = currentFrame.CalculateBonus(GetRollPointsAt(rolls, i), GetRollPointsAt(rolls, i + 1));
                frames.Add(currentFrame);
            }
            return frames;
        }

        private int? GetRollPointsAt(int[] rolls, int i)
        {
            if (i < rolls.Length)
                return rolls[i];
            return null;
        }

        private bool IsBonusTypeFrame(FrameTypeEnum frameType)
        {
            return frameType == FrameTypeEnum.Strike || frameType == FrameTypeEnum.Spare ? true : false;
        }

        private bool IsStrike(int currentRollPoints)
        {
            return currentRollPoints == FrameConstants.MAX_PIN_POINTS ? true : false;
        }

        private bool IsSpare(int currentRollPoints, int nextRollPoints)
        {
            return (currentRollPoints + nextRollPoints == FrameConstants.MAX_PIN_POINTS) ? true : false;
        }

        private bool IsLastFrame(int currentFrameIndex)
        {
            return currentFrameIndex == FrameConstants.MAX_NUMBER_OF_FRAMES ? true : false;
        }
    }
}
