using FinanceTrackingAPI.Enums;

namespace FinanceTrackingAPI.DTOs.Expense
{
    public class CreateExpenseDto
    {
        public float Amount { get; set; }
        public string Description { get; set; } = default!;
        public DateTime DateOfExpense { get; set; }
        public TypeOfExpenseEnum TypeOfExpense { get; set; }
    }
}