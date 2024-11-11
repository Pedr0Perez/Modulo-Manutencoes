using ModuloManutencoes.Dtos.LoginDtos;

namespace ModuloManutencoes.Repositories.Interfaces
{
    public interface IAutenticacaoRepository
    {
        Task<bool> ValidarSeEmailExiste(string email);
        Task<bool> ValidarSenhaUsuario(string email, string senha);
        Task<DadosSessaoDTO> RetornarDadosSessao(string email);
    }
}
