using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Exceptions.DispositivoExceptions;
using ModuloManutencoes.Exceptions.TipoDispositivoExceptions;
using ModuloManutencoes.Exceptions.TipoMemoriaRamExceptions;
using ModuloManutencoes.Exceptions.TipoMemoriaVramExceptions;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class DispositivoService : IDispositivoService
    {
        private readonly ICrud<int, DispositivoDTO, DispositivoGetDTO> _dispositivoRepositoryCrud;
        private readonly IDispositivoRepository _dispositivoRepositoryValidation;

        public DispositivoService(ICrud<int, DispositivoDTO, DispositivoGetDTO> dispositivoRepositoryCrud, IDispositivoRepository dispositivoRepositoryValidation)
        {
            _dispositivoRepositoryCrud = dispositivoRepositoryCrud;
            _dispositivoRepositoryValidation = dispositivoRepositoryValidation;
        }

        public async Task<IEnumerable<DispositivoGetDTO>> RetornarTodosDispositivos()
        {
            IEnumerable<DispositivoGetDTO> listaDispositivos = await _dispositivoRepositoryCrud.GetAll();

            return listaDispositivos;
        }

        public async Task<DispositivoGetDTO?> RetornarDispositivo(int id)
        {
            DispositivoGetDTO? dispositivo = await _dispositivoRepositoryCrud.GetById(id);

            return dispositivo;
        }

        public async Task<MensagemAoClienteDTO> AdicionarDispositivo(DispositivoDTO dispositivo)
        {
            bool validarSeJaExisteDispositivoComEsteNome = await _dispositivoRepositoryValidation.ValidarSeJaExisteDispositivoComEsteNome(dispositivo.Nome);
            bool validarSeTipoDispositivoExiste = await _dispositivoRepositoryValidation.ValidarSeTipoDispositivoExiste(dispositivo.Tipo);
            bool validarSeTipoRamExiste = await _dispositivoRepositoryValidation.ValidarSeTipoRamExiste(dispositivo.RamTipo);
            bool validarSeTipoVramExiste = await _dispositivoRepositoryValidation.ValidarSeTipoVramExiste(dispositivo.VramTipo);

            if (!validarSeJaExisteDispositivoComEsteNome)
            {
                throw new DispositivoJaExisteException();
            }

            if (!validarSeTipoDispositivoExiste)
            {
                throw new TipoDispositivoNaoEncontradoException();
            }

            if (!validarSeTipoRamExiste)
            {
                throw new TipoMemoriaRamNaoEncontradoException();
            }

            if (!validarSeTipoVramExiste)
            {
                throw new TipoMemoriaVramNaoEncontradoException();
            }

            MensagemAoClienteDTO adicionarDispositivo = await _dispositivoRepositoryCrud.Create(dispositivo);

            return adicionarDispositivo;
        }

        public async Task<MensagemAoClienteDTO> AtualizarDispositivo(int id, DispositivoDTO dispositivo)
        {
            bool validarSeDispositivoExiste = await _dispositivoRepositoryValidation.ValidarSeDispositivoExiste(id);
            bool validarSeJaExisteDispositivoComEsteNome = await _dispositivoRepositoryValidation.ValidarSeJaExisteDispositivoComEsteNome(id, dispositivo.Nome);
            bool validarSeTipoDispositivoExiste = await _dispositivoRepositoryValidation.ValidarSeTipoDispositivoExiste(dispositivo.Tipo);
            bool validarSeTipoRamExiste = await _dispositivoRepositoryValidation.ValidarSeTipoRamExiste(dispositivo.RamTipo);
            bool validarSeTipoVramExiste = await _dispositivoRepositoryValidation.ValidarSeTipoVramExiste(dispositivo.VramTipo);

            if (!validarSeDispositivoExiste)
            {
                throw new DispositivoNaoEncontradoException();
            }

            if (!validarSeJaExisteDispositivoComEsteNome)
            {
                throw new DispositivoJaExisteException();
            }

            if (!validarSeTipoDispositivoExiste)
            {
                throw new TipoDispositivoNaoEncontradoException();
            }

            if (!validarSeTipoRamExiste)
            {
                throw new TipoMemoriaRamNaoEncontradoException();
            }

            if (!validarSeTipoVramExiste)
            {
                throw new TipoMemoriaVramNaoEncontradoException();
            }

            MensagemAoClienteDTO atualizarDispositivo = await _dispositivoRepositoryCrud.Update(id, dispositivo);

            return atualizarDispositivo;
        }

        public async Task<MensagemAoClienteDTO> ApagarDispositivo(int id)
        {
            bool validarSeDispositivoExiste = await _dispositivoRepositoryValidation.ValidarSeDispositivoExiste(id);

            if (!validarSeDispositivoExiste)
            {
                throw new DispositivoNaoEncontradoException();
            }

            MensagemAoClienteDTO apagarDispositivo = await _dispositivoRepositoryCrud.Delete(id);

            return apagarDispositivo;
        }
    }
}
