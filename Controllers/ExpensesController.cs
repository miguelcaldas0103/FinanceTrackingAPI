using FinanceTrackingAPI.Models;
using FinanceTrackingAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IFinanceService _financeService;
        public ExpensesController(IFinanceService financeService)
        {
            _financeService = financeService;
        }
        [HttpPost]
        public async Task<IActionResult> AddExpense([FromBody] Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _financeService.AddExpenseAsync(expense);
            return CreatedAtAction(nameof(GetExpenses), new { id = expense.Id }, expense);
        }
        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            var expenses = await _financeService.GetExpensesAsync();
            return Ok(expenses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseById(Guid id)
        {
            var expenseToGet = await _financeService.GetExpenseByIdAsync(id);
            if (expenseToGet == null)
            {
                return NotFound();
            }
            return Ok(expenseToGet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(Guid id, [FromBody] Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var expenseToBeUpdated = await _financeService.UpdateExpenseAsync(id, expense);
            if (expenseToBeUpdated == null)
            {
                return NotFound();
            }
            return Ok(expenseToBeUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(Guid id)
        {
            var expenseToDelete = await _financeService.DeleteExpenseAsync(id);
            if (!expenseToDelete)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}