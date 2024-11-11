using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModuloManutencoes.Contexts;
using ModuloManutencoes.Dtos.LoginDtos;
using ModuloManutencoes.Models;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Repositories
{
    public class AutenticacaoRepository : IAutenticacaoRepository
    {
        private readonly MODMANUTENCOESContext _moduloManutencoesContext;
        private readonly IPasswordHasher _passwordHasherService;

        public AutenticacaoRepository(MODMANUTENCOESContext moduloManutencoesContext, IPasswordHasher passwordHasherService)
        {
            _moduloManutencoesContext = moduloManutencoesContext;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<bool> ValidarSeEmailExiste(string email)
        {
            Usuario? usuario = await _moduloManutencoesContext.Usuarios
                                .Where(u => u.Active == "Y" && u.Mail == email)
                                .FirstOrDefaultAsync();

            return usuario != null;
        }

        public async Task<bool> ValidarSenhaUsuario(string email, string senha)
        {
            string? senhaCriptografada = await _moduloManutencoesContext.Usuarios
                                    .Where(u => u.Mail == email)
                                    .Select(u => u.Password)
                                    .FirstOrDefaultAsync();

            PasswordVerificationResult validarSenha = _passwordHasherService.VerifyPassword(senhaCriptografada!, senha);

            if (validarSenha == PasswordVerificationResult.Success || validarSenha == PasswordVerificationResult.SuccessRehashNeeded)
            {
                return true;
            }

            return false;
        }

        public async Task<DadosSessaoDTO> RetornarDadosSessao(string email)
        {
            DadosSessaoDTO? dadosSessao = await _moduloManutencoesContext.Usuarios
                                            .Where(u => u.Mail == email)
                                            .Select(u => new DadosSessaoDTO
                                            {
                                                Email = u.Mail,
                                                Nome = u.FirstName + " " + u.LastName,
                                                Genero = u.Gender,
                                                Token = "teste"
                                            }).FirstOrDefaultAsync();

            return dadosSessao!;
        }
    }
}
