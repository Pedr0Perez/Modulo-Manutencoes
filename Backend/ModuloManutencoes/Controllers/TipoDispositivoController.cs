using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDispositivoController : ControllerBase
    {
        private readonly ITipoDispositivoService _tipoDispositivoService;

        public TipoDispositivoController(ITipoDispositivoService tipoDispositivoService)
        {
            _tipoDispositivoService = tipoDispositivoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDispositivoDTO>>> RetornarTodosTiposDispositivos()
        {
            IEnumerable<TipoDispositivoDTO> listaTipoDispositivos = await _tipoDispositivoService.RetornarTodosTiposDispositivos();
            return Ok(listaTipoDispositivos);
        }

        [HttpGet("{idTipoDisp:int}")]
        public async Task<ActionResult<TipoDispositivoDTO?>> RetornarTipoDispositivo([FromRoute] int idTipoDisp)
        {
            TipoDispositivoDTO? tipoDispositivo = await _tipoDispositivoService.RetornarTipoDispositivo(idTipoDisp);
            return Ok(tipoDispositivo);
        }

        [HttpPost]
        public async Task<ActionResult<MensagemAoClienteDTO>> AdicionarTipoDispositivo([FromBody] TipoDispositivoDTO tipoDispositivo)
        {
            MensagemAoClienteDTO adicionarTipoDispositivo = await _tipoDispositivoService.AdicionarTipoDispositivo(tipoDispositivo);
            return Created("Created.", adicionarTipoDispositivo);
        }

        [HttpPatch("{idTipoDisp:int}")]
        public async Task<ActionResult<MensagemAoClienteDTO>> AtualizarTipoDispositivo([FromRoute] int idTipoDisp, [FromBody] TipoDispositivoDTO tipoDispositivo)
        {
            MensagemAoClienteDTO atualizarTipoDispositivo = await _tipoDispositivoService.AtualizarTipoDispositivo(idTipoDisp, tipoDispositivo);
            return Ok(atualizarTipoDispositivo);
        }

        [HttpDelete("{idTipoDisp:int}")]
        public async Task<ActionResult<MensagemAoClienteDTO>> ApagarTipoDispositivo([FromRoute] int idTipoDisp)
        {
            MensagemAoClienteDTO apagarTipoDispositivo = await _tipoDispositivoService.ApagarTipoDispositivo(idTipoDisp);
            return Ok(apagarTipoDispositivo);
        }
    }
}
