﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCreditCalculator.Models.Interfaces
{
    public interface IOutputDataCreditDetails
    {
        IReadOnlyCollection<IPaymentDetails> PaymentDetails { get; }

        decimal OverPayment { get; }
    }
}
