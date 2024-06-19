namespace TournamentTable.Test
{
    public class GameResultTests
    {
        ITeam changeFirstTeamName;
        ITeam changeSecondTeamName;

        public GameResultTests()
        {
            changeFirstTeamName = new Team("FirstTeam");
            changeSecondTeamName = new Team("SecondTeam");
        }

        [Fact]
        public void MySuperDuperTestName()
        {
            // TODO
        }
    }
}