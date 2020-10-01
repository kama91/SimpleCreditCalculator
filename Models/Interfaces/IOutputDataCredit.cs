namespace SimpleCreditCalculator.Models.Interfaces
{
    public interface IOutputDataCredit
    {
        int PaymentNumber { get; set; }
        string PaymentDate { get; set; }
        decimal PaymentBody { get; set; }
        decimal PaymentPercent { get; set; }
        decimal BalanceDebt { get; set; }
    }
}
