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
            return leftTableEntry.Team!.Name.CompareTo(rightTableEntry.Team!.Name);
        }
    }
}

