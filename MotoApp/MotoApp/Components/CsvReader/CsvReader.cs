using MotoApp.Components.CsvReader.Extensions;
using MotoApp.Components.CsvReader.Models;

namespace MotoApp.Components.CsvReader;

public class CsvReader : ICsvReader
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

    public List<Manufacturer> ProcessManufacturers(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Manufacturer>();
        }
        var manufacturers = File.ReadAllLines(filePath)
            .Where(line => line.Length > 1)
            .Select(line =>
            {
                var columns = line.Split(',');
                return new Manufacturer()
                {
                    Name = columns[0],
                    Country = columns[1],
                    Year = int.Parse(columns[2])
                };
            });
        return manufacturers.ToList();
    }
}

