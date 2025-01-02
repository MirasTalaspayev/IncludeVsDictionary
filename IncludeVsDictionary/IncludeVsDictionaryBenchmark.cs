using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;

namespace IncludeVsDictionary;

[MemoryDiagnoser]
public class IncludeVsDictionaryBenchmark
{
    public static AppDbContext _dbContext = new();

    //public IncludeVsDictionaryBenchmark(AppDbContext dbContext)
    //{
    //    _dbContext = dbContext;
    //}

    [Benchmark]
    public void GetDataWithSelect()
    {
        _dbContext.Employees
            .AsNoTracking()
            .Select(x => new EmployeeDto
            {
                Id = x.Id,
                LevelId = x.LevelId,
                LevelName = x.Level!.Name
            }).ToList();
    }

    [Benchmark]
    public void GetDataWithSelectAndSplitQuering()
    {
        var employees = _dbContext.Employees
            .AsNoTracking()
            .AsSplitQuery()
            .Select(x => new EmployeeDto
            {
                Id = x.Id,
                LevelId = x.LevelId,
                LevelName = x.Level!.Name
            })
            .ToList();
    }

    [Benchmark]
    public void GetDataWithInclude()
    {
        var employees = _dbContext.Employees
            .AsNoTracking()
            .Include(x => x.Level)
            .ToList();

        var _ = employees.Select(x => new EmployeeDto
        {
            Id = x.Id,
            LevelId = x.LevelId,
            LevelName = x.Level!.Name
        }).ToList();
    }

    [Benchmark]
    public void GetDataWithIncludeAndSplitQuering()
    {
        var employees = _dbContext.Employees
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Level)
            .ToList();

        var _ = employees.Select(x => new EmployeeDto
        {
            Id = x.Id,
            LevelId = x.LevelId,
            LevelName = x.Level!.Name
        }).ToList();
    }

    [Benchmark]
    public void GetDataWithDictionary()
    {
        var dict = _dbContext.EmployeeLevels.ToDictionary(l => l.Id, v => v.Name);
        var employees = _dbContext.Employees.AsNoTracking()
            .ToList();

        var _ = employees.Select(x => new EmployeeDto
        {
            Id = x.Id,
            LevelId = x.LevelId,
            LevelName = dict[x.LevelId]
        }).ToList();
    }
}