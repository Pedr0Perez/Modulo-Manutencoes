using ModuloManutencoes.Dtos.LoginDtos;
using ModuloManutencoes.Exceptions.AutenticacaoExceptions;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IAutenticacaoRepository _autenticacaoRepository;

        public AutenticacaoService(IAutenticacaoRepository autenticacaoRepository)
        {
            _autenticacaoRepository = autenticacaoRepository;
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

            DadosSessaoDTO dadosSessao = await _autenticacaoRepository.RetornarDadosSessao(login.Email);

            return dadosSessao;

        }
    }
}
