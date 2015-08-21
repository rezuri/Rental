using System.Collections.Generic;
using Rental.Model.Extraction;

namespace Rental.DataAccess
{
    public interface ITransactionRepository
    {
        IList<TransactionCriteria> GetTransactionCriterias(bool isActive);
    }
}
