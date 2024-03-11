namespace TournamentTable
{
    public interface ITableEntryComparer
    {
        public int GreaterThan(ITableEntry leftTableEntry, ITableEntry rightTableEntry);
    }

    public class DefaultTableEntryComparer : ITableEntryComparer
    {
        public int GreaterThan(ITableEntry leftTableEntry, ITableEntry rightTableEntry)
        {
            var leftGoalDifference = CalculateGoalDifference(leftTableEntry);
            var rightGoalDifference = CalculateGoalDifference(rightTableEntry);

            if (leftGoalDifference == rightGoalDifference)
            {
                return leftTableEntry.Points.CompareTo(rightTableEntry.Points);
            }

            return leftGoalDifference.CompareTo(rightGoalDifference);
        }

        private static int CalculateGoalDifference(ITableEntry tableEntry)
        {
            return tableEntry.GoalsScored - tableEntry.GoalsAgainst;
        }
    }
}

