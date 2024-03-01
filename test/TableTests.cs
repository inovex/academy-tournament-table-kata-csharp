namespace TournamentTable.Test
{
    public class TableTests
    {
        [Test]
        public void Constructor_Default_CreatesEmptyTable()
        {
            var table = new Table();

            var tableList = table.GetTable();

            Assert.That(tableList, Is.Empty);
        }
    }
}