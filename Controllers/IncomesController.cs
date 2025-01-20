using FinanceTrackingAPI.Models;
using FinanceTrackingAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Name
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomesController : ControllerBase
    {
        private readonly IFinanceService _financeService;
        public IncomesController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpGet]
        public async Task<IActionResult> AddIncome([FromBody] Income income)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _financeService.AddIncomeAsync(income);
            return CreatedAtAction(nameof(AddIncome), income);
        }
    }
}