namespace ModuloManutencoes.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> ValidarSeUsuarioExiste(int userId);
        Task<bool> ValidarEmailDisponivel(string email);
        Task<bool> ValidarSeExisteAlgumUsuarioCadastrado();
    }
}
