namespace FinanceTrackingAPI.DTOs.Income
{
    public class UpdateIncomeDto
    {
        public float Amount { get; set; }
        public string Description { get; set; } = default!;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}