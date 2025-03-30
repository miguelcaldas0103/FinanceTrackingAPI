using FinanceTrackingAPI.DTOs.Expense;
using FinanceTrackingAPI.DTOs.Income;

namespace FinanceTrackingAPI.Services
{
    public interface IFinanceService
    {
        Task<ExpenseDto> AddExpenseAsync(CreateExpenseDto createExpenseDto);
        Task<IEnumerable<ExpenseDto>> GetExpensesAsync();
        Task<ExpenseDto> GetExpenseByIdAsync(Guid id);
        Task<bool> UpdateExpenseAsync(Guid id, UpdateExpenseDto updateExpenseDto);
        Task<bool> DeleteExpenseAsync(Guid id);

        Task<IncomeDto> AddIncomeAsync(CreateIncomeDto createIncomeDto);
        Task<IEnumerable<IncomeDto>> GetIncomesAsync();
        Task<IncomeDto> GetIncomeByIdAsync(Guid id);
        Task<bool> UpdateIncomeAsync(Guid id, UpdateIncomeDto updateIncomeDto);
        Task<bool> DeleteIncomeAsync(Guid id);
    }
}