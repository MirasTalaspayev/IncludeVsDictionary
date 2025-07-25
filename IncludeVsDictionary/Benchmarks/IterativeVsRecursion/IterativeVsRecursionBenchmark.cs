using BenchmarkDotNet.Attributes;

namespace IncludeVsDictionary.Benchmarks.IterativeVsRecursion;

[MemoryDiagnoser]
public class IterativeVsRecursionBenchmark
{
    [Params(1, 10, 100, 1000)]
    public int _size;

    [Benchmark]
    public void Iterative()
    {
        int result = 0;
        for (int i = 1; i <= _size; i++)
        {
            result += i;
        }
    }

    [Benchmark]
    public void Recusrsion()
    {
        int result = R(_size);
    }

    private int R(int n)
    {
        if (n == 1)
        {
            return 1;
        }

        return n + R(n - 1);
    }
}