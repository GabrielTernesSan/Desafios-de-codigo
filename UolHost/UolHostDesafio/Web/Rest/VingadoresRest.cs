using System.Text.Json;
using Web.Interfaces;
using static Domain.Entities.Vingadores;

namespace Web.Rest
{
    public class VingadoresRest : IVingadorApi
    {
        public async Task<Root> Vingadores()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://raw.githubusercontent.com/uolhost/test-backEnd-Java/master/referencias/vingadores.json");

            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<Root>(contentResp);

                return objResponse;
            }
        }
    }
}
