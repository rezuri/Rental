namespace Rental.Model
{
    public class Property
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public int PostCode { get; set; }
        public bool IsActive { get; set; }
    }
}
