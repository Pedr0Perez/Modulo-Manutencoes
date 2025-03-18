using ModuloManutencoes.Exceptions.TipoMemoriaVramExceptions;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class ValidadorTipoMemoriaVramService : IValidadorTipoMemoriaVramService
    {
        private readonly ITipoMemoriaVramRepository _repository;

        public ValidadorTipoMemoriaVramService(ITipoMemoriaVramRepository repository)
        {
            _repository = repository;
        }

        public async Task ValidarTipoMemoriaVram(string descricao)
        {
            if (!await _repository.ValidarSeJaExisteUmTipoMemoriaVramComEstaDescricao(descricao))
            {
                throw new DescricaoTipoMemoriaVramJaExisteException();
            }
        }

        public async Task ValidarTipoMemoriaVram(int id, string descricao)
        {
            if (!await _repository.ValidarSeTipoMemoriaVramExiste(id))
            {
                throw new TipoMemoriaVramNaoEncontradoException();
            }

            if (!await _repository.ValidarSeJaExisteUmTipoMemoriaVramComEstaDescricao(id, descricao))
            {
                throw new DescricaoTipoMemoriaVramJaExisteException();
            }
        }

        public async Task ValidarTipoMemoriaVram(int id)
        {
            if (!await _repository.ValidarSeTipoMemoriaVramExiste(id))
            {
                throw new TipoMemoriaVramNaoEncontradoException();
            }
        }
    }
}
