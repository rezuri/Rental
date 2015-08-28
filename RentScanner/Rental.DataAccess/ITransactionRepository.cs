using System;
using System.Collections.Generic;
using Rental.Model;

namespace Rental.DataAccess
{
    public interface ITransactionRepository
    {
        IList<TransactionCriteria> GetTransactionCriterias(bool isActive);
        IList<TransactionItem> GetTransactionItems(DateTime earliestDate);
        void SaveTransactionItems(IList<TransactionItem> transactionItems);
    }
}
