using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SimpleCreditCalculator.Models;
using SimpleCreditCalculator.Models.Interfaces;

namespace SimpleCreditCalculator.Services
{
    public class CreditCalculatorService : ICreditCalculatorService
    {
        private ILogger<ICreditCalculatorService> _logger;

        public CreditCalculatorService(ILogger<CreditCalculatorService> logger)
        {
            _logger = logger;
        }

        public IOutputDataCredit GetOutputDataCreditDetails(IInputDataCredit inputDataCredit)
        {
            if (inputDataCredit == null)
            {
                return null;
            }

            var annuityPaymentFactor = inputDataCredit.InterestRateOfYear / 100 / 12;
            var amountPayment = GetAmountPayment(inputDataCredit);
            var paymentsDetails = new List<IPaymentDetails>(inputDataCredit.CreditTerm);
            var date = DateTime.Now.Date;
            var balanceDebt = inputDataCredit.SumOfCredit;
            for (var j = 0; j < inputDataCredit.CreditTerm; j++)
            {
                var paymentPercent = balanceDebt * annuityPaymentFactor;
                var paymentBody = amountPayment - paymentPercent;
                balanceDebt  -= paymentBody;
                paymentsDetails.Add(new PaymentDetails(
                    j + 1,
                    date.ToString("dd/MM/yyyy"),
                    Math.Round(paymentBody, 2),
                    Math.Round(paymentPercent, 2),
                    Math.Round(balanceDebt, 2)
                ));

                date = date.AddMonths(1);
            }

            return new OutputDataCredit(paymentsDetails, GetOverPayment(inputDataCredit));
        }

        private decimal GetAmountPayment(IInputDataCredit inputDataCredit)
        {
            var annuityPaymentFactor = inputDataCredit.InterestRateOfYear / 100 / 12;
            var creditTerm = inputDataCredit.CreditTerm;
            var factor = decimal.ToDouble(annuityPaymentFactor) * Math.Pow(decimal.ToDouble(1 + annuityPaymentFactor), creditTerm) / (Math.Pow(decimal.ToDouble(1 + annuityPaymentFactor), creditTerm) - 1);
            return inputDataCredit.SumOfCredit * (decimal)factor;
        }

        private decimal GetOverPayment(IInputDataCredit inputDataCredit)
        {
            return  Math.Round(GetAmountPayment(inputDataCredit) * inputDataCredit.CreditTerm - inputDataCredit.SumOfCredit, 2);
        }
    }
}
