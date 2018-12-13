using BowlingBall.Interfaces;
using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        //TODO: make unnecessary public varibales to private
        public Guid Id { get; set; }
        public List<Frame> Frames { get; set; }
        public int[] Rolls { get; set; }

        private IFrameHelper frameHelper { get; set; }

        public Game(IFrameHelper frameHelper)
        {
            Id = Guid.NewGuid();
            Frames = new List<Frame>();
            this.frameHelper = frameHelper;
        }

        public List<Frame> GetFrames(int[] rolls)
        {
            this.Rolls = rolls;
            var frame = new Frame();
            Frames = frameHelper.GetFrames(Rolls);
            GetScore();
            return Frames;
        }

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
