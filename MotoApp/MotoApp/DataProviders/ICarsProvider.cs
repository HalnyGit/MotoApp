namespace MotoApp.DataProviders;
using MotoApp.Entities;


public interface ICarsProvider
{

    List<string> GetUniqueCarColors();

    decimal GetMinimumPriceOfAllCars();
    List<Car> FilterCars(decimal minPrice);

    List<Car> GetSpecificColumns();

    string AnonymousClass();

}
