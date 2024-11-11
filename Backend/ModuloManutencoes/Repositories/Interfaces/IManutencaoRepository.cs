namespace ModuloManutencoes.Repositories.Interfaces
{
    public interface IManutencaoRepository
    {
        Task<bool> ValidarSeManutencaoExiste(int id);
        Task<bool> ValidarSeManutencaoNaoFoiEncerrada(int id);
        Task<bool> ValidarSeDispositivoExiste(int id);
    }
}
