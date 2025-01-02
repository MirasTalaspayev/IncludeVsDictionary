using BenchmarkDotNet.Running;
using IncludeVsDictionary;

// using var dbContext = new AppDbContext();

// var benchmark = new IncludeVsDictionaryBenchmark(dbContext);

//IncludeVsDictionaryBenchmark._dbContext = dbContext;
BenchmarkRunner.Run<IncludeVsDictionaryBenchmark>();


//for (int i = 0; i < 1000; i++)
//{
//    var employee = new Employee
//    {
//        LevelId = Random.Shared.Next(1, 5)
//    };
//    dbContext.Employees.Add(employee);
//}

//dbContext.SaveChanges();