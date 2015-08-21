using System.Collections.Generic;
using System.Linq;
using Rental.Model.Extraction;

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
    }
}
