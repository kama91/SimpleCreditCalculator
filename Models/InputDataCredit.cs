using System.ComponentModel.DataAnnotations;
using SimpleCreditCalculator.Models.Interfaces;

namespace SimpleCreditCalculator.Models
{
    public class InputDataCredit : IInputDataCredit
    {
        [Range(1.0, 10000000000.0)]
        public decimal SumOfCredit { get; set; }

        [Range(1, 100000)]
        public int CreditTerm { get; set; }

        [Range(0.1, 100.0)]
        public decimal InterestRateOfYear { get; set; }

        //public double InterestRateOfDay { get; set; }
    }
}
