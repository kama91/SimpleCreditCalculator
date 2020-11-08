namespace SimpleCreditCalculator.Models.Interfaces
{
    public interface IPaymentDetails
    {
        /// <summary>
        /// Порядковый номер платежа
        /// </summary>
        int PaymentNumber { get; }

        /// <summary>
        /// Дата платежа
        /// </summary>
        string PaymentDate { get; }

        /// <summary>
        /// Размер платежа по телу кредита
        /// </summary>
        decimal PaymentBody { get; }

        /// <summary>
        /// Размер платежа по процентам
        /// </summary>
        decimal PaymentPercent { get; }

        /// <summary>
        /// Остаток основного долга
        /// </summary>
        decimal BalanceDebt { get; }
    }
}
