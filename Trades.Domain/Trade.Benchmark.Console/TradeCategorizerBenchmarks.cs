using BenchmarkDotNet.Attributes;
using Trades.App;
using Trades.Domain;

namespace Trade.Benchmark.Console
{
    [MemoryDiagnoser]
    internal class TradeCategorizerBenchmarks
    {

        private readonly TradeCategorizer _tradeCategorizer;
        private readonly List<ITrade> _portfolio;

        public TradeCategorizerBenchmarks()
        {
            _tradeCategorizer = new TradeCategorizer(10000, new string[] { "High Risk", "Medium Risk", "Low Risk" });
            _portfolio = new List<Trade>
        {
            new Trade("Private",5000),
            new Trade("Public", 20000),
            new Trade("Public", 15000),
            new Trade("Private", 12000),
            new Trade("Private", 8000),
            new Trade("Public", 25000),
            new Trade("Public", 18000),
            new Trade("Private", 10000),
            new Trade("Private", 6000),
            new Trade("Public", 22000),
        };
        }

        [Benchmark]
        public void Categorize()
        {
            _tradeCategorizer.Categorize(_portfolio);
        }
    }
}
