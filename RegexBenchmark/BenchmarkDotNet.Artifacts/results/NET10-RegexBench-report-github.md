```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.28020.1371)
AMD Ryzen 7 5700U with Radeon Graphics 1.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.102
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method              | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------- |------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| NewRegex            | 1,362.78 ns | 26.325 ns | 33.293 ns |  1.00 |    0.03 | 1.2264 |    2568 B |        1.00 |
| StaticRegexMatch    |    86.49 ns |  1.651 ns |  1.695 ns |  0.06 |    0.00 |      - |         - |        0.00 |
| CompiledRegexMatch  |    27.91 ns |  0.574 ns |  1.160 ns |  0.02 |    0.00 |      - |         - |        0.00 |
| GeneratedRegexMatch |    23.45 ns |  0.485 ns |  0.726 ns |  0.02 |    0.00 |      - |         - |        0.00 |
