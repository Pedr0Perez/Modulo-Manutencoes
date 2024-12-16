namespace ModuloManutencoes.Repositories.Interfaces
{
    public interface ITipoMemoriaVramRepository
    {
        Task<bool> ValidarSeTipoMemoriaVramExiste(int id);
        Task<bool> ValidarSeJaExisteUmTipoMemoriaVramComEstaDescricao(string descricao);
        Task<bool> ValidarSeJaExisteUmTipoMemoriaVramComEstaDescricao(int id, string descricao);
    }
}
