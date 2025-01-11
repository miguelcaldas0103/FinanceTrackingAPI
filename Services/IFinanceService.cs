using FinanceTrackingAPI.Models;

namespace FinanceTrackingAPI.Services
{
    public interface IFinanceService
    {
        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task AddExpenseAsync(Expense expense);
        Task<Expense> GetExpenseByIdAsync(Guid id);
        Task<bool> DeleteExpenseAsync(Guid id);
    }
}