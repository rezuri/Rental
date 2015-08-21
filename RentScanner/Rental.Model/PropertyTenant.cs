namespace Rental.Model
{
    public class PropertyTenant
    {
        public int Id { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual Property Property { get; set; }
    }
}
