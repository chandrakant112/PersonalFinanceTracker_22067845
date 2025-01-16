using PersonalFinanceTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Services
{

    public interface IAddTransactionServices
    {
        Task SaveTransactionAsync(TransactionModel transaction);
        Task<List<TransactionModel>> GetAllTransactionsAsync();

    }

}
