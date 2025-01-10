using FinanceTrackingAPI.Models;
using FinanceTrackingAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IFinanceService _financeservice;
        public ExpensesController(IFinanceService financeService)
        {
            _financeservice = financeService;
        }
        [HttpGet]
        public IActionResult GetExpenses() => Ok(_financeservice.GetExpenses());
        [HttpPost]
        public async Task<IActionResult> AddExpense([FromBody] Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _financeservice.AddExpenseAsync(expense);
            return CreatedAtAction(nameof(GetExpenses), new { id = expense.Id }, expense);
        }
    }
}