using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Dtos.MensagemDtos;

namespace ModuloManutencoes.Services.Interfaces
{
    public interface ITipoDispositivoService
    {
        Task<IEnumerable<TipoDispositivoDTO>> RetornarTodosTiposDispositivos();
        Task<TipoDispositivoDTO?> RetornarTipoDispositivo(int id);
        Task<MensagemAoClienteDTO> AdicionarTipoDispositivo(TipoDispositivoDTO tipoDispositivo);
        Task<MensagemAoClienteDTO> AtualizarTipoDispositivo(int id, TipoDispositivoDTO tipoDispositivo);
        Task<MensagemAoClienteDTO> ApagarTipoDispositivo(int id);
    }
}
