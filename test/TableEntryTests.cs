namespace TournamentTable.Test
{
    [TestFixture]
    public class TableEntryTests
    {
        private TableEntry tableEntry;
        private ITeam germany;
        private const int zero = 0;

        [SetUp]
        public void Setup()
        {
            germany = new Team("Germany");
            tableEntry = new TableEntry { Team = germany };
        }

        [Test]
        public void ToString_TableEntryWithTeam_ReturnsExpectedString()
        {
            const string expected = "Germany 0 0:0";

            var result = tableEntry.ToString();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToString_TableEntryWithTeamPointsAndGoals_ReturnsExpectedString()
        {
            const string expected = "Germany 3 4:2";
            tableEntry.AddPoints(3);
            tableEntry.AddGoalsScored(4);
            tableEntry.AddGoalsAgainst(2);

            var result = tableEntry.ToString();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddGoalsScored_SomeGoals_SumsTheAddedGoalsUp()
        {
            var expectedGoals = 5;
            var firstGoals = 2;
            var secondGoals = 3;

            tableEntry.AddGoalsScored(firstGoals);
            tableEntry.AddGoalsScored(secondGoals);

            var goalsScored = tableEntry.GoalsScored;
            Assert.That(goalsScored, Is.EqualTo(expectedGoals));
        }

        [Test]
        public void AddGoalsAgainst_SomeGoals_SumsTheAddedGoalsUp()
        {
            var expectedGoals = 5;
            var firstGoals = 2;
            var secondGoals = 3;

            tableEntry.AddGoalsAgainst(firstGoals);
            tableEntry.AddGoalsAgainst(secondGoals);

            var goalsAgainst = tableEntry.GoalsAgainst;
            Assert.That(goalsAgainst, Is.EqualTo(expectedGoals));
        }

        [Test]
        public void GetGoalsScored_DefaultTableEntry_ReturnsZero()
        {
            var goalsScored = tableEntry.GoalsScored;

            Assert.That(goalsScored, Is.EqualTo(zero));
        }

        [Test]
        public void GetGoalsScored_SomeGoalsScored_ReturnsExpectedGoals()
        {
            var someGoals = 5;
            tableEntry.AddGoalsScored(someGoals);

            var goalsScored = tableEntry.GoalsScored;

            Assert.That(goalsScored, Is.EqualTo(someGoals));
        }

        [Test]
        public void GetGoalsAgainst_DefaultTableEntry_ReturnsZero()
        {
            var goalsAgainst = tableEntry.GoalsAgainst;

            Assert.That(goalsAgainst, Is.EqualTo(zero));
        }

        [Test]
        public void GetGoalsAgainst_SomeGoalsAgainst_ReturnsExpectedGoals()
        {
            var someGoals = 5;
            tableEntry.AddGoalsAgainst(someGoals);

            var goalsAgainst = tableEntry.GoalsAgainst;

            Assert.That(goalsAgainst, Is.EqualTo(someGoals));
        }

        [Test]
        public void AddPoints_SomePoints_SumsTheAddedPointsUp()
        {
            var expectedPoints = 7;
            var firstPoints = 4;
            var secondPoints = 3;

            tableEntry.AddPoints(firstPoints);
            tableEntry.AddPoints(secondPoints);

            var points = tableEntry.Points;
            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [Test]
        public void GetPoints_DefaultTableEntry_ReturnsZero()
        {
            var points = tableEntry.Points;

            Assert.That(points, Is.EqualTo(zero));
        }

        [Test]
        public void GetPoints_SomePointsAdded_ReturnsExpectedPoints()
        {
            var somePoints = 5;
            tableEntry.AddPoints(somePoints);

            var points = tableEntry.Points;

            Assert.That(points, Is.EqualTo(somePoints));
        }

        [Test]
        public void GetTeam_DefaultTableEntry_ReturnsDefault()
        {
            var team = tableEntry.Team;

            Assert.That(team, Is.EqualTo(germany));
        }

        [Test]
        public void GetTeam_TeamIsSet_ReturnsExpectedTeam()
        {
            var england = new Team("England");
            tableEntry.Team = england;

            var team = tableEntry.Team;

            Assert.That(team, Is.EqualTo(england));
        }
    }
}