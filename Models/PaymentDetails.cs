using SimpleCreditCalculator.Models.Interfaces;

namespace SimpleCreditCalculator.Models
{
    public class PaymentDetails : IPaymentDetails
    {
        public int PaymentNumber { get; }

        public string PaymentDate { get; }
        
        public decimal PaymentBody { get;}
        
        public decimal PaymentPercent { get; }
        
        public decimal BalanceDebt { get; }

        //public double OverPayment { get; set; }

        public PaymentDetails(int paymentNumber,
            string paymentDate,
            decimal paymentBody,
            decimal paymentPercent,
            decimal balanceDebt)
        {
            PaymentNumber = paymentNumber;
            PaymentDate = paymentDate;
            PaymentBody = paymentBody;
            PaymentPercent = paymentPercent;
            BalanceDebt = balanceDebt;
        }
    }
}
