using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp.DataProviders;

public class CarsProviderBasic : ICarsProvider
{
    private readonly ICarsProvider _carsRepository;

    public CarsProviderBasic(IRepository<Car> carsRepository)
    {
        _carsRepository = carsRepository;
    }

    public decimal GetMinimumPriceOfAllCars()
    {
        throw new NotImplementedException();
    }

    public List<string> GetUniqueCarColors()
    {
        throw new NotImplementedException();
    }

    List<Car> ICarsProvider.FilterCars(decimal minPrice)
    {
        throw new NotImplementedException();
    }
}
