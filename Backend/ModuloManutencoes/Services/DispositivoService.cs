using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class DispositivoService : IDispositivoService
    {
        private readonly ICrud<int, DispositivoDTO, DispositivoGetDTO> _dispositivoRepositoryCrud;
        private readonly IValidadorDispositivoService _validadorService;

        public DispositivoService(ICrud<int, DispositivoDTO, DispositivoGetDTO> dispositivoRepositoryCrud, IValidadorDispositivoService validadorService)
        {
            _dispositivoRepositoryCrud = dispositivoRepositoryCrud;
            _validadorService = validadorService;
        }

        public async Task<IEnumerable<DispositivoGetDTO>> RetornarTodosDispositivos()
        {
            IEnumerable<DispositivoGetDTO> listaDispositivos = await _dispositivoRepositoryCrud.GetAll();

            return listaDispositivos;
        }

        public async Task<DispositivoGetDTO?> RetornarDispositivo(int id)
        {
            DispositivoGetDTO? dispositivo = await _dispositivoRepositoryCrud.GetById(id);

            return dispositivo;
        }

        public async Task<MensagemAoClienteDTO> AdicionarDispositivo(DispositivoDTO dispositivo)
        {
            await _validadorService.ValidarDispositivo(dispositivo);

            MensagemAoClienteDTO adicionarDispositivo = await _dispositivoRepositoryCrud.Create(dispositivo);

            return adicionarDispositivo;
        }

        public async Task<MensagemAoClienteDTO> AtualizarDispositivo(int id, DispositivoDTO dispositivo)
        {
            await _validadorService.ValidarDispositivo(dispositivo, id);

            MensagemAoClienteDTO atualizarDispositivo = await _dispositivoRepositoryCrud.Update(id, dispositivo);

            return atualizarDispositivo;
        }

        public async Task<MensagemAoClienteDTO> ApagarDispositivo(int id)
        {
            await _validadorService.ValidarDispositivo(id);

            MensagemAoClienteDTO apagarDispositivo = await _dispositivoRepositoryCrud.Delete(id);

            return apagarDispositivo;
        }
    }
}
