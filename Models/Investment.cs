namespace FinanceTrackingAPI.Models
{
    public class Investment
    {
        public Guid Id { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; } = default!;
        public DateTime DateOfIncome { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }
    }
}