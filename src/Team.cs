namespace TournamentTable
{
  public interface ITeam
  {
    public abstract string Name { get; }
  }

  public class Team(string name) : ITeam
  {
    private readonly string _name = name;

    public string Name => _name;
  }
}
