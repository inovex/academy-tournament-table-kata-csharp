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
            return leftTableEntry.Points.CompareTo(rightTableEntry.Points);
        }
    }
}

