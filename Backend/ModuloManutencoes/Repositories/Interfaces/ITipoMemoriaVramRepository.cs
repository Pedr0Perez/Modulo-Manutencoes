namespace ModuloManutencoes.Repositories.Interfaces
{
    public interface ITipoMemoriaRamRepository
    {
        Task<bool> ValidarSeTipoMemoriaRamExiste(int id);
        Task<bool> ValidarSeJaExisteUmTipoMemoriaRamComEstaDescricao(string descricao);
        Task<bool> ValidarSeJaExisteUmTipoMemoriaRamComEstaDescricao(int id, string descricao);
    }
}
