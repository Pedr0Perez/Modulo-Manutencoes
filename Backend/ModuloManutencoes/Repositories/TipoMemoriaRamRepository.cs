using Microsoft.EntityFrameworkCore;
using ModuloManutencoes.Contexts;
using ModuloManutencoes.Dtos.MemoriaDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Models;
using ModuloManutencoes.Repositories.Interfaces;

namespace ModuloManutencoes.Repositories
{
    public class TipoMemoriaRamRepository : ICrud<int, TipoMemoriaRamDTO>, ITipoMemoriaRamRepository
    {
        private readonly MODMANUTENCOESContext _modManutencoesContext;

        public TipoMemoriaRamRepository(MODMANUTENCOESContext modManutencoesContext)
        {
            _modManutencoesContext = modManutencoesContext;
        }

        public async Task<IEnumerable<TipoMemoriaRamDTO>> GetAll()
        {
            IEnumerable<TipoMemoriaRamDTO> listaTiposRam = await _modManutencoesContext.Ramtype
                                                            .Where(t => t.Active == "Y")
                                                            .Select(t => new TipoMemoriaRamDTO()
                                                            {
                                                                Id = t.Id,
                                                                Descricao = t.TypeName!
                                                            }).ToListAsync();

            return listaTiposRam;
        }

        public async Task<TipoMemoriaRamDTO?> GetById(int tipoRamId)
        {
            TipoMemoriaRamDTO? tipoRam = await _modManutencoesContext.Ramtype
                                            .Where(t => t.Active == "Y" && t.Id == tipoRamId)
                                            .Select(t => new TipoMemoriaRamDTO
                                            {
                                                Id = t.Id,
                                                Descricao = t.TypeName!
                                            })
                                            .FirstOrDefaultAsync();

            return tipoRam;
        }

        public async Task<MensagemAoClienteDTO> Create(TipoMemoriaRamDTO tipoRam)
        {
            await _modManutencoesContext.Ramtype.AddAsync(new Ramtype
            {
                TypeName = tipoRam.Descricao,
                Active = "Y"
            });

            await _modManutencoesContext.SaveChangesAsync();

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de memória RAM adicionado com sucesso.",
                Data = tipoRam
            };
        }

        public async Task<MensagemAoClienteDTO> Update(int id, TipoMemoriaRamDTO tipoRam)
        {
            Ramtype? tipoRamAtualizar = await _modManutencoesContext.Ramtype.FindAsync(id);

            tipoRamAtualizar!.TypeName = tipoRam.Descricao;

            await _modManutencoesContext.SaveChangesAsync();

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de memória RAM atualizado com sucesso."
            };
        }

        public async Task<MensagemAoClienteDTO> Delete(int id)
        {
            Ramtype? tipoRamApagar = await _modManutencoesContext.Ramtype.FindAsync(id);

            tipoRamApagar!.Active = "N";

            await _modManutencoesContext.SaveChangesAsync();

            return new MensagemAoClienteDTO
            {
                Mensagem = "Tipo de memória RAM excluído com sucesso."
            };
        }

        public async Task<bool> ValidarSeTipoMemoriaRamExiste(int id)
        {
            Ramtype? tipoRam = await _modManutencoesContext.Ramtype
                                .Where(t => t.Id == id && t.Active == "Y")
                                .FirstOrDefaultAsync();

            return tipoRam != null;
        }

        public async Task<bool> ValidarSeJaExisteUmTipoMemoriaRamComEstaDescricao(string descricao) //Para caso esteja criando
        {
            Ramtype? tipoRam = await _modManutencoesContext.Ramtype
                                .Where(t => t.TypeName!.ToUpper() == descricao.ToUpper() && t.Active == "Y")
                                .FirstOrDefaultAsync();

            return tipoRam == null;
        }

        public async Task<bool> ValidarSeJaExisteUmTipoMemoriaRamComEstaDescricao(int id, string descricao) //Para caso esteja atualizando
        {
            Ramtype? tipoRam = await _modManutencoesContext.Ramtype
                                .Where(t => t.TypeName!.ToUpper() == descricao.ToUpper() && t.Active == "Y" && t.Id != id)
                                .FirstOrDefaultAsync();

            return tipoRam == null;
        }
    }
}
