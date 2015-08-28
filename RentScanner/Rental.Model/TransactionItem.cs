using System;

namespace Rental.Model
{
    public class TransactionItem
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool IsRental { get; set; }
        public bool IsExpenditure { get; set; }

        public bool Equals(TransactionItem obj)
        {
            return TransactionDate.Equals(obj.TransactionDate) && Amount.Equals(obj.Amount) &&
                   Description.Equals(obj.Description);
        }
    }
}
