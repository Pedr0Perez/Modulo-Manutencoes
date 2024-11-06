using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Dtos.UsuarioDtos;

namespace ModuloManutencoes.Interfaces.Usuarios
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> RetornarListaUsuarios();
        Task<UsuarioDTO?> RetornarUsuario(int userId);
        Task<MensagemAoClienteDTO> CadastrarUsuario(UsuarioDTO usuario);
        Task<MensagemAoClienteDTO> AtualizarUsuario(int userId, UsuarioDTO usuario);
        Task<MensagemAoClienteDTO> ApagarUsuario(int userId);
    }
}
