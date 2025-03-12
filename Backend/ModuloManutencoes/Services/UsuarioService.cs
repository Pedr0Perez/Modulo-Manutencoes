using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Dtos.UsuarioDtos;
using ModuloManutencoes.Interfaces.Usuarios;
using ModuloManutencoes.Services.Interfaces;
using ModuloManutencoes.Interfaces;

namespace ModuloManutencoes.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ICrud<int, UsuarioDTO, UsuarioGetDTO> _usuarioRepositoyCrud;
        private readonly IConfiguration _configuration;
        private readonly IValidadorUsuarioService _validadorService;

        public UsuarioService(ICrud<int, UsuarioDTO, UsuarioGetDTO> usuarioRepositoyCrud, IConfiguration configuration, IValidadorUsuarioService validadorService)
        {
            _usuarioRepositoyCrud = usuarioRepositoyCrud;
            _configuration = configuration;
            _validadorService = validadorService;
        }

        public async Task<IEnumerable<UsuarioGetDTO>> RetornarListaUsuarios()
        {
            IEnumerable<UsuarioGetDTO> listaUsuarios = await _usuarioRepositoyCrud.GetAll();

            return listaUsuarios;
        }

        public async Task<UsuarioGetDTO?> RetornarUsuario(int userId)
        {
            UsuarioGetDTO? usuario = await _usuarioRepositoyCrud.GetById(userId);

            return usuario;
        }

        public async Task<MensagemAoClienteDTO> CadastrarUsuario(UsuarioDTO usuario)
        {
            await _validadorService.ValidarUsuario(usuario.Email);

            await _usuarioRepositoyCrud.Create(usuario);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Usuário cadastrado com sucesso.",
                Data = usuario
            };
        }

        public async Task<MensagemAoClienteDTO> AtualizarUsuario(int userId, UsuarioDTO usuario)
        {
            await _validadorService.ValidarUsuario(userId);

            await _usuarioRepositoyCrud.Update(userId, usuario);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Usuário atualizado com sucesso."
            };
        }

        public async Task<MensagemAoClienteDTO> ApagarUsuario(int userId)
        {
            await _validadorService.ValidarUsuario(userId);

            await _usuarioRepositoyCrud.Delete(userId);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Usuário excluído com sucesso."
            };
        }

        public async Task CadastrarUsuarioSuperAdministradorCasoNaoExista()
        {
            if (!await _validadorService.ValidarSeExisteUsuarioSuperAdminCadastrado())
            {
                await _usuarioRepositoyCrud.Create(new UsuarioDTO
                {
                    PrimeiroNome = "Super",
                    Sobrenome = "Administrador",
                    Email = _configuration.GetSection("SuperAdmin")["Email"],
                    Senha = _configuration.GetSection("SuperAdmin")["Password"],
                    Genero = "E",
                    Admin = "Y",
                    SuperAdmin = "Y"
                });
            }
        }
    }
}

