using Microsoft.AspNetCore.Mvc;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Dtos.UsuarioDtos;
using ModuloManutencoes.Interfaces.Usuarios;

namespace ModuloManutencoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioGetDTO>>> RetornarListaUsuarios()
        {
            IEnumerable<UsuarioGetDTO> listaUsuarios = await _usuarioService.RetornarListaUsuarios();
            return Ok(listaUsuarios);
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<UsuarioGetDTO?>> RetornarUsuario([FromRoute] int userId)
        {
            UsuarioGetDTO? usuario = await _usuarioService.RetornarUsuario(userId);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<MensagemAoClienteDTO>> CadastrarUsuario(UsuarioDTO usuario)
        {
            MensagemAoClienteDTO cadastrarUsuario = await _usuarioService.CadastrarUsuario(usuario);
            return Created("Created.", cadastrarUsuario);
        }

        [HttpPatch("{userId:int}")]
        public async Task<ActionResult<MensagemAoClienteDTO>> AtualizarUsuario([FromRoute] int userId, [FromBody] UsuarioDTO usuario)
        {
            MensagemAoClienteDTO atualizarUsuario = await _usuarioService.AtualizarUsuario(userId, usuario);
            return Ok(atualizarUsuario);
        }

        [HttpDelete("{userId:int}")]
        public async Task<ActionResult<MensagemAoClienteDTO>> ApagarUsuario([FromRoute] int userId)
        {
            MensagemAoClienteDTO apagarUsuario = await _usuarioService.ApagarUsuario(userId);
            return Ok(apagarUsuario);
        }
    }
}
