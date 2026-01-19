```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.28020.1371)
AMD Ryzen 7 5700U with Radeon Graphics 1.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.102
  [Host]     : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v3


```
| Method              | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------- |------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| NewRegex            | 1,410.46 ns | 28.076 ns | 26.263 ns |  1.00 |    0.03 | 1.2264 |    2568 B |        1.00 |
| StaticRegexMatch    |    83.19 ns |  0.716 ns |  0.559 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| CompiledRegexMatch  |    34.87 ns |  0.717 ns |  0.907 ns |  0.02 |    0.00 |      - |         - |        0.00 |
| GeneratedRegexMatch |    30.31 ns |  0.600 ns |  0.737 ns |  0.02 |    0.00 |      - |         - |        0.00 |
