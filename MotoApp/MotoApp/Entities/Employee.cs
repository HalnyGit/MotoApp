namespace MotoApp.Entities
{
    public class Employee: EntityBase
    {
        public string? FirstName { get; set; } //? accept null values

        public override string ToString() => $"Id: {Id}, FirstName {FirstName}";
    }
}
