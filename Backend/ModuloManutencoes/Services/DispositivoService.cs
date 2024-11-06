using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Exceptions.DispositivoExceptions;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class DispositivoService : IDispositivoService
    {
        private readonly ICrud<int, DispositivoDTO> _dispositivoRepositoryCrud;
        private readonly IDispositivoRepository _dispositivoRepositoryValidation;

        public DispositivoService(ICrud<int, DispositivoDTO> dispositivoRepositoryCrud, IDispositivoRepository dispositivoRepositoryValidation)
        {
            _dispositivoRepositoryCrud = dispositivoRepositoryCrud;
            _dispositivoRepositoryValidation = dispositivoRepositoryValidation;
        }

        public async Task<IEnumerable<DispositivoDTO>> RetornarTodosDispositivos()
        {
            IEnumerable<DispositivoDTO> listaDispositivos = await _dispositivoRepositoryCrud.GetAll();

            return listaDispositivos;
        }

        public async Task<DispositivoDTO?> RetornarDispositivo(int id)
        {
            DispositivoDTO? dispositivo = await _dispositivoRepositoryCrud.GetById(id);

            return dispositivo;
        }

        public async Task<MensagemAoClienteDTO> AdicionarDispositivo(DispositivoDTO dispositivo)
        {
            bool validarSeJaExisteDispositivoComEsteNome = await _dispositivoRepositoryValidation.ValidarSeJaExisteDispositivoComEsteNome(dispositivo.Nome);
            if (!validarSeJaExisteDispositivoComEsteNome)
            {
                throw new DispositivoJaExisteException();
            }

            MensagemAoClienteDTO adicionarDispositivo = await _dispositivoRepositoryCrud.Create(dispositivo);

            return adicionarDispositivo;
        }

        public async Task<MensagemAoClienteDTO> AtualizarDispositivo(int id, DispositivoDTO dispositivo)
        {
            bool validarSeDispositivoExiste = await _dispositivoRepositoryValidation.ValidarSeDispositivoExiste(id);
            bool validarSeJaExisteDispositivoComEsteNome = await _dispositivoRepositoryValidation.ValidarSeJaExisteDispositivoComEsteNome(id, dispositivo.Nome);

            if (!validarSeDispositivoExiste)
            {
                throw new DispositivoNaoEncontradoException();
            }

            if (!validarSeJaExisteDispositivoComEsteNome)
            {
                throw new DispositivoJaExisteException();
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
