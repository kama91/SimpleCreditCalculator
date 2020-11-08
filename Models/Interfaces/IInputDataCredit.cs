namespace SimpleCreditCalculator.Models.Interfaces
{
    public interface IInputDataCredit
    {
        /// <summary>
        /// Сумма кредита
        /// </summary>
        decimal SumOfCredit { get; set; }

        /// <summary>
        /// Срок кредита
        /// </summary>
        int CreditTerm { get; set; }

        /// <summary>
        /// Процентная ставка по кредиту
        /// </summary>
        decimal InterestRateOfYear { get; set; }
    }
}
