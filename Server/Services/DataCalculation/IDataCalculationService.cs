using Server.Models.Client;
using Server.Models.OctopusApi;

namespace Server.Services.DataCalculation
{
    /// <summary>
    /// Data Calculation Service
    /// </summary>
    public interface IDataCalculationService
    {
        /// <summary>
        /// Calculate the electricity price
        /// </summary>
        public Task<decimal> GetClientCostAsync(ClientDataModel clientData);

        /// <summary>
        /// Get the standard energy rates from Octopus Energy
        /// </summary>
        public Task<ElectricityDataResponse?> GetStandardRatesAsync(string productId, string tariffCode, DateTime? periodFrom, DateTime periodTo);

        /// <summary>
        /// Convert the string Date and Time of connection to type DateTime
        /// </summary>
        public Task<DateTime> ConvertConnectionTimeToDateTimeAsync(string dateAndTime);

        /// <summary>
        /// Calculate the cost of the client's electricity usage
        /// </summary>
        public Task<decimal> CalculateCostAsync(ElectricityDataResponse rates, DateTime periodFrom, decimal electricityUsage);
    }
}
