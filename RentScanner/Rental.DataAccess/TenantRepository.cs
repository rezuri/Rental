using System.Data.Entity;
using System.Linq;

namespace Rental.DataAccess
{
    public class TenantRepository
    {

        public void SaveTest()
        {
            //var tenant = new Tenant
            //{
            //    FirstName = "Joe",
            //    Surname = "Blog",
            //    IsActive = true
            //};

            using (var context = new RentalContext())
            {
                //context.Tenant.Add(tenant);
                //context.Entry(tenant).State = EntityState.Added;
                //context.SaveChanges();

                var test = context.Tenants.ToList();
                var x = 1;

            }


        }
    }
}
