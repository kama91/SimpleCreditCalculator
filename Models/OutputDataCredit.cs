using System.Collections.Generic;
using SimpleCreditCalculator.Models.Interfaces;

namespace SimpleCreditCalculator.Models
{
    public class OutputDataCredit : IOutputDataCredit
    {
        public IReadOnlyCollection<IPaymentDetails> PaymentDetails { get; }
        public decimal OverPayment { get; }

        public OutputDataCredit(
            IReadOnlyCollection<IPaymentDetails> paymentDetails,
            decimal overPayment)
        {
            PaymentDetails = paymentDetails;
            OverPayment = overPayment;
        }
    }
}
