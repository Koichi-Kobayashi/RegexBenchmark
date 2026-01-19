[English](README.md) | [日本語](README.ja.md)

# .NET Regex パフォーマンスベンチマーク（.NET 6 → 10）

このリポジトリでは、**BenchmarkDotNet による実測結果**をもとに、
.NET 6 から .NET 10 にかけての **正規表現（Regex）パフォーマンスの変化**をまとめています。

記載されている数値はすべて **実測値**です。

---

## ベンチマーク条件

- OS: Windows 11 Pro 26H1
- CPU: AMD Ryzen 7 5700U with Radeon Graphics (1.80 GHz)
- RAM: 32GB
- 入力文字列: `2026-01-19`
- 正規表現: `^\d{4}-\d{2}-\d{2}$`
- 実行モード: Release
- 使用ツール: BenchmarkDotNet

### 比較対象

- `new Regex()`
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
| 10 | **1446 ns（約 1.45 µs）** | 86.49 ns | 27.91 ns | **24.53 ns** |

> ※ BenchmarkDotNet の Mean 値を使用  
> ※ 可読性のため ns → µs 変換を行っています  
> （例: 1445.96 ns ≒ 1.45 µs）

<img width="567" height="455" alt="2026-01-20_00h04_19" src="https://github.com/user-attachments/assets/9829edb0-ce13-4873-ab77-0b77e7b5361a" />
<img width="584" height="455" alt="2026-01-20_00h04_24" src="https://github.com/user-attachments/assets/8216e9e4-c39b-4e76-a4db-ef346eeef6c3" />

使い方によっては**約60倍**の差が出る

---

## 「約 60 倍」の根拠

.NET 10 の実測値:

- `new Regex()` : **1445.96 ns**
- `GeneratedRegex` : **24.53 ns**

計算式:

```
1445.96 ÷ 24.53 ≒ 58.9
```

このため、本リポジトリおよび関連ブログでは

> **「約 60 倍の差」**

と表現しています。  
これは **推測ではなく、実測値から直接導かれた結果**です。

---

## 実務向け指針

| ケース | 推奨 |
|------|------|
| 固定パターン | `GeneratedRegex` |
| 動的 Regex | `CompiledRegex` / キャッシュ |
| UI・検索・フィルタ | **`new Regex()` は避ける** |

---

## ベンチマーク実行方法

```bash
dotnet restore
dotnet run -c Release -f net6.0
dotnet run -c Release -f net7.0
dotnet run -c Release -f net8.0
dotnet run -c Release -f net9.0
dotnet run -c Release -f net10.0
```

結果出力先:

```
BenchmarkDotNet.Artifacts/results/
```

---

## ライセンス

MIT License
