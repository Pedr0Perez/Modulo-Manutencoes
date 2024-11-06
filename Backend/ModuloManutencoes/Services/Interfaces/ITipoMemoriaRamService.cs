using ModuloManutencoes.Dtos.MemoriaDtos;
using ModuloManutencoes.Dtos.MensagemDtos;

namespace ModuloManutencoes.Services.Interfaces
{
    public interface ITipoMemoriaRamService
    {
        Task<IEnumerable<TipoMemoriaRamDTO>> RetornarTodosTiposMemoriasRam();
        Task<TipoMemoriaRamDTO?> RetornarTipoMemoriaRam(int id);
        Task<MensagemAoClienteDTO> AdicionarTipoMemoriaRam(TipoMemoriaRamDTO tipoMemoriaRam);
        Task<MensagemAoClienteDTO> AtualizarTipoMemoriaRam(int id, TipoMemoriaRamDTO tipoMemoriaRam);
        Task<MensagemAoClienteDTO> ApagarTipoMemoriaRam(int id);
    }
}
