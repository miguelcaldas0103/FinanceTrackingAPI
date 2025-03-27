using FinanceTrackingAPI.DTOs.Expense;
using FinanceTrackingAPI.DTOs.Income;
using FinanceTrackingAPI.Models;

namespace FinanceTrackingAPI.Services
{
    public interface IFinanceService
    {
        Task<CreateExpenseDto> AddExpenseAsync(CreateExpenseDto expenseDto);
        Task<IEnumerable<ExpenseDto>> GetExpensesAsync();
        Task<ExpenseDto> GetExpenseByIdAsync(Guid id);
        Task<UpdateExpenseDto> UpdateExpenseAsync(Guid id, UpdateExpenseDto expenseDto);
        Task<bool> DeleteExpenseAsync(Guid id);

        Task<CreateIncomeDto> AddIncomeAsync(CreateIncomeDto incomeDto);
        Task<IEnumerable<IncomeDto>> GetIncomesAsync();
        Task<IncomeDto> GetIncomeByIdAsync(Guid id);
        Task<UpdateIncomeDto> UpdateIncomeAsync(Guid id, UpdateIncomeDto incomeDto);
        Task<bool> DeleteIncomeAsync(Guid id);
    }
}