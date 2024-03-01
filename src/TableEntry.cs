namespace TournamentTable
{
  public class TableEntry : ITableEntry
  {
    private int goalsScored = 0;
    private int goalsAgainst = 0;
    private int points = 0;

    public int Points => points;
    public int GoalsScored => goalsScored;
    public int GoalsAgainst => goalsAgainst;

    public void AddPoints(int _points)
    {
      points += _points;
    }
    public void AddGoalsScored(int _goalsScored)
    {
      goalsScored += _goalsScored;
    }
    public void AddGoalsAgainst(int _goalsAgainst)
    {
      goalsAgainst += _goalsAgainst;
    }

    public required ITeam Team { get; set; }

    public override string ToString()
    {
      string result = "";

      result += Team.Name;
      result += " ";
      result += points;
      result += " ";
      result += goalsScored;
      result += ":";
      result += goalsAgainst;

      return result;
    }
  }
}
