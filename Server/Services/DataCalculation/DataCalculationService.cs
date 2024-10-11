using Server.Models.Client;
using Newtonsoft.Json;
using Server.Models.OctopusApiModel;

namespace Server.Services.DataCalculation
{
    public class DataCalculationService(HttpClient httpClient) : IDataCalculationService
    {
        private readonly HttpClient _httpClient = httpClient
            ?? throw new ArgumentNullException(nameof(httpClient));

        public string? ValidationMessage { get; set; }

        public virtual async Task<ClientDataModel> CalculateClientCost(ClientDataModel clientData)
        {
            string productId = "AGILE-FLEX-22-11-25";
            string tariffCode = "E-1R-AGILE-FLEX-22-11-25-C";
            DateTime periodFrom = new(2023, 03, 26);
            DateTime periodTo = new(2023, 03, 27);

            try
            {
                var data = await GetStandardUnitRates(productId, tariffCode, periodFrom, periodTo);

                return new ClientDataModel();
                //TODO: Add logic for caulcating cost
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ClientDataModel();
            }
        }

        public async Task<ElectricityDataResponse> GetStandardUnitRates(string productId, string tariffCode, DateTime periodFrom, DateTime periodTo)
        {
            // Build URL
            string url = $"https://api.octopus.energy/v1/products/{productId}/electricity-tariffs/{tariffCode}/standard-unit-rates/?period_from={periodFrom:yyyy-MM-dd'T'HH:mm:ss}Z&period_to={periodTo:yyyy-MM-dd'T'HH:mm:ss}Z";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                var data2 = JsonConvert.DeserializeObject<ElectricityDataResponse>(responseContent);

                return data2;
            }
            else
            {
                ValidationMessage = $"Error when retrieving electricity prices - Status code:{response.StatusCode}";
                Console.WriteLine(ValidationMessage);
                return new ElectricityDataResponse();
            }
        }
    }
}
