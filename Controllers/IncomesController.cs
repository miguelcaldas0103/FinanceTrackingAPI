using FinanceTrackingAPI.DTOs.Income;
using FinanceTrackingAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncomesController : ControllerBase
    {
        private readonly IFinanceService _financeService;
        public IncomesController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddIncome([FromBody] CreateIncomeDto createIncomeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdIncome = await _financeService.AddIncomeAsync(createIncomeDto);
            return CreatedAtAction(nameof(AddIncome), new { id = createdIncome.Id }, createIncomeDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetIncomes()
        {
            var incomes = await _financeService.GetIncomesAsync();
            return Ok(incomes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncomeById([FromRoute] Guid id)
        {
            var incomeToGet = await _financeService.GetIncomeByIdAsync(id);
            return Ok(incomeToGet);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateIncome([FromRoute] Guid id, [FromBody] UpdateIncomeDto updateIncomeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _financeService.UpdateIncomeAsync(id, updateIncomeDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome([FromRoute] Guid id)
        {
            await _financeService.DeleteIncomeAsync(id);
            return NoContent();
        }
    }
}