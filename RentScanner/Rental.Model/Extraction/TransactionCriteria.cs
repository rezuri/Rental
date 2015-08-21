namespace Rental.Model.Extraction
{
    public class TransactionCriteria
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
        public string Keyword { get; set; }
        public bool IsExpenditure { get; set; }
        public bool IsRental { get; set; }
        public bool IsActive { get; set; }
    }
}
