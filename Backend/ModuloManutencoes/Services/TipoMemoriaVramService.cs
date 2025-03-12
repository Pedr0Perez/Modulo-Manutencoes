using ModuloManutencoes.Dtos.MemoriaDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Exceptions.TipoMemoriaVramExceptions;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services.Interfaces;

namespace ModuloManutencoes.Services
{
    public class TipoMemoriaVramService : ITipoMemoriaVramService
    {

        private readonly ICrud<int, TipoMemoriaVramDTO, TipoMemoriaVramGetDTO> _tipoMemoriaVramCrud;
        private readonly ITipoMemoriaVramRepository _tipoMemoriaVramValidation;

        public TipoMemoriaVramService(ICrud<int, TipoMemoriaVramDTO, TipoMemoriaVramGetDTO> tipoMemoriaRamCrud, ITipoMemoriaVramRepository tipoMemoriaRamValidation)
        {
            _tipoMemoriaVramCrud = tipoMemoriaRamCrud;
            _tipoMemoriaVramValidation = tipoMemoriaRamValidation;
        }

        public async Task<IEnumerable<TipoMemoriaVramGetDTO>> RetornarTodosTiposMemoriasVram()
        {
            IEnumerable<TipoMemoriaVramGetDTO> listaTipoVram = await _tipoMemoriaVramCrud.GetAll();

            return listaTipoVram;
        }

        public async Task<TipoMemoriaVramGetDTO?> RetornarTipoMemoriaVram(int id)
        {
            TipoMemoriaVramGetDTO? tipoVram = await _tipoMemoriaVramCrud.GetById(id);

            return tipoVram;
        }

        public async Task<MensagemAoClienteDTO> AdicionarTipoMemoriaVram(TipoMemoriaVramDTO tipoMemoriaVram)
        {
            bool validarSeJaExisteTipoVramComEstaDescricao = await _tipoMemoriaVramValidation.ValidarSeJaExisteUmTipoMemoriaVramComEstaDescricao(tipoMemoriaVram.Descricao);
            if (!validarSeJaExisteTipoVramComEstaDescricao)
            {
                throw new DescricaoTipoMemoriaVramJaExisteException();
            }

            await _tipoMemoriaVramCrud.Create(tipoMemoriaVram);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de memória VRAM adicionado com sucesso.",
                Data = tipoMemoriaVram
            };
        }

        public async Task<MensagemAoClienteDTO> AtualizarTipoMemoriaVram(int id, TipoMemoriaVramDTO tipoMemoriaVram)
        {
            bool validarSeTipoVramExiste = await _tipoMemoriaVramValidation.ValidarSeTipoMemoriaVramExiste(id);
            bool validarSeJaExisteTipoVramComEstaDescricao = await _tipoMemoriaVramValidation.ValidarSeJaExisteUmTipoMemoriaVramComEstaDescricao(id, tipoMemoriaVram.Descricao);

            if (!validarSeTipoVramExiste)
            {
                throw new TipoMemoriaVramNaoEncontradoException();
            }

            if (!validarSeJaExisteTipoVramComEstaDescricao)
            {
                throw new DescricaoTipoMemoriaVramJaExisteException();
            }

            await _tipoMemoriaVramCrud.Update(id, tipoMemoriaVram);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de memória VRAM atualizado com sucesso."
            };
        }

        public async Task<MensagemAoClienteDTO> ApagarTipoMemoriaVram(int id)
        {
            bool validarSeTipoVramExiste = await _tipoMemoriaVramValidation.ValidarSeTipoMemoriaVramExiste(id);

            if (!validarSeTipoVramExiste)
            {

                throw new TipoMemoriaVramNaoEncontradoException();
            }

            await _tipoMemoriaVramCrud.Delete(id);

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de memória VRAM apagado com sucesso."
            };
        }
    }
}
