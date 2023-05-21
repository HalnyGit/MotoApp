using MotoApp.Components.CsvReader.Models;

namespace MotoApp.Components.CsvReader;

public interface ICsvReader
{
    List<CarModel> ProcessCars(string filePath);
    List<Manufacturer> ProcessManufacturers(string filePath);

}
