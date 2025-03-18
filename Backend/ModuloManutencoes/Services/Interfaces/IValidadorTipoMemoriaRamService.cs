namespace ModuloManutencoes.Services.Interfaces
{
    public interface IValidadorTipoMemoriaRamService
    {
        Task ValidarTipoMemoriaRam(string descricao);
        Task ValidarTipoMemoriaRam(int id, string descricao);
        Task ValidarTipoMemoriaRam(int id);
    }
}
