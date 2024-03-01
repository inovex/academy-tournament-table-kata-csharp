namespace TournamentTable.Test
{
    public class GameResultTests
    {
        ITeam changeFirstTeamName;
        ITeam changeSecondTeamName;

        [SetUp]
        public void Setup()
        {
            changeFirstTeamName = new Team("FirstTeam");
            changeSecondTeamName = new Team("SecondTeam");
        }

        [Test]
        public void MySuperDuperTestName()
        {
            // TODO
        }
    }
}