namespace TournamentTable.Test
{
    public class TableTests
    {
        [Fact]
        public void Constructor_Default_CreatesEmptyTable()
        {
            var table = new Table();

            var tableList = table.GetTable();

            Assert.Empty(tableList);
        }
    }
}