using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text.RegularExpressions;

BenchmarkRunner.Run<RegexBench>();

[MemoryDiagnoser]
public partial class RegexBench
{
    private const string Input = "2026-01-19";
    private const string Pattern = @"^\d{4}-\d{2}-\d{2}$";

    // ① 毎回 new（Baseline）
    [Benchmark(Baseline = true)]
    public bool NewRegex()
        => new Regex(Pattern).IsMatch(Input);

    // ② static Regex（解析済みを使い回し）
    private static readonly Regex StaticRegex = new Regex(Pattern);

    [Benchmark]
    public bool StaticRegexMatch()
        => StaticRegex.IsMatch(Input);

    // ③ Compiled（JIT 生成コード）
    private static readonly Regex CompiledRegex =
        new Regex(Pattern, RegexOptions.Compiled);

    [Benchmark]
    public bool CompiledRegexMatch()
        => CompiledRegex.IsMatch(Input);

#if NET7_0_OR_GREATER
    // ④ Source Generator（.NET7+）
    [GeneratedRegex(@"^\d{4}-\d{2}-\d{2}$")]
    private static partial Regex Generated();

    [Benchmark]
    public bool GeneratedRegexMatch()
        => Generated().IsMatch(Input);
#endif
}
