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

        var carsFromDb = _motoAppDbContext.Cars.ToList();

        foreach(var carFromDb in carsFromDb)
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
