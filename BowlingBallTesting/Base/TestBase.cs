using BowlingBall.Helper;
using BowlingBall.Interfaces;
using System;
using Unity;

namespace BowlingBallTesting
{
    /// <summary>
    /// Base class for test files.
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// The container.
        /// </summary>
        private IUnityContainer container = new UnityContainer();

        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase"/> class.
        /// </summary>
        public TestBase()
        {
            RegisterService();
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        private void RegisterService()
        {
            container.RegisterType<IFrameHelper, FrameHelper>();
        }

        /// <summary>
        /// Gets the required service.
        /// </summary>
        /// <typeparam name="T">Type of service.</typeparam>
        /// <returns>The service.</returns>
        public T GetService<T>()
        {
            return container.Resolve<T>();
        }

        /// <summary>
        /// Gets the random pin points.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>Pint points.</returns>
        public int GetRandomPins(int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue);
        }
    }
}
