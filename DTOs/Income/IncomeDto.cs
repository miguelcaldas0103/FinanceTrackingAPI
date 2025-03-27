using FinanceTrackingAPI.Enums;

namespace FinanceTrackingAPI.DTOs.Income
{
    public class IncomeDto
    {
        public Guid Id { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; } = default!;
        public DateTime DateOfIncome { get; set; }
        public TypeOfIncomeEnum TypeOfIncome { get; set; }
    }
}