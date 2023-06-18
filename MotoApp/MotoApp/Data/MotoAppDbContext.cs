namespace MotoApp.Data
{

    using Microsoft.EntityFrameworkCore;
    using MotoApp.Data.Entities;

    public class MotoAppDbContext : DbContext
    {
        public MotoAppDbContext(DbContextOptions<MotoAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }


        // below set up for Entity Framwork in Memory:
        //public DbSet<Employee> Employees => Set<Employee>();
        //public DbSet<BusinessPartner> BusinessPartners => Set<BusinessPartner>();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        //}

    }
}
