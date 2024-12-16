namespace ModuloManutencoes.Repositories.Interfaces
{
    public interface ITipoDispositivoRepository
    {
        Task<bool> ValidarSeDispositivoExiste(int dispId);
    }
}
