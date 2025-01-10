using FinanceTrackingAPI.Enums;

namespace FinanceTrackingAPI.Models
{
    public class Income
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = default!;
        public DateTime DateOfIncome { get; set; }
        public TypeOfIncomeEnum TypeOfIncome { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }
    }
}