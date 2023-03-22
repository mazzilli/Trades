using BenchmarkDotNet.Attributes;
using Trades.App;
using Trades.Domain;

namespace Trades.Benchmark
{
    [MemoryDiagnoser]
    public class TradeCategorizerBenchmarks
    {
        private TradeCategorizer _tradeCategorizer;
        private List<ITrade> _portfolio;

        [Params(1_000_000, 10_000_000)]
        public int QtdTrades { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _tradeCategorizer = new TradeCategorizer(10000, new string[] { "High Risk", "Medium Risk", "Low Risk" });
            _portfolio = new List<ITrade>(QtdTrades);
            for (int i = 0; i < QtdTrades; i++)
            {
                _portfolio.Add(GenerateTrade());
            }
        }

        [Benchmark]
        public void Categorize()
        {
            _tradeCategorizer.Categorize(_portfolio).Count();
        }

        private static Trade GenerateTrade()
        {
            var rnd = new Random();
            return new Trade(rnd.Next(500000, 1500000), rnd.Next(0, 9) % 2 == 0 ? Sector.Private : Sector.Public); ;
        }
    }

}

