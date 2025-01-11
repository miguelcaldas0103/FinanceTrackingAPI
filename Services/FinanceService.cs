using System.Runtime.CompilerServices;
using FinanceTrackingAPI.Data;
using FinanceTrackingAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task AddExpenseAsync(Expense expense)
        {
            _applicationDbContext.Expenses.Add(expense);
            await _applicationDbContext.SaveChangesAsync();
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
    }
}