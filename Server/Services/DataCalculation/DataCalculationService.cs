using Server.Models.Client;
using Newtonsoft.Json;
using Server.Models.OctopusApi;
using Server.Services.Http;
using System.Globalization;

// https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-8.0 - showed how to call external APIs in C#

namespace Server.Services.DataCalculation
{
    public class DataCalculationService(IHttpService httpService) : IDataCalculationService
    {
        private readonly IHttpService _httpService = httpService
            ?? throw new ArgumentNullException(nameof(httpService));

        public string? ValidationMessage { get; set; }

        public virtual async Task<decimal> GetClientCostAsync(ClientDataModel clientData)
        {
            var connectionTimeAsDateTime = await ConvertConnectionTimeToDateTimeAsync(clientData.ConnectionDateAndTime);

            // Place holder value to retrieve electricity prices
            string productId = "AGILE-FLEX-22-11-25";

            DateTime periodFrom = connectionTimeAsDateTime;
            DateTime periodTo = periodFrom.AddMinutes(30);

            try
            {
                var standardElectricityCosts = await GetStandardRatesAsync(productId, clientData.Tariff, periodFrom, periodTo);

                if (standardElectricityCosts is null)
                {
                    ValidationMessage = $"Error when retrieving electricity cost for client {clientData.Id}";
                    Console.WriteLine(ValidationMessage);
                    return 0;
                }

                var cost = await CalculateCostAsync(standardElectricityCosts, periodFrom, clientData.ElectricityUsage);

                return cost;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public async Task<DateTime> ConvertConnectionTimeToDateTimeAsync(string dateAndTime)
        {
            // Wrap synchronous method in Task.Run to run it 
            // asynchronousley on a seperate thread - stops blocking
            return await Task.Run(() =>
            {
                try
                {
                    return DateTime.ParseExact(
                        dateAndTime,
                        "yyyy-MM-ddTHH:mm:ssZ",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal
                    );
                }
                catch
                {
                    ValidationMessage = $"Error parsing the date string: {dateAndTime}";
                    Console.WriteLine(ValidationMessage);
                    return new DateTime();
                }
            });
        }


        public async Task<decimal> CalculateCostAsync(ElectricityDataResponse rates, DateTime periodFrom, decimal electricityUsage)
        {
            // Wrap synchronous method in Task.Run to run it 
            // asynchronousley on a seperate thread - stops blocking
            return await Task.Run(() =>
            {
                var cost = rates.Results?
                    .FirstOrDefault(x => x.Valid_from <= periodFrom)?.Value_inc_vat;

                return cost * electricityUsage ?? 0;
            });
        }

        public async Task<ElectricityDataResponse?> GetStandardRatesAsync(string productId, string tariffCode, DateTime? periodFrom, DateTime periodTo)
        {
            // Build URL
            string url = $"https://api.octopus.energy/v1/products/{productId}/electricity-tariffs/{tariffCode}/standard-unit-rates/?period_from={periodFrom:yyyy-MM-dd'T'HH:mm:ss}Z&period_to={periodTo:yyyy-MM-dd'T'HH:mm:ss}Z";

            var response = await _httpService.GetAsync(url);

            if (response is null)
            {
                ValidationMessage = $"Error when retrieving electricity prices";
                Console.WriteLine(ValidationMessage);
                return new ElectricityDataResponse();
            }

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                var dataResponse = JsonConvert.DeserializeObject<ElectricityDataResponse>(responseContent);

                return dataResponse;
            }
            else
            {
                ValidationMessage = $"Error when retrieving electricity prices - status code: {response.StatusCode}";
                Console.WriteLine(ValidationMessage);
                return new ElectricityDataResponse();
            }
        }
    }
}
