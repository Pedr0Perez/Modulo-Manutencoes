using Microsoft.EntityFrameworkCore;
using ModuloManutencoes.Contexts;
using ModuloManutencoes.Dtos.MemoriaDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Models;
using ModuloManutencoes.Repositories.Interfaces;

namespace ModuloManutencoes.Repositories
{
    public class TipoMemoriaVramRepository : ICrud<int, TipoMemoriaVramDTO, TipoMemoriaVramGetDTO>, ITipoMemoriaVramRepository
    {
        private readonly MODMANUTENCOESContext _modManutencoesContext;

        public TipoMemoriaVramRepository(MODMANUTENCOESContext modManutencoesContext)
        {
            _modManutencoesContext = modManutencoesContext;
        }

        public async Task<IEnumerable<TipoMemoriaVramGetDTO>> GetAll()
        {
            IEnumerable<TipoMemoriaVramGetDTO> listaTiposVram = await _modManutencoesContext.Vramtype
                                                            .Where(t => t.Active == "Y")
                                                            .Select(t => new TipoMemoriaVramGetDTO()
                                                            {
                                                                Id = t.Id,
                                                                Descricao = t.TypeName!
                                                            }).ToListAsync();

            return listaTiposVram;
        }

        public async Task<TipoMemoriaVramGetDTO?> GetById(int tipoVramId)
        {
            TipoMemoriaVramGetDTO? tipoVram = await _modManutencoesContext.Vramtype
                                            .Where(t => t.Active == "Y" && t.Id == tipoVramId)
                                            .Select(t => new TipoMemoriaVramGetDTO
                                            {
                                                Id = t.Id,
                                                Descricao = t.TypeName!
                                            })
                                            .FirstOrDefaultAsync();

            return tipoVram;
        }

        public async Task<MensagemAoClienteDTO> Create(TipoMemoriaVramDTO tipoVram)
        {
            await _modManutencoesContext.Vramtype.AddAsync(new Vramtype
            {
                TypeName = tipoVram.Descricao,
                Active = "Y"
            });

            await _modManutencoesContext.SaveChangesAsync();

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de memória VRAM adicionado com sucesso.",
                Data = tipoVram
            };
        }

        public async Task<MensagemAoClienteDTO> Update(int id, TipoMemoriaVramDTO tipoVram)
        {
            Vramtype? tipoRamAtualizar = await _modManutencoesContext.Vramtype.FindAsync(id);

            tipoRamAtualizar!.TypeName = tipoVram.Descricao;

            await _modManutencoesContext.SaveChangesAsync();

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de memória VRAM atualizado com sucesso."
            };
        }

        public async Task<MensagemAoClienteDTO> Delete(int id)
        {
            Vramtype? tipoRamApagar = await _modManutencoesContext.Vramtype.FindAsync(id);

            tipoRamApagar!.Active = "N";

            await _modManutencoesContext.SaveChangesAsync();

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de memória VRAM excluído com sucesso."
            };
        }

        public async Task<bool> ValidarSeTipoMemoriaVramExiste(int id)
        {
            Vramtype? tipoVram = await _modManutencoesContext.Vramtype
                                .Where(t => t.Id == id && t.Active == "Y")
                                .FirstOrDefaultAsync();

            return tipoVram != null;
        }

        public async Task<bool> ValidarSeJaExisteUmTipoMemoriaVramComEstaDescricao(string descricao) //Para caso esteja criando
        {
            Vramtype? tipoVram = await _modManutencoesContext.Vramtype
                                .Where(t => t.TypeName!.ToUpper() == descricao.ToUpper() && t.Active == "Y")
                                .FirstOrDefaultAsync();

            return tipoVram == null;
        }

        public async Task<bool> ValidarSeJaExisteUmTipoMemoriaVramComEstaDescricao(int id, string descricao) //Para caso esteja atualizando
        {
            Vramtype? tipoVram = await _modManutencoesContext.Vramtype
                                .Where(t => t.TypeName!.ToUpper() == descricao.ToUpper() && t.Active == "Y" && t.Id != id)
                                .FirstOrDefaultAsync();

            return tipoVram == null;
        }
    }
}
