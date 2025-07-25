namespace IncludeVsDictionary;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class DelegateVsIfStatementBenchmark
{
    private bool IsTrue = true;

    [Params(1, 10, 100)]
    public int _size;

    [Benchmark]
    public void Delegate()
    {
        LinkedList<int> Items = [];
        var func = (LinkedList<int> list, int item) => IsTrue ? list.AddFirst(item) : list.AddLast(item);
        for (int i = 0; i < _size; i++)
        {
            func(Items, i);
        }
    }

    [Benchmark]
    public void IfStatement()
    {
        LinkedList<int> Items = [];
        for (int i = 0; i < _size; i++)
        {
            if (IsTrue)
            {
                Items.AddFirst(i);
            }
            else
            {
                Items.AddLast(i);
            }
        }
    }
}