using Application.Requests.Jogador;
using Domain.Command;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;

namespace Web.Controllers
{
    [ApiController]
    [Route("v1/jogador")]
    public class HeroiController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IVingadorService _vingadorService;
        private readonly ILigaService _ligaService;
        private readonly IJogadorQuery _query;
        private readonly IVingadoresQuery _vingadoresQuery;
        private readonly ILigaQuery _ligaQuery;

        public HeroiController(IMediator mediator, IJogadorQuery query, IVingadorService vingadorService, IVingadoresQuery vingadoresQuery, ILigaService ligaService, ILigaQuery ligaQuery)
        {
            _mediator = mediator;
            _query = query;
            _vingadorService = vingadorService;
            _vingadoresQuery = vingadoresQuery;
            _ligaService = ligaService;
            _ligaQuery = ligaQuery;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
                var jogadores = await _query.ObterJogadoresAsync();
                return Ok(jogadores);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var relatorios = await _query.ObterJogadorIdAsync(id);
            return Ok(relatorios);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddJogadorRequest request)
        {
            var response = new GenericRequestResult();
            response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromBody] AlterarJogadorRequest request, int id)
        {
            var response = new GenericRequestResult();
            request.jogadorId = id;
            response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new GenericRequestResult();
            response = await _mediator.Send(new ExcluirJogadorRequest { jogadorId = id });
            return Ok(response);
        }

        [HttpGet("/vingadores/externo")]
        public async Task<IActionResult> GetVingadores()
        {
            var response = await _vingadorService.BuscarVingadores();
            return Ok(response);
        }

        [HttpGet("/vingadores")]
        public async Task<IActionResult> GetVingador()
        {
            var response = await _vingadoresQuery.ObterVingadores();
            return Ok(response);
        }

        [HttpGet("/liga/externo")]
        public async Task<IActionResult> GetLigaEx()
        {
            var response = await _ligaService.BuscarLigaDaJustica();
            return Ok(response);
        }

        [HttpGet("/liga")]
        public async Task<IActionResult> GetLiga()
        {
            var response = await _ligaQuery.ObterLigaDaJustica();
            return Ok(response);
        }
    }
}
