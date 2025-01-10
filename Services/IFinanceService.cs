using FinanceTrackingAPI.Models;

namespace FinanceTrackingAPI.Services
{
    public interface IFinanceService
    {
        IEnumerable<Expense> GetExpenses();
        Task AddExpenseAsync(Expense expense);
    }
}