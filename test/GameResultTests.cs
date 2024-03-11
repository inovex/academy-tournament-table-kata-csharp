namespace TournamentTable.Test
{
    public class GameResultTests
    {
        ITeam germany;
        ITeam england;

        [SetUp]
        public void Setup()
        {
            germany = new Team("Germany");
            england = new Team("England");
        }

        [Test]
        public void GetWinningTeam_HomeTeamWon_ReturnsHomeTeam()
        {
            var gameResult = new GameResult(germany, england, 6, 5);

            var winningTeam = gameResult.WinningTeam;

            Assert.That(winningTeam, Is.EqualTo(germany));
        }

        [Test]
        public void GetWinningTeam_AwayTeamWon_ReturnsAwayTeam()
        {
            var gameResult = new GameResult(germany, england, 2, 5);

            var winningTeam = gameResult.WinningTeam;

            Assert.That(winningTeam, Is.EqualTo(england));
        }

        [Test]
        public void GetWinningTeam_Draw_RetrunsNull()
        {
            var gameResult = new GameResult(germany, england, 2, 2);

            var winningTeam = gameResult.WinningTeam;

            Assert.That(winningTeam, Is.Null);
        }

        [Test]
        public void IsDraw_HomeTeamWon_ReturnsFalse()
        {
            var gameResult = new GameResult(germany, england, 6, 5);

            var isDraw = gameResult.IsDraw;

            Assert.That(isDraw, Is.False);
        }

        [Test]
        public void IsDraw_AwayTeamWon_ReturnsFalse()
        {
            var gameResult = new GameResult(germany, england, 2, 5);

            var isDraw = gameResult.IsDraw;

            Assert.That(isDraw, Is.False);
        }

        [Test]
        public void IsDraw_Draw_ReturnsTrue()
        {
            var gameResult = new GameResult(germany, england, 2, 2);

            var isDraw = gameResult.IsDraw;

            Assert.That(isDraw, Is.True);
        }

        [Test]
        public void Constructor_HomeTeamNull_ThrowsException()
        {
            Assert.Throws<RuntimeException>(() => new GameResult(null, england, 0, 0));
        }

        [Test]
        public void Constructor_AwayTeamNull_ThrowsException()
        {
            Assert.Throws<RuntimeException>(() => new GameResult(germany, null, 0, 0));
        }
    }
}