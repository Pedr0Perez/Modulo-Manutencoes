namespace ModuloManutencoes.Repositories.Interfaces
{
    public interface IDispositivoRepository
    {
        Task<bool> ValidarSeJaExisteDispositivoComEsteNome(string nome);
        Task<bool> ValidarSeJaExisteDispositivoComEsteNome(int id, string nome);
        Task<bool> ValidarSeDispositivoExiste(int id);
    }
}
