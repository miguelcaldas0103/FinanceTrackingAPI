namespace FinanceTrackingAPI.DTOs.Expense
{
    public class UpdateExpenseDto
    {
        public float Amount { get; set; }
        public string Description { get; set; } = default!;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}