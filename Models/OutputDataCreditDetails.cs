using System.Collections.Generic;
using SimpleCreditCalculator.Models.Interfaces;

namespace SimpleCreditCalculator.Models
{
    public class OutputDataCreditDetails : IOutputDataCreditDetails
    {
        public IReadOnlyCollection<IPaymentDetails> PaymentDetails { get; }
        public decimal OverPayment { get; }

        public OutputDataCreditDetails(
            IReadOnlyCollection<IPaymentDetails> paymentDetails,
            decimal overPayment)
        {
            PaymentDetails = paymentDetails;
            OverPayment = overPayment;
        }
    }
}
