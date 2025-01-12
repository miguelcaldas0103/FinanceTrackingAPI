using FinanceTrackingAPI.Models;

namespace FinanceTrackingAPI.Services
{
    public interface IFinanceService
    {
        Task AddExpenseAsync(Expense expense);
        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task<Expense> GetExpenseByIdAsync(Guid id);
        Task<Expense> UpdateExpenseAsync(Guid id, Expense updatedExpense);
        Task<bool> DeleteExpenseAsync(Guid id);
        Task<IEnumerable<Income>> GetIncomesAsync();
        Task AddIncomeAsync(Income income);
        Task<Income> GetIncomeByIdAsync(Guid id);
        Task<Income> UpdateIncomeAsync(Guid id, Income updatedIncome);
        Task<bool> DeleteIncomeAsync(Guid id);
    }
}