using Trades.Domain;

namespace Trades.App
{
    public interface ITradeCategorizer
    {
        IEnumerable<string> Categorize(List<ITrade> portfolio);
    }
}