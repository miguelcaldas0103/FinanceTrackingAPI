using FinanceTrackingAPI.Data;
using FinanceTrackingAPI.Models;

namespace FinanceTrackingAPI.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public FinanceService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Expense> GetExpenses()
        {
            return _applicationDbContext.Expenses.ToList();
        }
    }
}