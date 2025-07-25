using BenchmarkDotNet.Attributes;

namespace IncludeVsDictionary.Benchmarks.IfVsWhere;

[MemoryDiagnoser]
public class IfVsWhereBenchmark
{
    [Params(1, 10, 100, 1000)]
    public int _size;

    public List<int> Values { get; set; } = [];

    [GlobalSetup]
    public void Setup()
    {
        Values = new List<int>(_size);
        for (int i = 0; i < _size; i++)
        {
            Values.Add(i);
        }
    }

    [Benchmark]
    public void WhereQuery()
    {
        foreach (int i in Values.Where(x => x % 2 == 0))
        {
            var _ = Values[i];
        }
    }

    [Benchmark]
    public void IfStatement()
    {
        foreach (int i in Values)
        {
            if (i % 2 == 0)
            {
                var _ = Values[i];
            }
        }
    }
}