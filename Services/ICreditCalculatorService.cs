using SimpleCreditCalculator.Models.Interfaces;

namespace SimpleCreditCalculator.Services
{
    public interface ICreditCalculatorService
    {
        /// <summary>
        /// Получить рассчитанные данные по кредиту
        /// </summary>
        IOutputDataCredit GetOutputDataCreditDetails(IInputDataCredit inputDataCredit);
    }
}