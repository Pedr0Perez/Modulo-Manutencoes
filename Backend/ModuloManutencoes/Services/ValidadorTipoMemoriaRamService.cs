using ModuloManutencoes.Exceptions.TipoMemoriaRamExceptions;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class ValidadorTipoMemoriaRamService : IValidadorTipoMemoriaRamService
    {
        private readonly ITipoMemoriaRamRepository _repository;

        public ValidadorTipoMemoriaRamService(ITipoMemoriaRamRepository repository)
        {
            _repository = repository;
        }

        public async Task ValidarTipoMemoriaRam(string descricao)
        {
            if (await _repository.ValidarSeJaExisteUmTipoMemoriaRamComEstaDescricao(descricao))
            {
                throw new DescricaoTipoMemoriaRamJaExisteException();
            }
        }

        public async Task ValidarTipoMemoriaRam(int id, string descricao)
        {
            if (await _repository.ValidarSeTipoMemoriaRamExiste(id))
            {
                throw new TipoMemoriaRamNaoEncontradoException();
            }

            if (await _repository.ValidarSeJaExisteUmTipoMemoriaRamComEstaDescricao(descricao))
            {
                throw new DescricaoTipoMemoriaRamJaExisteException();
            }
        }

        public async Task ValidarTipoMemoriaRam(int id)
        {
            if (await _repository.ValidarSeTipoMemoriaRamExiste(id))
            {
                throw new TipoMemoriaRamNaoEncontradoException();
            }
        }
    }
}
