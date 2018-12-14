namespace BowlingBall.Interfaces
{
    /// <summary>
    /// Frame interface.
    /// </summary>
    public interface IFrame
    {
        /// <summary>
        /// Calculates the bonus.
        /// </summary>
        /// <param name="nextRoll">The next roll.</param>
        /// <param name="nextToNextRoll">The next to next roll.</param>
        /// <returns>The bonus.</returns>
        int CalculateBonus(int? nextRoll = null, int? nextToNextRoll = null);
    }
}
