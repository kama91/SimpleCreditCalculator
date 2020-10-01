namespace SimpleCreditCalculator.Models.Interfaces
{
    public interface IInputDataCredit
    {
        decimal SumOfCredit { get; set; }
        int CreditTerm { get; set; }
        decimal InterestRateOfYear { get; set; }
    }
}
