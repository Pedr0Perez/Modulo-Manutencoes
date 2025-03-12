using ModuloManutencoes.Dtos.MemoriaDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Exceptions.TipoMemoriaRamExceptions;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class TipoMemoriaRamService : ITipoMemoriaRamService
    {
        private readonly ICrud<int, TipoMemoriaRamDTO, TipoMemoriaRamGetDTO> _tipoMemoriaRamCrud;
        private readonly ITipoMemoriaRamRepository _tipoMemoriaRamValidation;

        public TipoMemoriaRamService(ICrud<int, TipoMemoriaRamDTO, TipoMemoriaRamGetDTO> tipoMemoriaRamCrud, ITipoMemoriaRamRepository tipoMemoriaRamValidation)
        {
            _tipoMemoriaRamCrud = tipoMemoriaRamCrud;
            _tipoMemoriaRamValidation = tipoMemoriaRamValidation;
        }

        public async Task<IEnumerable<TipoMemoriaRamGetDTO>> RetornarTodosTiposMemoriasRam()
        {
            IEnumerable<TipoMemoriaRamGetDTO> listaTipoRam = await _tipoMemoriaRamCrud.GetAll();

            return listaTipoRam;
        }

        public async Task<TipoMemoriaRamGetDTO?> RetornarTipoMemoriaRam(int id)
        {
            TipoMemoriaRamGetDTO? tipoRam = await _tipoMemoriaRamCrud.GetById(id);

            return tipoRam;
        }

        public async Task<MensagemAoClienteDTO> AdicionarTipoMemoriaRam(TipoMemoriaRamDTO tipoMemoriaRam)
        {
            bool validarSeJaExisteTipoRamComEstaDescricao = await _tipoMemoriaRamValidation.ValidarSeJaExisteUmTipoMemoriaRamComEstaDescricao(tipoMemoriaRam.Descricao);
            if (!validarSeJaExisteTipoRamComEstaDescricao)
            {
                throw new DescricaoTipoMemoriaRamJaExisteException();
            }

            await _tipoMemoriaRamCrud.Create(tipoMemoriaRam);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de memória RAM adicionado com sucesso.",
                Data = tipoMemoriaRam
            };
        }

        public async Task<MensagemAoClienteDTO> AtualizarTipoMemoriaRam(int id, TipoMemoriaRamDTO tipoMemoriaRam)
        {
            bool validarSeTipoRamExiste = await _tipoMemoriaRamValidation.ValidarSeTipoMemoriaRamExiste(id);
            bool validarSeJaExisteTipoRamComEstaDescricao = await _tipoMemoriaRamValidation.ValidarSeJaExisteUmTipoMemoriaRamComEstaDescricao(id, tipoMemoriaRam.Descricao);

            if (!validarSeTipoRamExiste)
            {
                throw new TipoMemoriaRamNaoEncontradoException();
            }

            if (!validarSeJaExisteTipoRamComEstaDescricao)
            {
                throw new DescricaoTipoMemoriaRamJaExisteException();
            }

            await _tipoMemoriaRamCrud.Update(id, tipoMemoriaRam);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de memória RAM atualizado com sucesso."
            };
        }

        public async Task<MensagemAoClienteDTO> ApagarTipoMemoriaRam(int id)
        {
            bool validarSeTipoRamExiste = await _tipoMemoriaRamValidation.ValidarSeTipoMemoriaRamExiste(id);

            if (!validarSeTipoRamExiste)
            {
                throw new TipoMemoriaRamNaoEncontradoException();
            }

            await _tipoMemoriaRamCrud.Delete(id);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de memória RAM apagado com sucesso."
            };
        }
    }
}
