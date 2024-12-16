using ModuloManutencoes.Dtos.LoginDtos;

namespace ModuloManutencoes.Services.Interfaces
{
    public interface IAutenticacaoService
    {
        Task<DadosSessaoDTO> RealizarAutenticacao(LoginDTO login);
    }
}
