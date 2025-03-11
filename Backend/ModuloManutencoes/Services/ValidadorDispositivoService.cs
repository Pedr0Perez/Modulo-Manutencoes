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

        public ValidadorDispositivoService(IDispositivoRepository repository)
        {
            _repository = repository;
        }

        public async Task ValidarDispositivo(DispositivoDTO dispositivo)
        {
            if (!await _repository.ValidarSeJaExisteDispositivoComEsteNome(dispositivo.Nome))
            {
                throw new DispositivoJaExisteException();
            }

            if (!await _repository.ValidarSeTipoDispositivoExiste(dispositivo.Tipo))
            {
                throw new TipoDispositivoNaoEncontradoException();
            }

            if (!await _repository.ValidarSeTipoRamExiste(dispositivo.RamTipo))
            {
                throw new TipoMemoriaRamNaoEncontradoException();
            }

            if (!await _repository.ValidarSeTipoVramExiste(dispositivo.VramTipo))
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

            if (!await _repository.ValidarSeTipoDispositivoExiste(dispositivo.Tipo))
            {
                throw new TipoDispositivoNaoEncontradoException();
            }

            if (!await _repository.ValidarSeTipoRamExiste(dispositivo.RamTipo))
            {
                throw new TipoMemoriaRamNaoEncontradoException();
            }

            if (!await _repository.ValidarSeTipoVramExiste(dispositivo.VramTipo))
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
