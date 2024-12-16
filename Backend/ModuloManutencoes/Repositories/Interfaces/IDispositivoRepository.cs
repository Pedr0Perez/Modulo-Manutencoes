namespace ModuloManutencoes.Repositories.Interfaces
{
    public interface IDispositivoRepository
    {
        Task<bool> ValidarSeJaExisteDispositivoComEsteNome(string nome);
        Task<bool> ValidarSeJaExisteDispositivoComEsteNome(int id, string nome);
        Task<bool> ValidarSeDispositivoExiste(int id);
        Task<bool> ValidarSeTipoDispositivoExiste(int id);
        Task<bool> ValidarSeTipoRamExiste(int? id);
        Task<bool> ValidarSeTipoVramExiste(int? id);
    }
}
