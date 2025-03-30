
using FinanceTrackingAPI.Data;
using FinanceTrackingAPI.DTOs.Expense;
using FinanceTrackingAPI.DTOs.Income;
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

        public async Task<ExpenseDto> AddExpenseAsync(CreateExpenseDto createExpenseDto)
        {
            var expense = new Expense
            {
                Amount = createExpenseDto.Amount,
                Description = createExpenseDto.Description,
                DateOfExpense = createExpenseDto.DateOfExpense,
                TypeOfExpense = createExpenseDto.TypeOfExpense,
            };
            _applicationDbContext.Expenses.Add(expense);
            await _applicationDbContext.SaveChangesAsync();
            return new ExpenseDto
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Description = expense.Description,
                DateOfExpense = expense.DateOfExpense,
                TypeOfExpense = expense.TypeOfExpense
            };
        }


        public async Task<IEnumerable<ExpenseDto>> GetExpensesAsync()
        {
            return await _applicationDbContext.Expenses
                .Select(expense => new ExpenseDto
                {
                    Id = expense.Id,
                    Amount = expense.Amount,
                    Description = expense.Description,
                    DateOfExpense = expense.DateOfExpense,
                })
                .ToListAsync();
        }


        public async Task<ExpenseDto> GetExpenseByIdAsync(Guid id)
        {
            var expense = await _applicationDbContext.Expenses.FirstAsync(x => x.Id == id);
            return new ExpenseDto
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Description = expense.Description,
                DateOfExpense = expense.DateOfExpense,
                TypeOfExpense = expense.TypeOfExpense
            };
        }

        public async Task<bool> UpdateExpenseAsync(Guid id, UpdateExpenseDto updateExpenseDto)
        {
            var expenseToBeUpdated = await _applicationDbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if (expenseToBeUpdated == null)
            {
                return false;
            }
            expenseToBeUpdated.Amount = updateExpenseDto.Amount;
            expenseToBeUpdated.Description = updateExpenseDto.Description;

            await _applicationDbContext.SaveChangesAsync();
            return true;
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

        public async Task<IncomeDto> AddIncomeAsync(CreateIncomeDto createIncomeDto)
        {
            var income = new Income
            {
                Amount = createIncomeDto.Amount,
                Description = createIncomeDto.Description,
                DateOfIncome = createIncomeDto.DateOfIncome,
                TypeOfIncome = createIncomeDto.TypeOfIncome,
            };
            _applicationDbContext.Incomes.Add(income);
            await _applicationDbContext.SaveChangesAsync();
            return new IncomeDto
            {
                Id = income.Id,
                Amount = income.Amount,
                Description = income.Description,
                DateOfIncome = income.DateOfIncome,
                TypeOfIncome = income.TypeOfIncome
            };
        }

        public async Task<IEnumerable<IncomeDto>> GetIncomesAsync()
        {
            return await _applicationDbContext.Incomes.Select(income => new IncomeDto
            {
                Id = income.Id,
                Amount = income.Amount,
                Description = income.Description,
                DateOfIncome = income.DateOfIncome,
                TypeOfIncome = income.TypeOfIncome
            }).ToListAsync();
        }

        public async Task<IncomeDto> GetIncomeByIdAsync(Guid id)
        {
            var incomeToFind = await _applicationDbContext.Incomes.FirstAsync(x => x.Id == id);
            return new IncomeDto
            {
                Id = incomeToFind.Id,
                Amount = incomeToFind.Amount,
                Description = incomeToFind.Description,
                DateOfIncome = incomeToFind.DateOfIncome,
                TypeOfIncome = incomeToFind.TypeOfIncome
            };
        }

        public async Task<bool> UpdateIncomeAsync(Guid id, UpdateIncomeDto updateIncomeDto)
        {
            var incomeToBeUpdated = await _applicationDbContext.Incomes.FirstOrDefaultAsync(x => x.Id == id);
            if (incomeToBeUpdated == null)
            {
                return false;
            }
            incomeToBeUpdated.Amount = updateIncomeDto.Amount;
            incomeToBeUpdated.Description = updateIncomeDto.Description;
            await _applicationDbContext.SaveChangesAsync();
            return true;
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