using MotoApp.Entities;

namespace MotoApp.DataProviders;

public class CarsProvider : ICarsProvider
{
    public List<Car> FilterCars(decimal minPrice)
    {
        throw new NotImplementedException();
    }

    public decimal GetMinimumPriceOfAllCars()
    {
        throw new NotImplementedException();
    }

    public List<string> GetUniqueCarColors()
    {
        throw new NotImplementedException();
    }
}
