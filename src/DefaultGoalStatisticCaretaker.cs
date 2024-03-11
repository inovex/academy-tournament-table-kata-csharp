namespace TournamentTable
{
    public interface IGoalStatisticCaretaker
    {
        public void MaintainGoalStatistic(ITableEntry tableEntry, int scoredGoals, int takenGoals);
    }

    public class DefaultGoalStatisticCaretaker : IGoalStatisticCaretaker
    {
        public void MaintainGoalStatistic(ITableEntry tableEntry, int scoredGoals, int takenGoals)
        {
            tableEntry.AddGoalsScored(scoredGoals);
            tableEntry.AddGoalsAgainst(takenGoals);
        }
    }
}


