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
    }
}