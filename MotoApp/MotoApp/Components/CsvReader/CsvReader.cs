using MotoApp.Components.CsvReader.Extensions;
using MotoApp.Components.CsvReader.Models;

namespace MotoApp.Components.CsvReader;

public class CsvReader : ICsvReaders
{
    public List<CarModel> ProcessCars(string filePath)
    {
        if(!File.Exists(filePath))
        {
            return new List<CarModel>();
        }
        var cars = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(line => line.Length > 1)
            .ToCarModel();

        return cars.ToList();
    }
}

