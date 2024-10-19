using Server.Models.Client;
using Server.Models.OctopusApiModel;

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
        public Task<ClientDataModel> CalculateClientCostAsync(ClientDataModel clientData);

        /// <summary>
        /// Get the standard energy rates from Octopus Energy
        /// </summary>
        public Task<ElectricityDataResponse> GetStandardRatesAsync(string productId, string tariffCode, DateTime periodFrom, DateTime periodTo);
    }
}
