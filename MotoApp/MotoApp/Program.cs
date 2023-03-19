using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.Data;


var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
AddEmployees(employeeRepository);
AddManagers(employeeRepository);
WriteAllToConsole(employeeRepository);


static void AddEmployees(IRepository<Employee> repository)
{
    repository.Add(new Employee { FirstName = "Zuzanna" });
    repository.Add(new Employee { FirstName = "Dominik" });
    repository.Add(new Employee { FirstName = "Adam" });
    repository.Save();
}

static void AddManagers(IWriteRepository<Manager> repository)
{
    repository.Add(new Manager { FirstName = "Stefan" });
    repository.Add(new Manager { FirstName = "Witold" });
    repository.Save();
}


static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
   var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

