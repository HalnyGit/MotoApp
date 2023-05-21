using MotoApp.Components.CsvReader.Models;

namespace MotoApp.Components.CsvReader.Extensions;

public static class CarModelExtensions
{
    public static IEnumerable<CarModel> ToCarModel(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var columns = line.Split(',');

            yield return new CarModel
            {
                Year = int.Parse(columns[0]),
                Manufacturer = columns[1],
                Name = columns[2],
                Displacement = double.Parse(columns[3]),
                Cylinders = int.Parse(columns[4]),
                City = int.Parse(columns[5]),
                Highway = int.Parse(columns[6]),
                Combined = int.Parse(columns[7]),
            };
        }
    }

}
