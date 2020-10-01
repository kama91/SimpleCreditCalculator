using System.Collections.Generic;
using SimpleCreditCalculator.Models.Interfaces;

namespace SimpleCreditCalculator.Services
{
    public interface ICreditCalculatorService
    {
       IInputDataCredit InputDataCredit { get; set; }
       decimal GetOverPayment();
       IEnumerable<IOutputDataCredit> GetPaymentsSchedule();
    }
}
