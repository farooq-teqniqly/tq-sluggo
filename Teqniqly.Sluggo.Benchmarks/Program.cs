using BenchmarkDotNet.Running;
using Teqniqly.Sluggo.Benchmarks;

BenchmarkRunner.Run<SlugCpuBenchmarks>();
BenchmarkRunner.Run<SlugMemoryBenchmarks>();
