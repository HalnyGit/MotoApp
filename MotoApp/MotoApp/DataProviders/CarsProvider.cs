using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp.DataProviders;

public class CarsProvider : ICarsProvider
{
    private readonly IRepository<Car> _carsRepository;

    public CarsProvider(IRepository<Car> carsRepository)
    {
        _carsRepository = carsRepository;
    }

    public List<Car> FilterCars(decimal minPrice)
    {
        throw new NotImplementedException();
    }

    public decimal GetMinimumPriceOfAllCars()
    {
        var cars = _carsRepository.GetAll();
        var minPrice = cars.Select(x => x.ListPrice).Min();
        return minPrice;
    }

    public List<Car> GetSpecificColumns()
    {
        var cars = _carsRepository.GetAll();
        var list = cars.Select(car => new Car
        {
            Id = car.Id,
            Name = car.Name,
            Type= car.Type,
        }).ToList();

        return list;
    }

    public List<string> GetUniqueCarColors()
    {
       var cars = _carsRepository.GetAll();
       var colors = cars.Select(x => x.Color).Distinct().ToList();
       return colors;
    }

    public string AnonymousClass()
    {
        var cars = _carsRepository.GetAll();
        var list = cars.Select(car => new
        {
            Identifier = car.Id,
            ProductName = car.Name,
            ProductType = car.Type,
        });

        return $"{car.Identifier}, {car.ProductName}, {car.ProductType}";
    }
}
