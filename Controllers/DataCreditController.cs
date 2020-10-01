using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleCreditCalculator.Models;
using SimpleCreditCalculator.Models.Interfaces;
using SimpleCreditCalculator.Services;

namespace SimpleCreditCalculator.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class DataCreditController : ControllerBase
    {
        private readonly ILogger<DataCreditController> _logger;
        private readonly ICreditCalculatorService _creditCalculatorService;

        public DataCreditController(ICreditCalculatorService creditCalculatorService, ILogger<DataCreditController> logger)
        {
            _creditCalculatorService = creditCalculatorService;
            _logger = logger;
        }
        
        [HttpGet("paymentschedule")]
        public IEnumerable<IOutputDataCredit> GetPaymentSchedule([FromBody] InputDataCredit inputDataCredit)
        {
            _creditCalculatorService.InputDataCredit = inputDataCredit;
            var paymentSchedule = _creditCalculatorService.GetPaymentsSchedule();
            return paymentSchedule;
        }
        
        [HttpGet("overpayment")]
        public decimal GetOverPayment()
        {
            return _creditCalculatorService.GetOverPayment();
        }
    }
}
