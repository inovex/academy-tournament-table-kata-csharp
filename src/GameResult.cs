namespace TournamentTable
{
  public class GameResult
  {
    public GameResult(ITeam homeTeam, ITeam awayTeam, int homeTeamGoals, int awayTeamGoals)
    {
      if (homeTeam == null)
      {
        throw new RuntimeException("Hometeam not specified");
      }

      if (awayTeam == null)
      {
        throw new RuntimeException("Awayteam not specified");
      }

      _homeTeam = homeTeam;
      _awayTeam = awayTeam;
      _homeTeamGoals = homeTeamGoals;
      _awayTeamGoals = awayTeamGoals;
    }

    private readonly ITeam _homeTeam;
    private readonly ITeam _awayTeam;
    private readonly int _homeTeamGoals;
    private readonly int _awayTeamGoals;

    public ITeam HomeTeam => _homeTeam;
    public ITeam AwayTeam => _awayTeam;
    public int HomeTeamGoals => _homeTeamGoals;
    public int AwayTeamGoals => _awayTeamGoals;

    public bool IsDraw => _homeTeamGoals == _awayTeamGoals;

    public ITeam? WinningTeam
    {
      get
      {
        if (_homeTeamGoals > _awayTeamGoals)
        {
          return _homeTeam;
        }

        if (_awayTeamGoals > _homeTeamGoals)
        {
          return _awayTeam;
        }

        return null;
      }
    }
  }
}