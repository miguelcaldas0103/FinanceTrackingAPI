using System.Runtime.InteropServices;
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
        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            var expenses = await _financeservice.GetExpensesAsync();
            return Ok(expenses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseById(Guid id)
        {
            var expenseToGet = await _financeservice.GetExpenseByIdAsync(id);
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
            var expenseToBeUpdated = await _financeservice.UpdateExpenseAsync(id, expense);
            if (expenseToBeUpdated == null)
            {
                return NotFound();
            }
            return Ok(expenseToBeUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(Guid id)
        {
            var expenseToDelete = await _financeservice.DeleteExpenseAsync(id);
            if (!expenseToDelete)
            {
                return NotFound();
            }
            return NoContent();
        }
        public async Task<IActionResult> AddIncome([FromBody] Income income)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _financeservice.AddIncomeAsync(income);
            return CreatedAtAction(nameof(GetIncomes), new { id = income.Id }, income);
        }
        [HttpGet]
        public async Task<IActionResult> GetIncomes()
        {
            var incomes = await _financeservice.GetIncomesAsync();
            return Ok(incomes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncomeById(Guid id)
        {
            var incomeToGet = await _financeservice.GetIncomeByIdAsync(id);
            if (incomeToGet == null)
            {
                return NotFound();
            }
            return Ok(incomeToGet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncome(Guid id, [FromBody] Income income)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var incomeToBeUpdated = await _financeservice.UpdateIncomeAsync(id, income);
            if (incomeToBeUpdated == null)
            {
                return NotFound();
            }
            return Ok(incomeToBeUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(Guid id)
        {
            var incomeToDelete = await _financeservice.DeleteIncomeAsync(id);
            if (!incomeToDelete)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}