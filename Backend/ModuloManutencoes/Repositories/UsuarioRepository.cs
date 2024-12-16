using Microsoft.EntityFrameworkCore;
using ModuloManutencoes.Contexts;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Dtos.UsuarioDtos;
using ModuloManutencoes.Exceptions.UsuariosExceptions;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Interfaces.Usuarios;
using ModuloManutencoes.Models;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Repositories
{
    public class UsuarioRepository : ICrud<int, UsuarioDTO, UsuarioGetDTO>, IUsuarioRepository
    {
        private readonly MODMANUTENCOESContext _modManutencoesContext;
        private readonly IPasswordHasher _passwordHasher;

        public UsuarioRepository(MODMANUTENCOESContext modManutencoesContext, IPasswordHasher passwordHasher)
        {
            _modManutencoesContext = modManutencoesContext;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<UsuarioGetDTO>> GetAll()
        {
            IEnumerable<UsuarioGetDTO> listaUsuarios = await _modManutencoesContext.Usuarios
                                                            .Where(u => u.Active == "Y")
                                                            .Select(u => new UsuarioGetDTO
                                                            {
                                                                Id = u.Id,
                                                                PrimeiroNome = u.FirstName,
                                                                Sobrenome = u.LastName,
                                                                Email = u.Mail,
                                                                Email2 = u.Mail2,
                                                                DataNascimento = u.BirthDate,
                                                                Genero = u.Gender,
                                                                Pais = u.Country,
                                                                Cidade = u.City,
                                                                Estado = u.State
                                                            }).ToListAsync();

            return listaUsuarios;
        }

        public async Task<UsuarioGetDTO?> GetById(int userId)
        {
            UsuarioGetDTO? usuario = await _modManutencoesContext.Usuarios
                                        .Where(u => u.Id == userId && u.Active == "Y")
                                        .Select(u => new UsuarioGetDTO
                                        {
                                            Id = u.Id,
                                            PrimeiroNome = u.FirstName,
                                            Sobrenome = u.LastName,
                                            Email = u.Mail,
                                            Email2 = u.Mail2,
                                            DataNascimento = u.BirthDate,
                                            Genero = u.Gender,
                                            Pais = u.Country,
                                            Cidade = u.City,
                                            Estado = u.State
                                        }).FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<MensagemAoClienteDTO> Create(UsuarioDTO usuario)
        {
            await _modManutencoesContext.Usuarios.AddAsync(new Usuario
            {
                FirstName = usuario.PrimeiroNome,
                LastName = usuario.Sobrenome,
                Mail = usuario.Email,
                Mail2 = usuario.Email2,
                Password = _passwordHasher.HashPassword(usuario.Senha),
                BirthDate = usuario.DataNascimento,
                Gender = usuario.Genero,
                Country = usuario.Pais,
                City = usuario.Cidade,
                State = usuario.Estado,
                Active = "Y",
                Admin = usuario.Admin,
                SuperAdmin = usuario.SuperAdmin,
            });

            await _modManutencoesContext.SaveChangesAsync();

            return new MensagemAoClienteDTO
            {
                Mensagem = "Usuário cadastrado com sucesso.",
                Data = usuario
            };
        }

        public async Task<MensagemAoClienteDTO> Update(int userId, UsuarioDTO usuario)
        {
            Usuario? usuarioAtualizar = await _modManutencoesContext.Usuarios.FindAsync(userId);

            usuarioAtualizar!.FirstName = usuario.PrimeiroNome;
            usuarioAtualizar.LastName = usuario.Sobrenome;
            usuarioAtualizar.Mail = usuario.Email;
            usuarioAtualizar.Mail2 = usuario.Email2;
            usuarioAtualizar.BirthDate = usuario.DataNascimento;
            usuarioAtualizar.Gender = usuario.Genero;
            usuarioAtualizar.Country = usuario.Pais;
            usuarioAtualizar.City = usuario.Cidade;
            usuarioAtualizar.State = usuario.Estado;

            await _modManutencoesContext.SaveChangesAsync();

            return new MensagemAoClienteDTO
            {
                Mensagem = "Usuário atualizado com sucesso."
            };
        }

        public async Task<MensagemAoClienteDTO> Delete(int userId)
        {
            Usuario? usuarioAtualizar = await _modManutencoesContext.Usuarios.FindAsync(userId);

            usuarioAtualizar!.Active = "N";

            await _modManutencoesContext.SaveChangesAsync();

            return new MensagemAoClienteDTO
            {
                Mensagem = "Usuário excluído com sucesso."
            };
        }

        public async Task<bool> ValidarSeUsuarioExiste(int userId)
        {
            Usuario? usuario = await _modManutencoesContext.Usuarios
                .Where(u => u.Active == "Y" && u.Id == userId)
                .FirstOrDefaultAsync();

            return usuario != null;
        }

        public async Task<bool> ValidarEmailDisponivel(string email)
        {
            string? emailJaExiste = await _modManutencoesContext.Usuarios
                             .Where(u => u.Mail == email)
                             .Select(u => u.Mail)
                             .FirstOrDefaultAsync();

            return emailJaExiste != null ? false : true;
        }

        public async Task<bool> ValidarSeExisteUsuarioSuperAdminCadastrado()
        {
            bool hasSuperAdmin = await _modManutencoesContext.Usuarios
                            .Where(u => u.SuperAdmin == "Y")
                            .AnyAsync();

            return hasSuperAdmin;
        }
    }
}
