namespace TournamentTable.Test
{
    public class DefaultTableEntryComparerTests
    {
        private ITableEntryComparer tableEntryComparer;
        private ITableEntry germanyTableEntry;
        private ITableEntry englandTableEntry;

        [SetUp]
        public void Setup()
        {
            tableEntryComparer = new DefaultTableEntryComparer();
            germanyTableEntry = new TableEntry { Team = new Team("Germany") };
            englandTableEntry = new TableEntry { Team = new Team("England") };
        }

        [Test]
        public void GreaterThan_BothTeamsHaveSamePoints_ReturnsZero()
        {
            germanyTableEntry.AddPoints(1);
            englandTableEntry.AddPoints(1);

            var result = tableEntryComparer.GreaterThan(germanyTableEntry, englandTableEntry);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GreaterThan_FirstTeamHasMorePoints_ReturnsOne()
        {
            germanyTableEntry.AddPoints(2);
            englandTableEntry.AddPoints(1);

            var result = tableEntryComparer.GreaterThan(germanyTableEntry, englandTableEntry);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GreaterThan_FirstTeamHasLessPoints_ReturnsMinusOne()
        {
            germanyTableEntry.AddPoints(1);
            englandTableEntry.AddPoints(2);

            var result = tableEntryComparer.GreaterThan(germanyTableEntry, englandTableEntry);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void GreaterThan_BothTeamsHaveSamePointsAndFirstTeamLessGoalDifference_ReturnsMinusOne()
        {
            germanyTableEntry.AddPoints(1);
            englandTableEntry.AddPoints(1);
            germanyTableEntry.AddGoalsScored(1);
            englandTableEntry.AddGoalsScored(2);

            var result = tableEntryComparer.GreaterThan(germanyTableEntry, englandTableEntry);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void GreaterThan_BothTeamsHaveSamePointsAndFirstTeamGreaterGoalDifference_ReturnsOne()
        {
            germanyTableEntry.AddPoints(1);
            englandTableEntry.AddPoints(1);
            germanyTableEntry.AddGoalsScored(2);
            englandTableEntry.AddGoalsScored(1);

            var result = tableEntryComparer.GreaterThan(germanyTableEntry, englandTableEntry);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GreaterThan_BothTeamsHaveSamePointsAndSameGoalDifferenceAndSameScoredGoals_ReturnsZero()
        {
            germanyTableEntry.AddPoints(1);
            englandTableEntry.AddPoints(1);
            germanyTableEntry.AddGoalsScored(1);
            englandTableEntry.AddGoalsScored(1);

            var result = tableEntryComparer.GreaterThan(germanyTableEntry, englandTableEntry);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GreaterThan_BothTeamsHaveSamePointsAndSameGoalDifferenceAndFirstTeamLessScoredGoals_ReturnsMinusOne()
        {
            germanyTableEntry.AddPoints(1);
            englandTableEntry.AddPoints(1);
            germanyTableEntry.AddGoalsScored(1);
            germanyTableEntry.AddGoalsAgainst(2);
            englandTableEntry.AddGoalsScored(2);
            englandTableEntry.AddGoalsScored(3);

            var result = tableEntryComparer.GreaterThan(germanyTableEntry, englandTableEntry);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void GreaterThan_BothTeamsHaveSamePointsAndSameGoalDifferenceAndFirstTeamGreaterScoredGoals_ReturnsOne()
        {
            germanyTableEntry.AddPoints(1);
            englandTableEntry.AddPoints(1);
            germanyTableEntry.AddGoalsScored(2);
            germanyTableEntry.AddGoalsAgainst(3);
            englandTableEntry.AddGoalsScored(1);
            englandTableEntry.AddGoalsScored(2);

            var result = tableEntryComparer.GreaterThan(germanyTableEntry, englandTableEntry);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}