namespace TournamentTable.Test
{
    public class DefaultGoalStatisticCaretakerTests
    {
        [Test]
        public void MaintainGoalStatistic_SomeGoals_AddGoalsToTableEntry()
        {
            var scoredGoals = 3;
            var takenGoals = 2;
            var tableEntry = new TableEntry { Team = new Team("Germany") };
            var defaultGoalStatisticCaretaker = new DefaultGoalStatisticCaretaker();

            defaultGoalStatisticCaretaker.MaintainGoalStatistic(tableEntry, scoredGoals, takenGoals);

            Assert.That(tableEntry.GoalsScored, Is.EqualTo(scoredGoals));
            Assert.That(tableEntry.GoalsAgainst, Is.EqualTo(takenGoals));
        }
    }
}