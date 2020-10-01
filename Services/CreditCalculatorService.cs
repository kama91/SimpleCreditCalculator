using System;
using System.Collections.Generic;
using SimpleCreditCalculator.Models;
using SimpleCreditCalculator.Models.Interfaces;

namespace SimpleCreditCalculator.Services
{
    public class CreditCalculatorService : ICreditCalculatorService
    {
        public IInputDataCredit InputDataCredit { get; set; }

        public IEnumerable<IOutputDataCredit> GetPaymentsSchedule()
        {
            if (InputDataCredit == null) return new List<IOutputDataCredit>();
            var i = InputDataCredit.InterestRateOfYear / 100 / 12;
            var a = GetAmountPayment();
            var result = new List<IOutputDataCredit>(InputDataCredit.CreditTerm);
            var date = DateTime.Now.Date;
            var balanceDebt = InputDataCredit.SumOfCredit;
            for (var j = 0; j < InputDataCredit.CreditTerm; j++)
            {
                var paymentPercent = balanceDebt * i;
                var paymentBody = a - paymentPercent;
                balanceDebt  -= paymentBody;
                result.Add(new OutputDataCredit
                {
                    PaymentNumber = j + 1,
                    PaymentDate = date.ToString("dd/MM/yyyy"),
                    PaymentBody = Math.Round(paymentBody, 2),
                    PaymentPercent = Math.Round(paymentPercent, 2),
                    BalanceDebt =  Math.Round(balanceDebt, 2),
                });
                date = date.AddMonths(1);
            }

            return result;
        }

        private decimal GetAmountPayment()
        {
            var i = InputDataCredit.InterestRateOfYear / 100 / 12;
            var c = InputDataCredit.CreditTerm;
            var k = decimal.ToDouble(i) * Math.Pow(decimal.ToDouble(1 + i), c) / (Math.Pow(decimal.ToDouble(1 + i), c) - 1);
            return InputDataCredit.SumOfCredit * (decimal)k;
        }

        public decimal GetOverPayment()
        {
            return  Math.Round(GetAmountPayment() * InputDataCredit.CreditTerm - InputDataCredit.SumOfCredit, 2);
        }
    }
}
