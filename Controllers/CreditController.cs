using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleCreditCalculator.Models;
using SimpleCreditCalculator.Models.Interfaces;
using SimpleCreditCalculator.Services;

namespace SimpleCreditCalculator.Controllers
{
    public class CreditController : Controller
    {
        private readonly ILogger<CreditController> _logger;
        private readonly ICreditCalculatorService _creditCalculatorService;
        private static IOutputDataCredit _outputDataCreditDetails;

        public CreditController(ICreditCalculatorService creditCalculatorService, ILogger<CreditController> logger)
        {
            _creditCalculatorService = creditCalculatorService;
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PaymentSchedule(InputDataCredit inputDataCredit)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Credit");
            }

            _outputDataCreditDetails = _creditCalculatorService.GetOutputDataCreditDetails(inputDataCredit);

            return View();
        }

        [HttpGet("/[controller]/paymentschedule")]
        public IReadOnlyCollection<IPaymentDetails> GetPaymentsSchedule()
        {
            return _outputDataCreditDetails.PaymentDetails;
        }

        [HttpGet("/[controller]/overpayment")]
        public decimal GetOverPayment()
        {
            return _outputDataCreditDetails.OverPayment;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
