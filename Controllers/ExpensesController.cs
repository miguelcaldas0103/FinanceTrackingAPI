using FinanceTrackingAPI.DTOs.Expense;
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
        public async Task<IActionResult> AddExpense([FromBody] CreateExpenseDto createExpenseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdExpense = await _financeService.AddExpenseAsync(createExpenseDto);
            return CreatedAtAction(nameof(GetExpenses), new { id = createdExpense.Id }, createdExpense);
        }

        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            var expenses = await _financeService.GetExpensesAsync();
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseById([FromRoute] Guid id)
        {
            var expenseToGet = await _financeService.GetExpenseByIdAsync(id);
            return Ok(expenseToGet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense([FromRoute] Guid id, [FromBody] UpdateExpenseDto updateExpenseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _financeService.UpdateExpenseAsync(id, updateExpenseDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense([FromRoute] Guid id)
        {
            await _financeService.DeleteExpenseAsync(id);
            return NoContent();
        }
    }
}