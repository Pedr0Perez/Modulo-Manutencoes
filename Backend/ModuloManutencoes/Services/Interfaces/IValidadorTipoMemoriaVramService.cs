namespace ModuloManutencoes.Services.Interfaces
{
    public interface IValidadorTipoMemoriaVramService
    {
        Task ValidarTipoMemoriaVram(string descricao);
        Task ValidarTipoMemoriaVram(int id, string descricao);
        Task ValidarTipoMemoriaVram(int id);
    }
}
