using FinanceTrackingAPI.Data;
using FinanceTrackingAPI.Models;
using FinanceTrackingAPI.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FinanceTrackingAPI.tests.FinanceServiceTests
{
    public class FinanceServiceTests
    {
        [Fact]
        public async Task AddExpenseAsync_ShouldAddExpense()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            using var context = new ApplicationDbContext(options);
            var service = new FinanceService(context);

            var expense = new Expense
            {
                Id = Guid.NewGuid(),
                Amount = 20,
                Description = "Eating out at Eusebios",
                DateOfExpense = new DateTime(2025, 01, 10),
                TypeOfExpense = 0

            };
            // Act
            var result = await service.AddExpenseAsync(expense);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(expense.Id, result.Id);
            Assert.Equal(expense.Amount, result.Amount);
            Assert.Equal(expense.Description, result.Description);

            // Verify the expense exists in the database
            var expenseInDb = await context.Expenses.FirstOrDefaultAsync(x => x.Id == expense.Id);
            Assert.NotNull(expenseInDb);
        }

    }
}