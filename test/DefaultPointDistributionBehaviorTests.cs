namespace TournamentTable.Test
{
    public class DefaultPointDistributionBehaviorTests
    {
        IPointDistributionBehavior pointDistributionBehavior;
        ITeam changeFirstTeamName;
        ITeam changeSecondTeamName;
        ITableEntry firstTeamTableEntry;
        ITableEntry secondTableEntry;

        [SetUp]
        public void Setup()
        {
            pointDistributionBehavior = new DefaultPointDistributionBehavior();

            changeFirstTeamName = new Team("first");
            changeSecondTeamName = new Team("second");

            firstTeamTableEntry = new TableEntry() { Team = changeFirstTeamName };
            secondTableEntry = new TableEntry() { Team = changeSecondTeamName };
        }

        [Test]
        public void WhatShouldITest()
        {
            // TODO
        }
    }
}