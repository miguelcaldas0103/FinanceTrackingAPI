using FinanceTrackingAPI.Enums;

namespace FinanceTrackingAPI.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; } = default!;
        public DateTime DateOfExpense { get; set; }
        public TypeOfExpenseEnum TypeOfExpense { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    }
}