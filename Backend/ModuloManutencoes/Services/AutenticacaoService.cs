using System.ComponentModel.DataAnnotations;
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
        private readonly IValidadorAutenticacaoService _validador;

        public AutenticacaoService(IAutenticacaoRepository autenticacaoRepository, IConfiguration configuration, IValidadorAutenticacaoService validador)
        {
            _autenticacaoRepository = autenticacaoRepository;
            _configuration = configuration;
            _validador = validador;
        }

        public async Task<DadosSessaoDTO> RealizarAutenticacao(LoginDTO login)
        {
            await _validador.ValidarCredenciaisInseridas(login.Email, login.Senha);

            DadosUsuarioDTO dadosUsuario = await _autenticacaoRepository.RetornarDadosSessao(login.Email);

            string token = GerarToken(dadosUsuario.Id.ToString());

            DadosSessaoDTO dadosSessao = MapearDadosSessao(dadosUsuario, token);

            return dadosSessao;
        }

        private DadosSessaoDTO MapearDadosSessao(DadosUsuarioDTO dadosUsuario, string token)
        {
            return new DadosSessaoDTO
            {
                Nome = dadosUsuario.Nome,
                Email = dadosUsuario.Email,
                Genero = dadosUsuario.Genero,
                Token = token,
            };
        }

        private string GerarToken(string userId)
        {
            string jwtKey = ColetarJwtKey();

            string jwtIssuer = ColetarJwtIssuer();

            var claims = CriarClaims(userId);

            var securityKey = GerarChaveSeguranca(jwtKey);
            var credentials = GerarCredenciaisAssinatura(securityKey);

            var token = CriarToken(jwtIssuer, claims, credentials);

            return ConverterTokenParaString(token);
        }

        private string ColetarJwtKey()
        {
            return _configuration.GetSection("JwtConfiguration")["SecretJwtKey"];
        }

        private string ColetarJwtIssuer()
        {
            return _configuration.GetSection("JwtConfiguration")["Issuer"];
        }

        private Claim[] CriarClaims(string userId)
        {
            return new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
        }

        private SymmetricSecurityKey GerarChaveSeguranca(string jwtKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        }

        private SigningCredentials GerarCredenciaisAssinatura(SymmetricSecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }

        private JwtSecurityToken CriarToken(string jwtIssuer, Claim[] claims, SigningCredentials credentials)
        {
            return new JwtSecurityToken(issuer: jwtIssuer, audience: jwtIssuer, claims: claims, expires: DateTime.UtcNow.AddHours(12), signingCredentials: credentials);
        }

        private string ConverterTokenParaString(JwtSecurityToken token)
        {
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
