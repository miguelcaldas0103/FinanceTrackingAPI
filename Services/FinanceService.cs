
using FinanceTrackingAPI.Data;
using FinanceTrackingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackingAPI.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public FinanceService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            _applicationDbContext.Expenses.Add(expense);
            await _applicationDbContext.SaveChangesAsync();
            return expense;
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync()
        {
            return await _applicationDbContext.Expenses.ToListAsync();
        }

        public async Task<Expense?> GetExpenseByIdAsync(Guid id)
        {
            var expense = await _applicationDbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            return expense;
        }

        public async Task<Expense> UpdateExpenseAsync(Guid id, Expense expense)
        {
            var expenseToBeUpdated = await _applicationDbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if (expenseToBeUpdated == null)
            {
                return null;
            }
            expenseToBeUpdated.Description = expense.Description;
            expenseToBeUpdated.Amount = expense.Amount;
            expenseToBeUpdated.DateOfExpense = expenseToBeUpdated.DateOfExpense;
            expenseToBeUpdated.TypeOfExpense = expenseToBeUpdated.TypeOfExpense;
            expenseToBeUpdated.ModifiedAt = DateTime.Now;

            await _applicationDbContext.SaveChangesAsync();
            return expenseToBeUpdated;
        }

        public async Task<bool> DeleteExpenseAsync(Guid id)
        {
            var expenseToDelete = await _applicationDbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if (expenseToDelete == null)
            {
                return false;
            }
            _applicationDbContext.Expenses.Remove(expenseToDelete);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Income> AddIncomeAsync(Income income)
        {
            _applicationDbContext.Incomes.Add(income);
            await _applicationDbContext.SaveChangesAsync();
            return income;
        }

        public async Task<IEnumerable<Income>> GetIncomesAsync()
        {
            return await _applicationDbContext.Incomes.ToListAsync();
        }

        public async Task<Income?> GetIncomeByIdAsync(Guid id)
        {
            var incomeToFind = await _applicationDbContext.Incomes.FirstOrDefaultAsync(x => x.Id == id);
            return incomeToFind;
        }

        public async Task<Income?> UpdateIncomeAsync(Guid id, Income income)
        {
            var incomeToBeUpdated = await _applicationDbContext.Incomes.FirstOrDefaultAsync(x => x.Id == id);
            if (incomeToBeUpdated == null)
            {
                return null;
            }
            incomeToBeUpdated.Description = income.Description;
            incomeToBeUpdated.Amount = income.Amount;
            incomeToBeUpdated.DateOfIncome = income.DateOfIncome;
            incomeToBeUpdated.TypeOfIncome = income.TypeOfIncome;
            incomeToBeUpdated.ModifiedAt = DateTime.Now;
            await _applicationDbContext.SaveChangesAsync();
            return incomeToBeUpdated;
        }

        public async Task<bool> DeleteIncomeAsync(Guid id)
        {
            var incomeToDelete = await _applicationDbContext.Incomes.FirstOrDefaultAsync(x => x.Id == id);
            if (incomeToDelete == null)
            {
                return false;
            }
            _applicationDbContext.Remove(incomeToDelete);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}