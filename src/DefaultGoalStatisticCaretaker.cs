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
            // TODO: this method should add the scored and taken goals to the table entry
        }
    }
}


