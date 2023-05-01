namespace MotoApp;

using MotoApp.Repositories;
using MotoApp.Entities;

public class App : IApp
{
    private readonly IRepository<Employee> _employeesRepository;

    public App(IRepository<Employee> employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public void Run()
    {
        Console.WriteLine("I'm here in Run() method");

        var employees = new[]
        {
            new Employee { FirstName = "Adam"},
            new Employee { FirstName = "Piotr"},
            new Employee { FirstName = "Zuzanna"}
        };

        foreach (var employee in employees)
        {
            _employeesRepository.Add(employee);
        }

        _employeesRepository.Save();
        

        //reading
        var items = _employeesRepository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }


    }
}
