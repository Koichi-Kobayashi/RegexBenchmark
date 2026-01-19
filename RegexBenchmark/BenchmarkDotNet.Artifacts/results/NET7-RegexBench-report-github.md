```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.28020.1371)
AMD Ryzen 7 5700U with Radeon Graphics 1.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.102
  [Host]     : .NET 7.0.20 (7.0.20, 7.0.2024.26716), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 7.0.20 (7.0.20, 7.0.2024.26716), X64 RyuJIT x86-64-v3


```
| Method              | Mean        | Error     | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------- |------------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| NewRegex            | 2,064.73 ns | 47.273 ns | 137.898 ns |  1.00 |    0.09 | 1.2589 |    2640 B |        1.00 |
| StaticRegexMatch    |   115.57 ns |  1.843 ns |   1.633 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| CompiledRegexMatch  |    39.94 ns |  0.802 ns |   1.295 ns |  0.02 |    0.00 |      - |         - |        0.00 |
| GeneratedRegexMatch |    40.98 ns |  0.818 ns |   1.250 ns |  0.02 |    0.00 |      - |         - |        0.00 |
