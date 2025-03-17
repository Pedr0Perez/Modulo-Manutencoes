namespace ModuloManutencoes.Services.Interfaces
{
    public interface IValidadorTipoMemoriaRam
    {
        Task ValidarTipoMemoriaRam(string descricao);
        Task ValidarTipoMemoriaRam(int id, string descricao);
        Task ValidarTipoMemoriaRam(int id);
    }
}
