namespace ModuloManutencoes.Services.Interfaces
{
    public interface IValidadorAutenticacaoService
    {
        Task ValidarCredenciaisInseridas(string email, string senha);
    }
}
