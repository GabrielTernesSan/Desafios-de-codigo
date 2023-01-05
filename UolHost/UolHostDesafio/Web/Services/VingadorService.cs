using Web.Interfaces;
using static Domain.Entities.Vingadores;

namespace Web.Services
{
    public class VingadorService : IVingadorService
    {

        private readonly IVingadorApi _heroiApi;

        public VingadorService(IVingadorApi heroiApi)
        {
            _heroiApi = heroiApi;
        }

        public async Task<Root> BuscarVingadores()
        {
            var retorno = await _heroiApi.Vingadores();
            return retorno;
        }
    }
}
