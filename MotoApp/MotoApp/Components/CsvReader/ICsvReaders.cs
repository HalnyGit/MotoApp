using MotoApp.Components.CsvReader.Models;

namespace MotoApp.Components.CsvReader;

public interface ICsvReaders
{
    List<CarModel> ProcessCars(string filePath);

}
