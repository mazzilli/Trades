using BenchmarkDotNet.Running;
using Trade.Benchmark.Console;

var summary = BenchmarkRunner.Run<TradeCategorizerBenchmarks>();