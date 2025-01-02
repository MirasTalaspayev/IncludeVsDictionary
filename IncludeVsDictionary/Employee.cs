namespace IncludeVsDictionary;
public class Employee
{
    public int Id { get; set; }
    public int LevelId { get; set; }

    public EmployeeLevel? Level { get; set; }
}