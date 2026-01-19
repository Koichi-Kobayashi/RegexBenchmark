```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.28020.1371)
AMD Ryzen 7 5700U with Radeon Graphics 1.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.102
  [Host]     : .NET 6.0.36 (6.0.36, 6.0.3624.51421), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 6.0.36 (6.0.36, 6.0.3624.51421), X64 RyuJIT x86-64-v3


```
| Method             | Mean        | Error      | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------- |------------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| NewRegex           | 2,999.02 ns | 100.609 ns | 291.885 ns |  1.01 |    0.14 | 1.5755 |    3296 B |        1.00 |
| StaticRegexMatch   |   194.23 ns |   4.039 ns |  11.459 ns |  0.07 |    0.01 |      - |         - |        0.00 |
| CompiledRegexMatch |    41.30 ns |   0.859 ns |   1.117 ns |  0.01 |    0.00 |      - |         - |        0.00 |
