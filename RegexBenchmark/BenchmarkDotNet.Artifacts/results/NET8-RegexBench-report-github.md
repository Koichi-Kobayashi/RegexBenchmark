```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.28020.1371)
AMD Ryzen 7 5700U with Radeon Graphics 1.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.102
  [Host]     : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 8.0.23 (8.0.23, 8.0.2325.60607), X64 RyuJIT x86-64-v3


```
| Method              | Mean        | Error     | StdDev     | Median      | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------- |------------:|----------:|-----------:|------------:|------:|--------:|-------:|----------:|------------:|
| NewRegex            | 1,620.03 ns | 38.724 ns | 112.346 ns | 1,587.23 ns |  1.00 |    0.10 | 1.2131 |    2552 B |        1.00 |
| StaticRegexMatch    |    89.65 ns |  1.680 ns |   2.899 ns |    89.27 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| CompiledRegexMatch  |    38.20 ns |  0.795 ns |   1.494 ns |    37.68 ns |  0.02 |    0.00 |      - |         - |        0.00 |
| GeneratedRegexMatch |    36.50 ns |  0.546 ns |   0.456 ns |    36.59 ns |  0.02 |    0.00 |      - |         - |        0.00 |
