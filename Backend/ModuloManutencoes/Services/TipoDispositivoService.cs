using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class TipoDispositivoService : ITipoDispositivoService
    {
        private readonly ICrud<int, TipoDispositivoDTO, TipoDispositivoGetDTO> _tipoDispositivoCrud;
        private readonly ITipoDispositivoRepository _tipoDispositivoValidation;
        private readonly IValidadorTipoDispositivoService _validadorService;

        public TipoDispositivoService(ICrud<int, TipoDispositivoDTO, TipoDispositivoGetDTO> tipoDispositivoCrud, ITipoDispositivoRepository tipoDispositivoValidation, IValidadorTipoDispositivoService validadorService)
        {
            _tipoDispositivoCrud = tipoDispositivoCrud;
            _tipoDispositivoValidation = tipoDispositivoValidation;
            _validadorService = validadorService;
        }

        public async Task<IEnumerable<TipoDispositivoGetDTO>> RetornarTodosTiposDispositivos()
        {
            IEnumerable<TipoDispositivoGetDTO> listaTipoDispositivo = await _tipoDispositivoCrud.GetAll();

            return listaTipoDispositivo;
        }

        public async Task<TipoDispositivoGetDTO?> RetornarTipoDispositivo(int idTipoDisp)
        {
            TipoDispositivoGetDTO? tipoDispositivo = await _tipoDispositivoCrud.GetById(idTipoDisp);

            return tipoDispositivo;
        }

        public async Task<MensagemAoClienteDTO> AdicionarTipoDispositivo(TipoDispositivoDTO tipoDispositivo)
        {
            await _tipoDispositivoCrud.Create(tipoDispositivo);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de dispositivo adicionado com sucesso.",
                Data = tipoDispositivo
            };
        }

        public async Task<MensagemAoClienteDTO> AtualizarTipoDispositivo(int id, TipoDispositivoDTO tipoDispositivo)
        {
            await _validadorService.ValidarTipoDispositivo(id);

            await _tipoDispositivoCrud.Update(id, tipoDispositivo);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de dispositivo atualizado com sucesso."
            };
        }

        public async Task<MensagemAoClienteDTO> ApagarTipoDispositivo(int id)
        {
            await _validadorService.ValidarTipoDispositivo(id);

            await _tipoDispositivoCrud.Delete(id);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de dispositivo apagado com sucesso."
            };
        }
    }
}
