using System.Data;

namespace TournamentTable.Test
{
    public class CoefficientClientMock : ICoefficientClient
    {
        public Dictionary<ITeam, int> returnValue = [];
        public bool wasCalled = false;

        public int GetCoefficient(ITeam team)
        {
            wasCalled = true;
            return returnValue[team];
        }
    };

    public class DefaultTableEntryComparerTests
    {
        private ITableEntryComparer tableEntryComparer;
        private ITeam germany;
        private ITableEntry germanyTableEntry;
        private ITeam england;
        private ITableEntry englandTableEntry;
        private CoefficientClientMock coefficientClientMock;

        [SetUp]
        public void Setup()
        {
            coefficientClientMock = new CoefficientClientMock();

            tableEntryComparer = new DefaultTableEntryComparer { CoefficientClient = coefficientClientMock };

            germany = new Team("Germany");
            germanyTableEntry = new TableEntry { Team = germany };

            england = new Team("England");
            englandTableEntry = new TableEntry { Team = england };
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
            coefficientClientMock.returnValue.Add(germany, 1);
            coefficientClientMock.returnValue.Add(england, 1);
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
            coefficientClientMock.returnValue.Add(germany, 1);
            coefficientClientMock.returnValue.Add(england, 2);
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
            coefficientClientMock.returnValue.Add(germany, 2);
            coefficientClientMock.returnValue.Add(england, 1);
            germanyTableEntry.AddPoints(1);
            englandTableEntry.AddPoints(1);
            germanyTableEntry.AddGoalsScored(2);
            germanyTableEntry.AddGoalsAgainst(3);
            englandTableEntry.AddGoalsScored(1);
            englandTableEntry.AddGoalsAgainst(2);

            var result = tableEntryComparer.GreaterThan(germanyTableEntry, englandTableEntry);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GreaterThan_FirstTeamHasMorePoints_CoefficientClientIsNotCalled()
        {
            germanyTableEntry.AddPoints(2);
            englandTableEntry.AddPoints(1);

            tableEntryComparer.GreaterThan(germanyTableEntry, englandTableEntry);

            Assert.That(coefficientClientMock.wasCalled, Is.False);
        }
    }
}