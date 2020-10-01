using SimpleCreditCalculator.Models.Interfaces;

namespace SimpleCreditCalculator.Models
{
    public class OutputDataCredit : IOutputDataCredit
    {
        public int PaymentNumber { get; set; }
        public string PaymentDate { get; set; }
        public decimal PaymentBody { get; set; }
        public decimal PaymentPercent { get; set; }
        public decimal BalanceDebt { get; set; }
        //public double OverPayment { get; set; }
    }
}
