
using ModuloManutencoes.Exceptions.TipoDispositivoExceptions;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class ValidadorTipoDispositivoService : IValidadorTipoDispositivoService
    {
        private readonly ITipoDispositivoRepository _repository;

        public ValidadorTipoDispositivoService(ITipoDispositivoRepository repository)
        {
            _repository = repository;
        }

        public async Task ValidarTipoDispositivo(int id)
        {
            if (!await _repository.ValidarSeTipoDispositivoExiste(id))
            {
                throw new TipoDispositivoNaoEncontradoException();
            }
        }
    }
}
