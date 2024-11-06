using Microsoft.EntityFrameworkCore;
using ModuloManutencoes.Contexts;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Dtos.UsuarioDtos;
using ModuloManutencoes.Exceptions.UsuariosExceptions;
using ModuloManutencoes.Models;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Interfaces.Usuarios;
using ModuloManutencoes.Services.Interfaces;
using ModuloManutencoes.Interfaces;

namespace ModuloManutencoes.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ICrud<int, UsuarioDTO> _usuarioRepositoyCrud;
        private readonly IUsuarioRepository _usuarioRepositoryValidation;

        public UsuarioService(ICrud<int, UsuarioDTO> usuarioRepositoyCrud, IUsuarioRepository usuarioRepositoryValidation)
        {
            _usuarioRepositoyCrud = usuarioRepositoyCrud;
            _usuarioRepositoryValidation = usuarioRepositoryValidation;
        }

        public async Task<IEnumerable<UsuarioDTO>> RetornarListaUsuarios()
        {
            IEnumerable<UsuarioDTO> listaUsuarios = await _usuarioRepositoyCrud.GetAll();

            return listaUsuarios;
        }

        public async Task<UsuarioDTO?> RetornarUsuario(int userId)
        {
            UsuarioDTO? usuario = await _usuarioRepositoyCrud.GetById(userId);

            return usuario;
        }

        public async Task<MensagemAoClienteDTO> CadastrarUsuario(UsuarioDTO usuario)
        {
            bool validarSeEmailRecebidoEstaDisponivel = await _usuarioRepositoryValidation.ValidarEmailDisponivel(usuario.Email);
            if (!validarSeEmailRecebidoEstaDisponivel)
            {
                throw new EmailJaCadastradoException();
            }

            await _usuarioRepositoyCrud.Create(usuario);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Usuário cadastrado com sucesso."
            };
        }

        public async Task<MensagemAoClienteDTO> AtualizarUsuario(int userId, UsuarioDTO usuario)
        {
            bool validarSeUsuarioExiste = await _usuarioRepositoryValidation.ValidarSeUsuarioExiste(userId);
            if (!validarSeUsuarioExiste)
            {
                throw new UsuarioNaoEncontradoException();
            }

            await _usuarioRepositoyCrud.Update(userId, usuario);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Usuário atualizado com sucesso."
            };
        }

        public async Task<MensagemAoClienteDTO> ApagarUsuario(int userId)
        {
            bool validarSeUsuarioExiste = await _usuarioRepositoryValidation.ValidarSeUsuarioExiste(userId);
            if (!validarSeUsuarioExiste)
            {
                throw new UsuarioNaoEncontradoException();
            }

            await _usuarioRepositoyCrud.Delete(userId);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Usuário excluído com sucesso."
            };
        }
    }
}
