namespace TournamentTable
{
    public interface IPointDistributionBehavior
    {
        public void AddPointsToTableEntries(ITableEntry homeTeamTableEntry, ITableEntry awayTeamTableEntry, GameResult gameResult);
    }

    public class DefaultPointDistributionBehavior : IPointDistributionBehavior
    {
        public void AddPointsToTableEntries(ITableEntry homeTeamTableEntry, ITableEntry awayTeamTableEntry, GameResult gameResult)
        {
            // TODO: this method should add points to the table entries depending on the
            // game result
        }

    }
}

