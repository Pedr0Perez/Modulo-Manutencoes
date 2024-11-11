using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuloManutencoes.Dtos.LoginDtos;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpPost]
        public async Task<ActionResult<DadosSessaoDTO>> RealizarAutenticacao([FromBody] LoginDTO login)
        {
            DadosSessaoDTO dadosSessaoDTO = await _autenticacaoService.RealizarAutenticacao(login);

            return Ok(dadosSessaoDTO);
        }
    }
}
