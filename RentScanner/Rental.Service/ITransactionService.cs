using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Service
{
    public interface ITransactionService
    {
        void ProcessTransactions(string fullPathFileName);
    }
}
