using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Exceptions.DispositivoExceptions;
using ModuloManutencoes.Exceptions.TipoDispositivoExceptions;
using ModuloManutencoes.Exceptions.TipoMemoriaRamExceptions;
using ModuloManutencoes.Exceptions.TipoMemoriaVramExceptions;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class ValidadorDispositivoService : IValidadorDispositivoService
    {
        private readonly IDispositivoRepository _repository;
        private readonly ITipoMemoriaRamRepository _ramRepository;
        private readonly ITipoMemoriaVramRepository _vramRepository;
        private readonly ITipoDispositivoRepository _tipoDispRepository;

        public ValidadorDispositivoService(IDispositivoRepository repository, ITipoMemoriaRamRepository ramRepository, ITipoMemoriaVramRepository vramRepository, ITipoDispositivoRepository tipoDispRepository)
        {
            _repository = repository;
            _ramRepository = ramRepository;
            _vramRepository = vramRepository;
            _tipoDispRepository = tipoDispRepository;
        }

        public async Task ValidarDispositivo(DispositivoDTO dispositivo)
        {
            if (!await _repository.ValidarSeJaExisteDispositivoComEsteNome(dispositivo.Nome))
            {
                throw new DispositivoJaExisteException();
            }

            if (!await _tipoDispRepository.ValidarSeTipoDispositivoExiste(dispositivo.Tipo))
            {
                throw new TipoDispositivoNaoEncontradoException();
            }

            if (dispositivo.RamTipo is not null && !await _ramRepository.ValidarSeTipoMemoriaRamExiste(dispositivo.RamTipo ?? 0))
            {
                throw new TipoMemoriaRamNaoEncontradoException();
            }

            if (dispositivo.VramTipo is not null && !await _vramRepository.ValidarSeTipoMemoriaVramExiste(dispositivo.VramTipo ?? 0))
            {
                throw new TipoMemoriaVramNaoEncontradoException();
            }
        }

        public async Task ValidarDispositivo(DispositivoDTO dispositivo, int id)
        {
            if (!await _repository.ValidarSeJaExisteDispositivoComEsteNome(id, dispositivo.Nome))
            {
                throw new DispositivoJaExisteException();
            }

            if (!await _tipoDispRepository.ValidarSeTipoDispositivoExiste(dispositivo.Tipo))
            {
                throw new TipoDispositivoNaoEncontradoException();
            }

            if (dispositivo.RamTipo is not null && !await _ramRepository.ValidarSeTipoMemoriaRamExiste(dispositivo.RamTipo ?? 0))
            {
                throw new TipoMemoriaRamNaoEncontradoException();
            }

            if (dispositivo.VramTipo is not null && !await _vramRepository.ValidarSeTipoMemoriaVramExiste(dispositivo.VramTipo ?? 0))
            {
                throw new TipoMemoriaVramNaoEncontradoException();
            }
        }

        public async Task ValidarDispositivo(int id)
        {
            if (!await _repository.ValidarSeDispositivoExiste(id))
            {
                throw new DispositivoNaoEncontradoException();
            }
        }

    }
}
