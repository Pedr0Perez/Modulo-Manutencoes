﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class DispositivoController : ControllerBase
    {
        private readonly IDispositivoService _dispositivoService;

        public DispositivoController(IDispositivoService dispositivoService)
        {
            _dispositivoService = dispositivoService;
        }

        /// <summary>
        /// Retorna todos dispositivos cadastrados
        /// </summary>
        /// <param name="dispositivo"></param>
        /// <returns>Todos dispositivos</returns>
        /// <response code="200">Dispositivos retornados com sucesso.</response>
        /// <response code="401">Sem autorização.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DispositivoGetDTO>>> RetornarTodosDispositivos()
        {
            IEnumerable<DispositivoGetDTO> listaDispositivos = await _dispositivoService.RetornarTodosDispositivos();

            return Ok(listaDispositivos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DispositivoGetDTO?>> RetornarDispositivo([FromRoute] int id)
        {
            DispositivoGetDTO? dispositivo = await _dispositivoService.RetornarDispositivo(id);

            return Ok(dispositivo);
        }

        [HttpPost]
        public async Task<ActionResult<MensagemAoClienteDTO>> AdicionarDispositivo([FromBody] DispositivoDTO dispositivo)
        {
            MensagemAoClienteDTO adicionarDispositivo = await _dispositivoService.AdicionarDispositivo(dispositivo);

            return Created("Created.", adicionarDispositivo);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<MensagemAoClienteDTO>> AtualizarDispositivo([FromRoute] int id, [FromBody] DispositivoDTO dispositivo)
        {
            MensagemAoClienteDTO atualizarDispositivo = await _dispositivoService.AtualizarDispositivo(id, dispositivo);

            return Ok(atualizarDispositivo);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MensagemAoClienteDTO>> ApagarDispositivo([FromRoute] int id)
        {
            MensagemAoClienteDTO apagarDispositivo = await _dispositivoService.ApagarDispositivo(id);

            return Ok(apagarDispositivo);
        }
    }
}
