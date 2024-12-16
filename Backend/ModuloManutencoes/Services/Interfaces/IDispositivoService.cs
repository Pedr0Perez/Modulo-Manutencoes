using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Dtos.MensagemDtos;

namespace ModuloManutencoes.Services.Interfaces
{
    public interface IDispositivoService
    {
        Task<IEnumerable<DispositivoGetDTO>> RetornarTodosDispositivos();
        Task<DispositivoGetDTO?> RetornarDispositivo(int id);
        Task<MensagemAoClienteDTO> AdicionarDispositivo(DispositivoDTO dispositivo);
        Task<MensagemAoClienteDTO> AtualizarDispositivo(int id, DispositivoDTO dispositivo);
        Task<MensagemAoClienteDTO> ApagarDispositivo(int id);
    }
}
