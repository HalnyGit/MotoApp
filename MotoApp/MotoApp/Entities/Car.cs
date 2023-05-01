using System.Text;
namespace MotoApp.Entities;


public class Car : EntityBase
{
    public string Name { get; set; }
    public string Color { get; set; }
    public string StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string Type { get; set; }

    // Calculated Properties
    public int? NameLength { get; set; }
    public decimal? TotalSales { get; set; }







}
