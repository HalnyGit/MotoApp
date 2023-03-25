﻿using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.Data;
using MotoApp.Repositories.Extensions;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;

static void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
{
    Console.WriteLine($"Employee added {e.FirstName} from {sender?.GetType().Name}");
}

AddEmployees(employeeRepository);
WriteAllToConsole(employeeRepository);

static void EmployeeAdded(Employee item)
{
    Console.WriteLine($"{item} added");

}


static void AddEmployees(IRepository<Employee> employeeRepository)
{
    var employees = new[]
    {
        new Employee {FirstName = "Adam"},
        new Employee {FirstName = "Dominik"},
        new Employee {FirstName = "Zuzanna"},

    };

    employeeRepository.AddBatch(employees);

    //repository.Add(new Employee { FirstName = "Zuzanna" });
    //repository.Add(new Employee { FirstName = "Dominik" });
    //repository.Add(new Employee { FirstName = "Adam" });
    //repository.Save();
}

//static void AddBatch<T>(IRepository<T> repository, T[] items)
//    where T : class, IEntity
//{
//    foreach (var item in items )
//    {
//        repository.Add(item);
//    }
//    repository.Save();
//}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
