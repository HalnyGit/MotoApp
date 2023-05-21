using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;
using MotoApp.Components.DataProviders;
using MotoApp.Components.CsvReader;
using MotoApp.Components.CsvReader.Models;




var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICarsProvider, CarsProvider>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();

string fp = "C:\\Users\\halin\\Projects\\MotoApp\\MotoApp\\MotoApp\\Resources\\Files\\fuel.csv";
List<CarModel> carModels = ProcessCars(fp);






//using MotoApp.Repositories;
//using MotoApp.Entities;
//using MotoApp.Data;
//using MotoApp.Repositories.Extensions;

//// delegat action
//var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);

//// eventhandler
//employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;

//static void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
//{
//    Console.WriteLine($"Employee added {e.FirstName} from {sender?.GetType().Name}");
//}

//AddEmployees(employeeRepository);
//WriteAllToConsole(employeeRepository);

//static void EmployeeAdded(Employee item)
//{
//    Console.WriteLine($"{item} added");

//}


//static void AddEmployees(IRepository<Employee> employeeRepository)
//{
//    var employees = new[]
//    {
//        new Employee {FirstName = "Adam"},
//        new Employee {FirstName = "Dominik"},
//        new Employee {FirstName = "Zuzanna"},

//    };

//    employeeRepository.AddBatch(employees);

//    //repository.Add(new Employee { FirstName = "Zuzanna" });
//    //repository.Add(new Employee { FirstName = "Dominik" });
//    //repository.Add(new Employee { FirstName = "Adam" });
//    //repository.Save();
//}

////static void AddBatch<T>(IRepository<T> repository, T[] items)
////    where T : class, IEntity
////{
////    foreach (var item in items )
////    {
////        repository.Add(item);
////    }
////    repository.Save();
////}

//static void WriteAllToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}

