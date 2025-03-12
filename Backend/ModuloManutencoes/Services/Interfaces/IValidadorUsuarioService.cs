namespace ModuloManutencoes.Services.Interfaces
{
    public interface IValidadorUsuarioService
    {
        Task ValidarUsuario(int id);
        Task ValidarUsuario(string email);
        Task<bool> ValidarSeExisteUsuarioSuperAdminCadastrado();
    }
}
