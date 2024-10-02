using Newtonsoft.Json;
using Server.Models.Client;

namespace Server.Repositories.File
{
    public class FileRepository : IFileRepository
    {
        public List<ClientDataModel> _clientDataList = [];

        public virtual async Task WriteDataAsync(string file, ClientDataModel clientData)
        {
            if (System.IO.File.Exists(file))
            {
                _clientDataList = await ReadDataAsync(file);
            }

            _clientDataList.Add(clientData);

            var jsonData = JsonConvert.SerializeObject(_clientDataList, Formatting.Indented);
            using StreamWriter writer = new(file, append: false);

            await writer.WriteAsync(jsonData);
        }

        public virtual async Task<List<ClientDataModel>> ReadDataAsync(string file)
        {
            using StreamReader reader = new(file);
            var jsonClientDataFromFile = await reader.ReadToEndAsync();
            return JsonConvert.DeserializeObject<List<ClientDataModel>>(jsonClientDataFromFile)!;
        }
    }
}
