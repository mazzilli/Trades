using BenchmarkDotNet.Running;
using Trades.Benchmark;

var summary = BenchmarkRunner.Run<TradeCategorizerBenchmarks>();