using System.Net;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public AutenticacaoController(IAutenticacaoService autenticacaoService, IHttpContextAccessor httpContextAccessor)
        {
            _autenticacaoService = autenticacaoService;
           _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// Realiza a autenticação do usuário
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Informações do usuário e token de acesso</returns>
        /// <response code="200">Usuário autenticado com sucesso.</response>
        /// <response code="401">Usuário não autenticado.</response>
        [HttpPost]
        public async Task<ActionResult<DadosSessaoDTO>> RealizarAutenticacao([FromBody] LoginDTO login)
        {
            DadosSessaoDTO dadosSessaoDTO = await _autenticacaoService.RealizarAutenticacao(login);

            return Ok(dadosSessaoDTO);
        }
    }
}
