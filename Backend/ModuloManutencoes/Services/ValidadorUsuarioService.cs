using ModuloManutencoes.Contexts;
using ModuloManutencoes.Exceptions.UsuariosExceptions;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class ValidadorUsuarioService : IValidadorUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public ValidadorUsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task ValidarUsuario(int id)
        {
            if (!await _repository.ValidarSeUsuarioExiste(id))
            {
                throw new UsuarioNaoEncontradoException();
            }
        }

        public async Task ValidarUsuario(string email)
        {
            if (!await _repository.ValidarEmailDisponivel(email))
            {
                throw new UsuarioNaoEncontradoException();
            }
        }

        public async Task<bool> ValidarSeExisteUsuarioSuperAdminCadastrado()
        {
            return await _repository.ValidarSeExisteUsuarioSuperAdminCadastrado();
        }
    }
}
