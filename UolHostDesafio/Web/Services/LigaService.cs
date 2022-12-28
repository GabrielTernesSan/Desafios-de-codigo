using Domain.Entities;
using Web.Interfaces;
using static Domain.Entities.Liga;

namespace Web.Services
{
    public class LigaService : ILigaService
    {

        private readonly ILigaApi _ligaApi;

        public LigaService(ILigaApi ligaApi)
        {
            _ligaApi = ligaApi;
        }

        public async Task<LigaDaJustica> BuscarLigaDaJustica()
        {
            var retorno = await _ligaApi.Liga();
            return retorno;
        }
    }
}
