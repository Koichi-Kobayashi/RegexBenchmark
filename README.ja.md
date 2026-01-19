[English](README.md) | [日本語](README.ja.md)

# .NET Regex パフォーマンスベンチマーク（.NET 6 → 10）

このリポジトリでは、**BenchmarkDotNet を用いた実測結果**をもとに  
**.NET 6 から .NET 10 にかけて正規表現（Regex）がどれだけ高速化されたか**を可視化しています。

本ベンチマークで検証したいポイントは次の1点です。

> **.NET の世代進化と、Regex の書き方は、パフォーマンスにどれほど影響するのか？**

---

## ベンチマーク概要

### テスト条件

- 入力文字列: `2026-01-19`
- 正規表現: `^\d{4}-\d{2}-\d{2}$`
- 実行モード: Release
- 使用ツール: BenchmarkDotNet

### 比較した Regex の書き方

- `new Regex()`（毎回生成）
- `static Regex`
- `RegexOptions.Compiled`
- `GeneratedRegex`（.NET 7 以降）

---

## 実測結果（Mean）

| .NET | NewRegex | StaticRegex | CompiledRegex | GeneratedRegex |
|------|----------|-------------|---------------|----------------|
| 6 | 2.999 µs | 194.23 ns | 41.30 ns | — |
| 7 | 2.065 µs | 115.57 ns | 39.94 ns | 40.98 ns |
| 8 | 1.620 µs | 89.65 ns | 38.20 ns | 36.50 ns |
| 9 | 1.410 µs | 83.19 ns | 34.87 ns | 30.31 ns |
| 10 | 1.363 µs | 86.49 ns | 27.91 ns | 23.45 ns |

---

## 分かったこと

### 1. .NET の進化による高速化は確実にある

- .NET 6 → 10 で全手法が高速化
- 特に `new Regex()` / `static Regex` は **約2倍以上改善**

### 2. しかし最大の差は「書き方」

- .NET 10 においても  
  - `new Regex()` : 約 **1.36 µs**
  - `GeneratedRegex` : 約 **24 ns**
- **約60倍の差**

### 3. GeneratedRegex は現代 .NET の最適解

- 実行時解析なし
- メモリアロケーションなし
- UI スレッドでも安全に使用可能

---

## 実務向け指針

| ケース | 推奨 |
|------|------|
| 固定パターン | `GeneratedRegex` |
| 動的 Regex | `CompiledRegex` またはキャッシュ |
| UI / 検索 / フィルタ | **`new Regex()` は使用しない** |

---

## なぜ重要か

WPF や WinUI などの UI アプリでは、

- Regex が短時間に大量実行される
- わずかな遅延や GC が体感性能に直結する

このリポジトリは、  
**Regex を正しく使うことの重要性を実測で示す資料**です。

---

## ベンチマークの実行方法

```bash
dotnet restore
dotnet run -c Release -f net6.0
dotnet run -c Release -f net7.0
dotnet run -c Release -f net8.0
dotnet run -c Release -f net9.0
dotnet run -c Release -f net10.0
```

結果は以下に出力されます。

BenchmarkDotNet.Artifacts/results

---

## ライセンス

MIT License