using System;
using System.Collections.Generic;
using System.Linq;
using Rental.Model;

namespace Rental.DataAccess
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly RentalContext _context;

        public TransactionRepository(RentalContext context)
        {
            _context = context;
        }

        public IList<TransactionCriteria> GetTransactionCriterias(bool isActive)
        {
            var test = _context.TransactionCriterias.ToList();

            var query = from tc in _context.TransactionCriterias select tc;

            if (isActive)
                query = query.Where(x => x.IsActive);

            return query.ToList();
        }

        public IList<TransactionItem> GetTransactionItems(DateTime earliestDate)
        {
            return _context.TransactionItems.Where(t => t.TransactionDate >= earliestDate.Date).ToList();
        }

        public void SaveTransactionItems(IList<TransactionItem> transactionItems)
        {
            _context.TransactionItems.AddRange(transactionItems);
            _context.SaveChanges();
        }
    }
}
