using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Exceptions.TipoDispositivoExceptions;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class TipoDispositivoService : ITipoDispositivoService
    {
        private readonly ICrud<int, TipoDispositivoDTO> _tipoDispositivoCrud;
        private readonly ITipoDispositivoRepository _tipoDispositivoValidation;

        public TipoDispositivoService(ICrud<int, TipoDispositivoDTO> tipoDispositivoCrud, ITipoDispositivoRepository tipoDispositivoValidation)
        {
            _tipoDispositivoCrud = tipoDispositivoCrud;
            _tipoDispositivoValidation = tipoDispositivoValidation;
        }

        public async Task<IEnumerable<TipoDispositivoDTO>> RetornarTodosTiposDispositivos()
        {
            IEnumerable<TipoDispositivoDTO> listaTipoDispositivo = await _tipoDispositivoCrud.GetAll();
            return listaTipoDispositivo;
        }

        public async Task<TipoDispositivoDTO?> RetornarTipoDispositivo(int idTipoDisp)
        {
            TipoDispositivoDTO? tipoDispositivo = await _tipoDispositivoCrud.GetById(idTipoDisp);
            return tipoDispositivo;
        }

        public async Task<MensagemAoClienteDTO> AdicionarTipoDispositivo(TipoDispositivoDTO tipoDispositivo)
        {
            MensagemAoClienteDTO adicionarDispositivo = await _tipoDispositivoCrud.Create(tipoDispositivo);
            return adicionarDispositivo;
        }

        public async Task<MensagemAoClienteDTO> AtualizarTipoDispositivo(int idTipoDisp, TipoDispositivoDTO tipoDispositivo)
        {
            bool validarSeTipoDispositivoExiste = await _tipoDispositivoValidation.ValidarSeDispositivoExiste(idTipoDisp);
            if (!validarSeTipoDispositivoExiste)
            {
                throw new TipoDispositivoNaoEncontradoException();
            }

            MensagemAoClienteDTO atualizarDispositivo = await _tipoDispositivoCrud.Update(idTipoDisp, tipoDispositivo);
            return atualizarDispositivo;
        }

        public async Task<MensagemAoClienteDTO> ApagarTipoDispositivo(int idTipoDisp)
        {
            bool validarSeTipoDispositivoExiste = await _tipoDispositivoValidation.ValidarSeDispositivoExiste(idTipoDisp);
            if (!validarSeTipoDispositivoExiste)
            {
                throw new TipoDispositivoNaoEncontradoException();
            }

            MensagemAoClienteDTO apagarDispositivo = await _tipoDispositivoCrud.Delete(idTipoDisp);
            return apagarDispositivo;
        }
    }
}
