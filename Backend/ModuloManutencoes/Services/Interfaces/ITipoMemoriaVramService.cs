using ModuloManutencoes.Dtos.MemoriaDtos;
using ModuloManutencoes.Dtos.MensagemDtos;

namespace ModuloManutencoes.Services.Interfaces
{
    public interface ITipoMemoriaVramService
    {
        Task<IEnumerable<TipoMemoriaVramGetDTO>> RetornarTodosTiposMemoriasVram();
        Task<TipoMemoriaVramGetDTO?> RetornarTipoMemoriaVram(int id);
        Task<MensagemAoClienteDTO> AdicionarTipoMemoriaVram(TipoMemoriaVramDTO tipoMemoriaVram);
        Task<MensagemAoClienteDTO> AtualizarTipoMemoriaVram(int id, TipoMemoriaVramDTO tipoMemoriaVram);
        Task<MensagemAoClienteDTO> ApagarTipoMemoriaVram(int id);
    }
}
