using FinanceTrackingAPI.Enums;

namespace FinanceTrackingAPI.DTOs.Expense
{
    public class ExpenseDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = default!;
        public DateTime DateOfExpense { get; set; }
        public TypeOfExpenseEnum TypeOfExpense { get; set; }
    }
}