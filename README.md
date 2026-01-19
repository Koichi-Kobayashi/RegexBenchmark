[English](README.md) | [日本語](README.ja.md)

# .NET Regex Performance Benchmark (NET 6 → 10)

This repository contains **BenchmarkDotNet-based measurements** that visualize
how **regular expression (Regex) performance has improved from .NET 6 to .NET 10**.

The goal is to answer a simple but important question:

> *Does upgrading .NET make Regex faster — and how much does coding style matter?*

---

## Benchmark Overview

### Tested Regex Patterns

- Input string: `2026-01-19`
- Pattern: `^\d{4}-\d{2}-\d{2}$`

### Compared Approaches

- `new Regex()` (created every time)
- `static Regex`
- `RegexOptions.Compiled`
- `GeneratedRegex` (Source Generator, .NET 7+)

All benchmarks were executed in **Release mode** using **BenchmarkDotNet**.

---

## Benchmark Results (Mean)

| .NET | NewRegex | StaticRegex | CompiledRegex | GeneratedRegex |
|------|----------|-------------|---------------|----------------|
| 6 | 2.999 µs | 194.23 ns | 41.30 ns | — |
| 7 | 2.065 µs | 115.57 ns | 39.94 ns | 40.98 ns |
| 8 | 1.620 µs | 89.65 ns | 38.20 ns | 36.50 ns |
| 9 | 1.410 µs | 83.19 ns | 34.87 ns | 30.31 ns |
| 10 | 1.363 µs | 86.49 ns | 27.91 ns | 23.45 ns |

---

## Key Findings

### 1. .NET Runtime Improvements Are Real

- All approaches are faster in newer .NET versions
- `new Regex()` and `static Regex` are **over 2× faster** from .NET 6 to .NET 10

### 2. Coding Style Matters More Than Runtime Version

- Even on .NET 10:
  - `new Regex()` ≈ **1.36 µs**
  - `GeneratedRegex` ≈ **24 ns**
- That is a **~60× difference**

### 3. GeneratedRegex Is the Modern Best Practice

- Zero runtime parsing
- Zero allocations
- Best performance on .NET 7+

---

## Practical Recommendations

| Scenario | Recommendation |
|--------|----------------|
| Fixed patterns | `GeneratedRegex` |
| Dynamic/user input patterns | `CompiledRegex` or cached `Regex` |
| UI / filtering / search | **Never use `new Regex()`** |

---

## Why This Matters

In UI applications (WPF, WinUI, MAUI, etc.):

- Regex is often executed **thousands of times per second**
- Allocations and microsecond delays directly affect responsiveness

This benchmark demonstrates **why Regex usage must be intentional** in modern .NET.

---

## How to Run the Benchmark

```bash
dotnet restore
dotnet run -c Release -f net6.0
dotnet run -c Release -f net7.0
dotnet run -c Release -f net8.0
dotnet run -c Release -f net9.0
dotnet run -c Release -f net10.0
```

Benchmark results will be generated under:

BenchmarkDotNet.Artifacts/results/

---

## License

MIT License
