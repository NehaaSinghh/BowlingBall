using BowlingBall.Helper;
using BowlingBall.Interfaces;
using System;
using Unity;

namespace BowlingBallTesting
{
    public class TestBase
    {
        private IUnityContainer container = new UnityContainer();

        public TestBase()
        {
            RegisterService();
        }

        private void RegisterService()
        {
            container.RegisterType<IFrameHelper, FrameHelper>();
        }

        public T GetService<T>()
        {
            return container.Resolve<T>();
        }

        public int GetRandomPins(int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue);
        }
    }
}
