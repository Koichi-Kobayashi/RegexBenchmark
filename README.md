[English](README.md) | [日本語](README.ja.md)

# .NET Regex Performance Benchmark (NET 6 → 10)

This repository contains **BenchmarkDotNet-based measurements** that visualize
how **regular expression (Regex) performance has improved from .NET 6 to .NET 10**.

All numbers shown here are derived from **actual measured data**.

---

## Benchmark Overview

- Input string: `2026-01-19`
- Pattern: `^\d{4}-\d{2}-\d{2}$`
- Mode: Release
- Tool: BenchmarkDotNet

### Compared Approaches

- `new Regex()`
- `static Regex`
- `RegexOptions.Compiled`
- `GeneratedRegex` (Source Generator, .NET 7+)

---

## Benchmark Results (Mean)

| .NET | NewRegex | StaticRegex | CompiledRegex | GeneratedRegex |
|------|----------|-------------|---------------|----------------|
| 6 | 2.999 µs | 194.23 ns | 41.30 ns | — |
| 7 | 2.065 µs | 115.57 ns | 39.94 ns | 40.98 ns |
| 8 | 1.620 µs | 89.65 ns | 38.20 ns | 36.50 ns |
| 9 | 1.410 µs | 83.19 ns | 34.87 ns | 30.31 ns |
| 10 | **1.446 µs (1446 ns)** | 86.49 ns | 27.91 ns | **24.53 ns** |

> Note: Values are means reported by BenchmarkDotNet.  
> For readability, microseconds (µs) are used when appropriate.  
> Example: **1445.96 ns ≈ 1.446 µs**.

<img width="567" height="455" alt="2026-01-20_00h04_19" src="https://github.com/user-attachments/assets/9829edb0-ce13-4873-ab77-0b77e7b5361a" />
<img width="584" height="455" alt="2026-01-20_00h04_24" src="https://github.com/user-attachments/assets/8216e9e4-c39b-4e76-a4db-ef346eeef6c3" />

Depending on how regular expressions are used, performance differences of up to **approximately 60×** can be observed.

---

## Where Does “~60× Slower” Come From?

In .NET 10:

- `new Regex()` mean: **1445.96 ns**
- `GeneratedRegex` mean: **24.53 ns**

Calculation:

```
1445.96 ns / 24.53 ns ≈ 58.9×
```

This is why the documentation states:

> **“Even on .NET 10, new Regex() is about ~60× slower than GeneratedRegex.”**

This value is **directly derived from measured data**, not an estimate.

---

## Practical Recommendations

| Scenario | Recommendation |
|--------|----------------|
| Fixed patterns | `GeneratedRegex` |
| Dynamic patterns | `CompiledRegex` or cached `Regex` |
| UI / filtering / search | **Avoid `new Regex()`** |

---

## How to Run

```bash
dotnet restore
dotnet run -c Release -f net6.0
dotnet run -c Release -f net7.0
dotnet run -c Release -f net8.0
dotnet run -c Release -f net9.0
dotnet run -c Release -f net10.0
```

Results are generated under:

```
BenchmarkDotNet.Artifacts/results/
```

---

## License

MIT License
