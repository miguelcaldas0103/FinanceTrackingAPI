using FinanceTrackingAPI.Enums;

namespace FinanceTrackingAPI.Models
{
    public class Investment
    {
        public Guid Id { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; } = default!;
        public string Broker { get; set; } = default!;
        public DateTime DateOfInvestment { get; set; }
        public TypeOfInvestmentEnum TypeOfInvestment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }
    }
}