``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1413/22H2/2022Update/SunValley2)
AMD Ryzen 7 4800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.100-preview.1.23115.2
  [Host]     : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2


```
|     Method | QtdTrades |      Mean |    Error |   StdDev | Allocated |
|----------- |---------- |----------:|---------:|---------:|----------:|
| **Categorize** |   **1000000** |  **13.93 ms** | **0.013 ms** | **0.012 ms** |     **145 B** |
| **Categorize** |  **10000000** | **139.29 ms** | **1.594 ms** | **1.413 ms** |     **286 B** |
