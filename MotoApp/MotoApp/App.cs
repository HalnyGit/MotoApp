namespace MotoApp;

using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.DataProviders;

public class App : IApp
{
    private readonly IRepository<Employee> _employeesRepository;
    private readonly IRepository<Car> _carsRepository;
    private readonly ICarsProvider _carsProvider;

    public App(
        IRepository<Employee> employeesRepository,
        IRepository<Car> carsRepository,
        ICarsProvider carsProvider)
    {
        _employeesRepository = employeesRepository;
        _carsRepository = carsRepository;
        _carsProvider = carsProvider;
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


        // cars
        var cars = GenerateSampleCars();
        foreach (var car in cars)
        {
            _carsRepository.Add(car);
        }

        foreach(var car in _carsProvider.ChunkCars(2))
        {
            Console.WriteLine(car);
        }

    }

    public static List<Car> GenerateSampleCars()
    {
        return new List<Car>
        {
            new Car
            {
                Id = 1,
                Name = "Fiat",
                Color = "Red",
                StandardCost = 1059.31M,
                ListPrice= 1431.50M,
                Type = "sedan"
            },
            new Car
            {
                Id = 2,
                Name = "Syrena",
                Color = "Yellow",
                StandardCost = 1000.31M,
                ListPrice = 1231.50M,
                Type = "sedan"
            },
            new Car
            {
                Id = 3,
                Name = "Polonez",
                Color = "Blue",
                StandardCost = 1045.31M,
                ListPrice = 1331.50M,
                Type = "hatchback"
            },
            new Car
            {
                Id = 4,
                Name = "Dacia",
                Color = "Red",
                StandardCost = 1001.31M,
                ListPrice = 1251.50M,
                Type = "hatchback"
            }
        };
    }


}
