namespace TournamentTable
{
    public interface IPointDistributionBehavior
    {
        public void AddPointsToTableEntries(ITableEntry homeTeamTableEntry, ITableEntry awayTeamTableEntry, GameResult gameResult);
    }

    public class DefaultPointDistributionBehavior : IPointDistributionBehavior
    {
        private const int pointsInCaseOfDraw = 1;
        private const int pointsInCaseOfWin = 3;

        public void AddPointsToTableEntries(ITableEntry homeTeamTableEntry, ITableEntry awayTeamTableEntry, GameResult gameResult)
        {
            var winningTeam = gameResult.WinningTeam;

            if (winningTeam == null)
            {
                homeTeamTableEntry.AddPoints(pointsInCaseOfDraw);
                awayTeamTableEntry.AddPoints(pointsInCaseOfDraw);

                return;
            }

            if (winningTeam == homeTeamTableEntry.Team)
            {
                homeTeamTableEntry.AddPoints(pointsInCaseOfWin);
            }

            if (winningTeam == awayTeamTableEntry.Team)
            {
                awayTeamTableEntry.AddPoints(pointsInCaseOfWin);
            }
        }
    }
}

