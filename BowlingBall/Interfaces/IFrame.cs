namespace BowlingBall.Interfaces
{
    public interface IFrame
    {
        int CalculateBonus(int? nextRoll = null, int? nextToNextRoll = null);
    }
}
