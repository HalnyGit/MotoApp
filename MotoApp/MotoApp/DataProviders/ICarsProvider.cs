namespace MotoApp.DataProviders;
using MotoApp.Entities;


public interface ICarsProvider
{
    List<Car> FilterCars(decimal minPrice);

    List<string> GetUniqueCarColors();

    decimal GetMinimumPriceOfAllCars();




}
