using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public class FileRepository
    {
        public async Task WriteDataAsync(string file, int clientId, int locationId, decimal electricityUsage, string connectionDateAndTime)
        {
            using StreamWriter writer = new(file, append: true);
            await writer.WriteLineAsync($"Id: {clientId}");
            await writer.WriteLineAsync($"Location Id: {locationId}");
            await writer.WriteLineAsync($"Electricity Usage in kWh: {electricityUsage}");
            await writer.WriteLineAsync($"Connection Date and Time: {connectionDateAndTime}\n\n");
        }
    }
}
