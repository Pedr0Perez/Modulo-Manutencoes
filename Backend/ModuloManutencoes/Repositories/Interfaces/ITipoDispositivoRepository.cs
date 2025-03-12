namespace ModuloManutencoes.Repositories.Interfaces
{
    public interface ITipoDispositivoRepository
    {
        Task<bool> ValidarSeTipoDispositivoExiste(int dispId);
    }
}
