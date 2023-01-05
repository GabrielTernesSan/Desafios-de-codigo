using Domain.Entities;
using System.Xml.Serialization;
using Web.Interfaces;
using static Domain.Entities.MembrosLiga;

namespace Web.Rest
{
    public class LigaRest : ILigaApi
    {
        public async Task<LigaDaJustica> Liga()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://raw.githubusercontent.com/uolhost/test-backEnd-Java/master/referencias/liga_da_justica.xml");

            using (var client = new HttpClient())
            {
                LigaDaJustica scp = null;
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp =  await responseBrasilApi.Content.ReadAsStringAsync();
                XmlSerializer serializer = new XmlSerializer(typeof(LigaDaJustica), new XmlRootAttribute("liga_da_justica"));

                StringReader stringReader = new StringReader(contentResp);

                scp = (LigaDaJustica)serializer.Deserialize(stringReader);
                

                return scp;
            }
        }
    }
}
