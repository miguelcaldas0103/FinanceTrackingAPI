using FinanceTrackingAPI.DTOs.Expense;
using FinanceTrackingAPI.Models;

namespace FinanceTrackingAPI.Services
{
    public interface IFinanceService
    {
        Task<ExpenseDto> AddExpenseAsync(Expense expense);
        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task<Expense> GetExpenseByIdAsync(Guid id);
        Task<Expense> UpdateExpenseAsync(Guid id, Expense expense);
        Task<bool> DeleteExpenseAsync(Guid id);
        Task<IEnumerable<Income>> GetIncomesAsync();
        Task<Income> AddIncomeAsync(Income income);
        Task<Income> GetIncomeByIdAsync(Guid id);
        Task<Income> UpdateIncomeAsync(Guid id, Income income);
        Task<bool> DeleteIncomeAsync(Guid id);
    }
}