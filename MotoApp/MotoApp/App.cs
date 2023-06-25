namespace MotoApp;

using MotoApp.Components.CsvReader;
using MotoApp.Data;
using MotoApp.Data.Entities;
using System;
using System.Xml.Linq;

public class App : IApp
{
    private readonly ICsvReader _csvReader;
    private readonly MotoAppDbContext _motoAppDbContext;

    public App(ICsvReader csvReader, MotoAppDbContext motoAppDbContext)
    {
        _csvReader = csvReader;
        _motoAppDbContext = motoAppDbContext;
        _motoAppDbContext.Database.EnsureCreated();
    }

    public void Run()
    {
        // InsertData();
        // ReadAllCarsFromDb();
        // ReadGroupCarsFromDb();

        //var cayman = ReadFirst("0000");
        //cayman.Name = "Cayman";
        //_motoAppDbContext.SaveChanges();

        var cayman = ReadFirst("Cayman");
        _motoAppDbContext.Cars.Remove(cayman);
        _motoAppDbContext.SaveChanges();
    }

    public Car? ReadFirst(string name)
    {
        return _motoAppDbContext.Cars.FirstOrDefault(c => c.Name == name);
    }


    private void ReadGroupCarsFromDb()
    {
        var groups = _motoAppDbContext
            .Cars
            .GroupBy(c => c.Manufacturer)
            .Select(c => new
            {
                Name = c.Key,
                Cars = c.ToList()
            })
            .ToList();

        foreach(var group in groups)
        {
            Console.WriteLine(group.Name);
            Console.WriteLine("=========");
            foreach(var car in group.Cars)
            {
                Console.WriteLine($"\t{car.Name}:{car.Combined}");
            }
            Console.WriteLine();
        }


    }

    private void ReadAllCarsFromDb()
    {
        var carsFromDb = _motoAppDbContext.Cars.ToList();

        foreach (var carFromDb in carsFromDb)
        {
            Console.WriteLine($"\t{carFromDb.Name} : {carFromDb.Combined}");
        }
    }

    private void InsertData()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");

        foreach (var car in cars)
        {
            _motoAppDbContext.Cars.Add(new Car()
            {
                Manufacturer = car.Manufacturer,
                Name = car.Name,
                Year = car.Year,
                City = car.City,
                Combined = car.Combined,
                Cylinders = car.Cylinders,
                Displacement = car.Displacement,
                Highway = car.Highway,
            });
        }
        _motoAppDbContext.SaveChanges();
    }
}
