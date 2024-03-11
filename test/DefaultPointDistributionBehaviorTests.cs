namespace TournamentTable.Test
{
    public class DefaultPointDistributionBehaviorTests
    {
        IPointDistributionBehavior pointDistributionBehavior;
        ITeam germany;
        ITeam england;
        ITableEntry germanyTableEntry;
        ITableEntry englandTableEntry;
        const int zeroPoints = 0;
        const int winningPoints = 3;
        const int drawPoints = 1;

        [SetUp]
        public void Setup()
        {
            pointDistributionBehavior = new DefaultPointDistributionBehavior();

            germany = new Team("Germany");
            england = new Team("Germany");

            germanyTableEntry = new TableEntry() { Team = germany };
            englandTableEntry = new TableEntry() { Team = england };
        }

        [Test]
        public void AddPointsToTableEntries_HomeTeamWon_HomeTeamGetPoints()
        {
            var gameResult = new GameResult(germany, england, 1, 0);

            pointDistributionBehavior.AddPointsToTableEntries(germanyTableEntry, englandTableEntry, gameResult);

            Assert.Multiple(() =>
            {
                Assert.That(germanyTableEntry.Points, Is.EqualTo(winningPoints));
                Assert.That(englandTableEntry.Points, Is.EqualTo(zeroPoints));
            });
        }

        [Test]
        public void AddPointsToTableEntries_AwayTeamWon_AwayTeamGetPoints()
        {
            var gameResult = new GameResult(germany, england, 0, 1);

            pointDistributionBehavior.AddPointsToTableEntries(germanyTableEntry, englandTableEntry, gameResult);

            Assert.Multiple(() =>
            {
                Assert.That(germanyTableEntry.Points, Is.EqualTo(zeroPoints));
                Assert.That(englandTableEntry.Points, Is.EqualTo(winningPoints));
            });
        }

        [Test]
        public void WhatShouldITest()
        {
            var gameResult = new GameResult(germany, england, 1, 1);

            pointDistributionBehavior.AddPointsToTableEntries(germanyTableEntry, englandTableEntry, gameResult);

            Assert.Multiple(() =>
            {
                Assert.That(germanyTableEntry.Points, Is.EqualTo(drawPoints));
                Assert.That(englandTableEntry.Points, Is.EqualTo(drawPoints));
            });
        }
    }
}