using SimpleCreditCalculator.Models.Interfaces;

namespace SimpleCreditCalculator.Services
{
    public interface ICreditCalculatorService
    {
        /// <summary>
        /// Получить рассчитанные данные по кредиту
        /// </summary>
        IOutputDataCreditDetails GetOutputDataCreditDetails(IInputDataCredit inputDataCredit);
    }
}