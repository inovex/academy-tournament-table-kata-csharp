namespace TournamentTable.Test
{
    public class DefaultPointDistributionBehaviorTests
    {
        IPointDistributionBehavior pointDistributionBehavior;
        ITeam changeFirstTeamName;
        ITeam changeSecondTeamName;
        ITableEntry firstTeamTableEntry;
        ITableEntry secondTableEntry;

        public DefaultPointDistributionBehaviorTests()
        {
            pointDistributionBehavior = new DefaultPointDistributionBehavior();

            changeFirstTeamName = new Team("first");
            changeSecondTeamName = new Team("second");

            firstTeamTableEntry = new TableEntry() { Team = changeFirstTeamName };
            secondTableEntry = new TableEntry() { Team = changeSecondTeamName };
        }

        [Fact]
        public void WhatShouldITest()
        {
            // TODO
        }
    }
}