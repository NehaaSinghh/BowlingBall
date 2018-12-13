using BowlingBall;
using BowlingBall.Helper;
using BowlingBall.Interfaces;
using System;
using System.Collections.Generic;
using Unity;

namespace BowlingExecuter
{
    class Program
    {
        private static IUnityContainer container = new UnityContainer();

        static void Main(string[] args)
        {
            RegisterService();
            var game = GetService<Game>();

            Console.WriteLine("Welcome!");

            int[] rolls = { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };

            var frames = game.GetFrames(rolls);
            var totalScore = game.GetScore();

            PrintFrames(frames);
            PrintTotalScore(totalScore);
            Console.ReadLine();
        }

        private static void PrintTotalScore(int totalScore)
        {
            Console.WriteLine("**************************");
            Console.WriteLine("TOTAL SCORE: " + totalScore);
            Console.WriteLine("**************************");
        }

        public static void PrintFrames(List<Frame> frames)
        {
            Console.WriteLine("\n\nFollowing are the Frames: ");
            foreach (var frame in frames)
            {
                Console.WriteLine("-------");
                Console.WriteLine("ID: " + frame.Id);
                Console.WriteLine("ROLL1: " + frame.Roll1);
                if (frame.Roll2 != null) Console.WriteLine("ROLL2: " + frame.Roll2);
                if (frame.Roll3 != null) Console.WriteLine("ROLL3: " + frame.Roll3);
                Console.WriteLine("Type: " + frame.FrameType);
                Console.WriteLine("Frame Score: " + frame.FrameScore);
                Console.WriteLine("Bonus: " + frame.Bonus);
                Console.WriteLine("-------\n");
            }
            Console.WriteLine("Done!");
        }

        private static void RegisterService()
        {
            container.RegisterType<IFrameHelper, FrameHelper>();
        }

        private static T GetService<T>()
        {
            return container.Resolve<T>();
        }
    }
}
