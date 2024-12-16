using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuloManutencoes.Dtos.MemoriaDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class TipoMemoriaRamController : ControllerBase
    {
        private readonly ITipoMemoriaRamService _tipoMemoriaRamService;

        public TipoMemoriaRamController(ITipoMemoriaRamService tipoMemoriaRamService)
        {
            _tipoMemoriaRamService = tipoMemoriaRamService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMemoriaRamGetDTO>>> RetornarTodosTiposMemoriasRam()
        {
            IEnumerable<TipoMemoriaRamGetDTO> listaTipoRam = await _tipoMemoriaRamService.RetornarTodosTiposMemoriasRam();

            return Ok(listaTipoRam);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TipoMemoriaRamGetDTO?>> RetornarTipoMemoriaRam([FromRoute] int id)
        {
            TipoMemoriaRamGetDTO? tipoRam = await _tipoMemoriaRamService.RetornarTipoMemoriaRam(id);

            return Ok(tipoRam);
        }

        [HttpPost]
        public async Task<ActionResult<MensagemAoClienteDTO>> AdicionarTipoMemoriaRam([FromBody] TipoMemoriaRamDTO tipoMemoriaRam)
        {
            MensagemAoClienteDTO adicionarTipoRam = await _tipoMemoriaRamService.AdicionarTipoMemoriaRam(tipoMemoriaRam);

            return Created("Created.", adicionarTipoRam);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<MensagemAoClienteDTO>> AtualizarTipoMemoriaRam([FromRoute] int id, [FromBody] TipoMemoriaRamDTO tipoMemoriaRam)
        {
            MensagemAoClienteDTO atualizarTipoRam = await _tipoMemoriaRamService.AtualizarTipoMemoriaRam(id, tipoMemoriaRam);

            return Ok(atualizarTipoRam);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MensagemAoClienteDTO>> ApagarTipoMemoriaRam([FromRoute] int id)
        {
            MensagemAoClienteDTO apagarTipoRam = await _tipoMemoriaRamService.ApagarTipoMemoriaRam(id);

            return Ok(apagarTipoRam);
        }
    }
}
