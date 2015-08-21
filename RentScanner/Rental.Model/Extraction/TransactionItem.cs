using System;

namespace Rental.Model.Extraction
{
    public class TransactionItem
    {
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}
