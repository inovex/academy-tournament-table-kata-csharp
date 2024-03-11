namespace TournamentTable
{
    public interface ITableEntryComparer
    {
        public int GreaterThan(ITableEntry leftTableEntry, ITableEntry rightTableEntry);
    }

    public class DefaultTableEntryComparer : ITableEntryComparer
    {
        public DefaultTableEntryComparer()
        {
            CoefficientClient = new CoefficientClient();
        }

        public ICoefficientClient CoefficientClient { get; set; }

        public int GreaterThan(ITableEntry leftTableEntry, ITableEntry rightTableEntry)
        {
            if (leftTableEntry.Points == rightTableEntry.Points)
            {
                var leftGoalDifference = CalculateGoalDifference(leftTableEntry);
                var rightGoalDifference = CalculateGoalDifference(rightTableEntry);

                if (leftGoalDifference == rightGoalDifference)
                {
                    return CoefficientClient.GetCoefficient(leftTableEntry.Team).CompareTo(CoefficientClient.GetCoefficient(rightTableEntry.Team));
                }

                return leftGoalDifference.CompareTo(rightGoalDifference);
            }

            return leftTableEntry.Points.CompareTo(rightTableEntry.Points);
        }

        private static int CalculateGoalDifference(ITableEntry tableEntry)
        {
            return tableEntry.GoalsScored - tableEntry.GoalsAgainst;
        }
    }
}

