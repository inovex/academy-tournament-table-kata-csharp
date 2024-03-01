using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace TournamentTable
{
  public class Table()
  {
    private readonly Dictionary<ITeam, ITableEntry> tableEntries = [];
    private readonly DefaultPointDistributionBehavior pointDistributionBehavior = new();
    private readonly DefaultTableEntryComparer tableEntryComparer = new();
    private readonly DefaultGoalStatisticCaretaker goalStatisticCaretaker = new();

    private List<ITableEntry> SortTableEntries()
    {
      var values = tableEntries.Values.ToList();
      values.Sort(tableEntryComparer.GreaterThan);

      return values;
    }
    private void MaintainGoalsStatistic(GameResult result)
    {
      var homeTeamTableEntry = GetTableEntryForTeam(result.HomeTeam);
      goalStatisticCaretaker.MaintainGoalStatistic(homeTeamTableEntry, result.HomeTeamGoals, result.AwayTeamGoals);

      var awayTeamTableEntry = GetTableEntryForTeam(result.AwayTeam);
      goalStatisticCaretaker.MaintainGoalStatistic(awayTeamTableEntry, result.AwayTeamGoals, result.HomeTeamGoals);
    }
    private void AddPointsToTeams(GameResult result)
    {
      var homeTeamTableEntry = GetTableEntryForTeam(result.HomeTeam);
      var awayTeamTableEntry = GetTableEntryForTeam(result.AwayTeam);

      pointDistributionBehavior.AddPointsToTableEntries(homeTeamTableEntry, awayTeamTableEntry, result);
    }
    private void CreateTableEntriesForResultIfNotExistent(GameResult result)
    {
      var homeTeam = result.HomeTeam;
      var awayTeam = result.AwayTeam;

      CreateTableEntryIfTeamEntryNotExists(homeTeam);
      CreateTableEntryIfTeamEntryNotExists(awayTeam);
    }
    private void CreateTableEntryIfTeamEntryNotExists(ITeam team)
    {
      if (tableEntries.ContainsKey(team))
      {
        return;
      }

      var tableEntry = new TableEntry
      {
        Team = team
      };

      tableEntries.Add(team, tableEntry);
    }

    public List<ITableEntry> GetTable() { return SortTableEntries(); }

    public void BookGameResultToTable(GameResult result)
    {
      CreateTableEntriesForResultIfNotExistent(result);
      AddPointsToTeams(result);
      MaintainGoalsStatistic(result);
    }

    public ITableEntry GetTableEntryForTeam(ITeam team)
    {
      return tableEntries[team];
    }

    public override string ToString()
    {
      var tableEntries = SortTableEntries();
      var tableAsString = "";

      foreach (var entry in tableEntries)
      {
        tableAsString += entry.ToString() + "\n";
      }

      return tableAsString;
    }
  }
}
