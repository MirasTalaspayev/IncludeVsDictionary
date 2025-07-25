using BenchmarkDotNet.Attributes;

namespace IncludeVsDictionary.Benchmarks.KeyValuePairVsHashSetInDictionary;
[MemoryDiagnoser]
public class KeyValuePairVsHashSetInDictionaryBenchmark
{
    HashSet<(int, int)> set = [];
    Dictionary<int, HashSet<int>> dict = [];

    [Params(1, 10, 100, 1000)]
    public int _size;

    public List<int> Keys { get; set; } = [];
    public List<int> Values { get; set; } = [];

    [GlobalSetup]
    public void Setup()
    {
        Keys = new(_size);
        Values = new(_size);

        for (int i = 0; i < _size; i++)
        {
            Keys.Add(Random.Shared.Next(1, _size));
            Values.Add(Random.Shared.Next(_size + 1, _size * 2));
        }
    }

    public void SetInsert()
    {
        for (int i = 0; i < _size; i++)
        {
            set.Add((Keys[i], Values[i]));
        }
    }

    public void DictionaryInsert()
    {
        for (int i = 0; i < _size; i++)
        {
            if (dict.ContainsKey(Keys[i]) == false)
            {
                dict[Keys[i]] = [];
            }
            dict[Keys[i]].Add(Values[i]);
        }
    }

    [Benchmark]
    public void SetGet()
    {
        for (int i = 0; i < _size; i++)
        {
            var _ = set.Contains((Keys[i], Values[i]));
        }
    }

    [Benchmark]
    public void DictoinaryGet()
    {
        for (int i = 0; i < _size; i++)
        {
            var _ = dict.ContainsKey(Keys[i]) == false || dict[Keys[i]].Contains(Values[i]);
        }
    }
}