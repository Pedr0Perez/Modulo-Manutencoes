using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ModuloManutencoes.Dtos.LoginDtos;
using ModuloManutencoes.Exceptions.AutenticacaoExceptions;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IAutenticacaoRepository _autenticacaoRepository;
        private readonly IConfiguration _configuration;

        public AutenticacaoService(IAutenticacaoRepository autenticacaoRepository, IConfiguration configuration)
        {
            _autenticacaoRepository = autenticacaoRepository;
            _configuration = configuration;
        }

        public async Task<DadosSessaoDTO> RealizarAutenticacao(LoginDTO login)
        {
            bool validarSeEmailExiste = await _autenticacaoRepository.ValidarSeEmailExiste(login.Email);
            if (!validarSeEmailExiste)
            {
                throw new EnderecoEmailNaoExisteException();
            }

            bool validarSenhaUsuario = await _autenticacaoRepository.ValidarSenhaUsuario(login.Email, login.Senha);

            if (!validarSenhaUsuario)
            {
                throw new SenhaIncorretaException();
            }

            DadosUsuarioDTO dadosUsuario = await _autenticacaoRepository.RetornarDadosSessao(login.Email);
            string token = GerarToken(dadosUsuario.Id.ToString());

            DadosSessaoDTO dadosSessao = new DadosSessaoDTO
            {
                Nome = dadosUsuario.Nome,
                Email = dadosUsuario.Email,
                Genero = dadosUsuario.Genero,
                Token = token,
            };

            return dadosSessao;

        }



        private string GerarToken(string userId)
        {
            string jwtKey = _configuration.GetSection("JwtConfiguration")["SecretJwtKey"];

            string jwtIssuer = _configuration.GetSection("JwtConfiguration")["Issuer"];

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfiguration")["SecretJwtKey"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(issuer: jwtIssuer, audience: jwtIssuer, claims: claims, expires: DateTime.UtcNow.AddHours(1), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
