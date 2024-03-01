namespace TournamentTable
{
    public class Program
    {
        static void Main(string[] args)
        {
            var germany = new Team("Germany");
            var netherlands = new Team("Netherlands");
            var england = new Team("England");
            var italy = new Team("Italy");

            var table = new Table();

            // First round
            var germanAgainstNetherlands = new GameResult(germany, netherlands, 1, 0);
            var italyAgainstEngland = new GameResult(italy, england, 2, 3);
            table.BookGameResultToTable(germanAgainstNetherlands);
            table.BookGameResultToTable(italyAgainstEngland);

            // Second round
            var germanAgainstItaly = new GameResult(germany, italy, 4, 2);
            var netherlandsAgainstEngland = new GameResult(netherlands, england, 2, 3);
            table.BookGameResultToTable(germanAgainstItaly);
            table.BookGameResultToTable(netherlandsAgainstEngland);

            // Third round
            var germanAgainstEngland = new GameResult(germany, england, 1, 0);
            var italyAgainstNetherlands = new GameResult(italy, netherlands, 2, 2);
            table.BookGameResultToTable(germanAgainstEngland);
            table.BookGameResultToTable(italyAgainstNetherlands);

            Console.WriteLine(table.ToString());
        }
    }
}