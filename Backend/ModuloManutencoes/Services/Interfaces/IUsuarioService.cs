using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Dtos.UsuarioDtos;

namespace ModuloManutencoes.Interfaces.Usuarios
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioGetDTO>> RetornarListaUsuarios();
        Task<UsuarioGetDTO?> RetornarUsuario(int userId);
        Task<MensagemAoClienteDTO> CadastrarUsuario(UsuarioDTO usuario);
        Task<MensagemAoClienteDTO> AtualizarUsuario(int userId, UsuarioDTO usuario);
        Task<MensagemAoClienteDTO> ApagarUsuario(int userId);
        Task CadastrarUsuarioSuperAdministradorCasoNaoExistaNenhum();
    }
}
