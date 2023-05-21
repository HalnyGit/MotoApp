using System.Text;
namespace MotoApp.Data.Entities;


public class Car : EntityBase
{
    public string Name { get; set; }
    public string Color { get; set; }
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string Type { get; set; }

    // Calculated Properties
    public int? NameLength { get; set; }
    public decimal? TotalSales { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Id: {Id} Name: {Name}");
        sb.AppendLine($"         Color: {Color} Type: {Type ?? "n/a"}");
        sb.AppendLine($"         Cost:  {StandardCost} Price: {ListPrice}");

        return sb.ToString();
    }







}
