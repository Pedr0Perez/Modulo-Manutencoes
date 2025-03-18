using ModuloManutencoes.Exceptions.AutenticacaoExceptions;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class ValidadorAutenticacaoService : IValidadorAutenticacaoService
    {
        private readonly IAutenticacaoRepository _repository;

        public ValidadorAutenticacaoService(IAutenticacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task ValidarCredenciaisInseridas(string email, string senha)
        {
            await ValidarSeEmailExiste(email);
            await ValidarSeSenhaEstaCorreta(email, senha);
        }

        private async Task ValidarSeEmailExiste(string email)
        {
            if (!await _repository.ValidarSeEmailExiste(email))
            {
                throw new EnderecoEmailNaoExisteException();
            }
        }

        private async Task ValidarSeSenhaEstaCorreta(string email, string senha)
        {
            if (!await _repository.ValidarSenhaUsuario(email, senha))
            {
                throw new SenhaIncorretaException();
            }
        }
    }
}
