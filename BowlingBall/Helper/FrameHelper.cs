using BowlingBall.Constants;
using BowlingBall.Enums;
using BowlingBall.Interfaces;
using System.Collections.Generic;

namespace BowlingBall.Helper
{
    /// <summary>
    /// Helper class frame related operations.
    /// </summary>
    /// <seealso cref="BowlingBall.Interfaces.IFrameHelper" />
    public class FrameHelper : IFrameHelper
    {
        /// <inheritdoc />
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
                    if (currentFrame.Roll2 == null)
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

        /// <summary>
        /// Gets the roll points at particular index.
        /// </summary>
        /// <param name="rolls">The collection rolls.</param>
        /// <param name="index">The index.</param>
        /// <returns>The roll points.</returns>
        private int? GetRollPointsAt(int[] rolls, int index)
        {
            if (index < rolls.Length)
                return rolls[index];
            return null;
        }

        /// <summary>
        /// Determines whether is the specified frame of a bonus type frame.
        /// </summary>
        /// <param name="frameType">Type of the frame.</param>
        /// <returns>
        ///   <c>true</c> if the specified frame is of a bonus type frame; otherwise, <c>false</c>.
        /// </returns>
        private bool IsBonusTypeFrame(FrameTypeEnum frameType)
        {
            return frameType == FrameTypeEnum.Strike || frameType == FrameTypeEnum.Spare ? true : false;
        }

        /// <summary>
        /// Determines whether the specified current frame is strike.
        /// </summary>
        /// <param name="currentRollPoints">The current roll points.</param>
        /// <returns>
        ///   <c>true</c> if the specified current frame is strike; otherwise, <c>false</c>.
        /// </returns>
        private bool IsStrike(int currentRollPoints)
        {
            return currentRollPoints == FrameConstants.MAX_PIN_POINTS ? true : false;
        }

        /// <summary>
        /// Determines whether the specified current frame is spare.
        /// </summary>
        /// <param name="currentRollPoints">The current roll points.</param>
        /// <param name="nextRollPoints">The next roll points.</param>
        /// <returns>
        ///   <c>true</c> if the specified current frame is spare; otherwise, <c>false</c>.
        /// </returns>
        private bool IsSpare(int currentRollPoints, int nextRollPoints)
        {
            return (currentRollPoints + nextRollPoints == FrameConstants.MAX_PIN_POINTS) ? true : false;
        }

        /// <summary>
        /// Determines whether the specified current frame is the last frame.
        /// </summary>
        /// <param name="currentFrameIndex">Index of the current frame.</param>
        /// <returns>
        ///   <c>true</c> if the specified current frame is the last frame; otherwise, <c>false</c>.
        /// </returns>
        private bool IsLastFrame(int currentFrameIndex)
        {
            return currentFrameIndex == FrameConstants.MAX_NUMBER_OF_FRAMES ? true : false;
        }
    }
}
