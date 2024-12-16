using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModuloManutencoes.Dtos.MemoriaDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TipoMemoriaVramController : ControllerBase
    {
        private readonly ITipoMemoriaVramService _tipoMemoriaVramService;

        public TipoMemoriaVramController(ITipoMemoriaVramService tipoMemoriaRamService)
        {
            _tipoMemoriaVramService = tipoMemoriaRamService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMemoriaVramGetDTO>>> RetornarTodosTiposMemoriasVram()
        {
            IEnumerable<TipoMemoriaVramGetDTO> listaTipoVram = await _tipoMemoriaVramService.RetornarTodosTiposMemoriasVram();

            return Ok(listaTipoVram);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TipoMemoriaVramGetDTO?>> RetornarTipoMemoriaVram([FromRoute] int id)
        {
            TipoMemoriaVramGetDTO? tipoVram = await _tipoMemoriaVramService.RetornarTipoMemoriaVram(id);

            return Ok(tipoVram);
        }

        [HttpPost]
        public async Task<ActionResult<MensagemAoClienteDTO>> AdicionarTipoMemoriaVram([FromBody] TipoMemoriaVramDTO tipoMemoriaRam)
        {
            MensagemAoClienteDTO adicionarTipoVram = await _tipoMemoriaVramService.AdicionarTipoMemoriaVram(tipoMemoriaRam);

            return Created("Created.", adicionarTipoVram);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<MensagemAoClienteDTO>> AtualizarTipoMemoriaVram([FromRoute] int id, [FromBody] TipoMemoriaVramDTO tipoMemoriaRam)
        {
            MensagemAoClienteDTO atualizarTipoVram = await _tipoMemoriaVramService.AtualizarTipoMemoriaVram(id, tipoMemoriaRam);

            return Ok(atualizarTipoVram);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MensagemAoClienteDTO>> ApagarTipoMemoriaVram([FromRoute] int id)
        {
            MensagemAoClienteDTO apagarTipoVram = await _tipoMemoriaVramService.ApagarTipoMemoriaVram(id);

            return Ok(apagarTipoVram);
        }
    }
}
