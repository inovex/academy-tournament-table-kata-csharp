namespace TournamentTable
{
    public interface ICoefficientClient
    {
        public int GetCoefficient(ITeam team);
    }

    public class CoefficientClient : ICoefficientClient
    {
        public int GetCoefficient(ITeam team)
        {
            throw new NotImplementedException();
        }
    }
}
