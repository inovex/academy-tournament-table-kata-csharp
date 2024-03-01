namespace TournamentTable
{
    public interface ITableEntry
    {
        public int Points { get; }
        public int GoalsScored { get; }
        public int GoalsAgainst { get; }
        public void AddPoints(int _points);
        public void AddGoalsScored(int _goalsScored);
        public void AddGoalsAgainst(int _goalsAgainst);
        public ITeam Team { get; set; }
        public string ToString();
    }
}
