using BowlingBall.Interfaces;
using System;
using System.Collections.Generic;

namespace BowlingBall
{
    /// <summary>
    /// The Game class.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the frames.
        /// </summary>
        /// <value>
        /// The frames.
        /// </value>
        public List<Frame> Frames { get; set; }

        /// <summary>
        /// Gets or sets the rolls points.
        /// </summary>
        /// <value>
        /// The rolls points.
        /// </value>
        public int[] Rolls { get; set; }

        /// <summary>
        /// Gets or sets the frame helper.
        /// </summary>
        /// <value>
        /// The frame helper.
        /// </value>
        private IFrameHelper frameHelper { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="frameHelper">The frame helper.</param>
        public Game(IFrameHelper frameHelper)
        {
            Id = Guid.NewGuid();
            Frames = new List<Frame>();
            this.frameHelper = frameHelper;
        }

        /// <summary>
        /// Gets the frames.
        /// </summary>
        /// <param name="rolls">The rolls.</param>
        /// <returns>The collection of frames.</returns>
        public List<Frame> GetFrames(int[] rolls)
        {
            this.Rolls = rolls;
            var frame = new Frame();
            Frames = frameHelper.GetFrames(Rolls);
            GetScore();
            return Frames;
        }

        /// <summary>
        /// Gets the total score.
        /// </summary>
        /// <returns>The total score.</returns>
        public int GetScore()
        {
            int totalScore = 0;
            foreach (var frame in Frames)
            {
                frame.FrameScore = frame.Roll1.GetValueOrDefault(0) + frame.Roll2.GetValueOrDefault(0) + frame.Roll3.GetValueOrDefault(0);
                totalScore += frame.FrameScore + frame.Bonus;
            }
            return totalScore;
        }
    }
}
