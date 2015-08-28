using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Rental.Model;

namespace Rental.DataAccess
{
    public class RentalContext : DbContext
    {
        public RentalContext()
            : base("Rental-ConnectionString")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyTenant> PropertyTenants { get; set; }
        public DbSet<TransactionCriteria> TransactionCriterias { get; set; }
        public DbSet<TransactionItem> TransactionItems { get; set; }
    }
}
