using static Domain.Entities.Vingadores;
using System.Text.Json;
using Domain.Entities;
using Infra;
using Domain.Repositories;
using System.Xml.Serialization;
using static Domain.Entities.MembrosLiga;

namespace Web.HostedService
{
    public class HeroisHostedService : IHostedService
    {

        private readonly IServiceScopeFactory _scopeFactory;

        public HeroisHostedService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ExecuteProcess();
            return Task.CompletedTask;
        }

        private async Task ExecuteProcess()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://raw.githubusercontent.com/uolhost/test-backEnd-Java/master/referencias/vingadores.json");

            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<Root>(contentResp);

                foreach (var vingador in objResponse.vingadores)
                {
                    var cadastrarVingador = new Infra.Tables.Vingador
                    {
                        codinome = vingador.codinome
                    };

                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<ContextMemory>();
                        dbContext.Vingadores.AddAsync(cadastrarVingador);
                        await dbContext.SaveChangesAsync();
                    }
                }
            }

            var requestLiga = new HttpRequestMessage(HttpMethod.Get, $"https://raw.githubusercontent.com/uolhost/test-backEnd-Java/master/referencias/liga_da_justica.xml");

            using (var client = new HttpClient())
            {
                LigaDaJustica scp = null;
                var responseBrasilApi = await client.SendAsync(requestLiga);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                XmlSerializer serializer = new XmlSerializer(typeof(LigaDaJustica), new XmlRootAttribute("liga_da_justica"));

                StringReader stringReader = new StringReader(contentResp);

                scp = (LigaDaJustica)serializer.Deserialize(stringReader);

                foreach(var membroLiga in scp.Codinomes.Codinome)
                {
                    var ligaDaJustica = new Infra.Tables.LigaDaJustica
                    {
                        codinome = membroLiga
                    };

                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<ContextMemory>();
                        dbContext.LigaDaJustica.AddAsync(ligaDaJustica);
                        await dbContext.SaveChangesAsync();
                    }
                }
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
