using Microsoft.EntityFrameworkCore;
using ModuloManutencoes.Contexts;
using ModuloManutencoes.Dtos.MemoriaDtos;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Models;
using ModuloManutencoes.Repositories.Interfaces;

namespace ModuloManutencoes.Repositories
{
    public class TipoMemoriaRamRepository : ICrud<int, TipoMemoriaRamDTO, TipoMemoriaRamGetDTO>, ITipoMemoriaRamRepository
    {
        private readonly MODMANUTENCOESContext _modManutencoesContext;

        public TipoMemoriaRamRepository(MODMANUTENCOESContext modManutencoesContext)
        {
            _modManutencoesContext = modManutencoesContext;
        }

        public async Task<IEnumerable<TipoMemoriaRamGetDTO>> GetAll()
        {
            IEnumerable<TipoMemoriaRamGetDTO> listaTiposRam = await _modManutencoesContext.Ramtype
                                                            .Where(t => t.Active == "Y")
                                                            .Select(t => new TipoMemoriaRamGetDTO()
                                                            {
                                                                Id = t.Id,
                                                                Descricao = t.TypeName!
                                                            }).ToListAsync();

            return listaTiposRam;
        }

        public async Task<TipoMemoriaRamGetDTO?> GetById(int tipoRamId)
        {
            TipoMemoriaRamGetDTO? tipoRam = await _modManutencoesContext.Ramtype
                                            .Where(t => t.Active == "Y" && t.Id == tipoRamId)
                                            .Select(t => new TipoMemoriaRamGetDTO
                                            {
                                                Id = t.Id,
                                                Descricao = t.TypeName!
                                            })
                                            .FirstOrDefaultAsync();

            return tipoRam;
        }

        public async Task Create(TipoMemoriaRamDTO tipoRam)
        {
            await _modManutencoesContext.Ramtype.AddAsync(new Ramtype
            {
                TypeName = tipoRam.Descricao,
                Active = "Y"
            });

            await _modManutencoesContext.SaveChangesAsync();
        }

        public async Task Update(int id, TipoMemoriaRamDTO tipoRam)
        {
            Ramtype? tipoRamAtualizar = await _modManutencoesContext.Ramtype.FindAsync(id);

            tipoRamAtualizar!.TypeName = tipoRam.Descricao;

            await _modManutencoesContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Ramtype? tipoRamApagar = await _modManutencoesContext.Ramtype.FindAsync(id);

            tipoRamApagar!.Active = "N";

            await _modManutencoesContext.SaveChangesAsync();
        }

        public async Task<bool> ValidarSeTipoMemoriaRamExiste(int id)
        {
            bool validar = await _modManutencoesContext.Ramtype
                                .Where(t => t.Active == "Y" && t.Id == id)
                                .AnyAsync();

            return validar;
        }

        public async Task<bool> ValidarSeJaExisteUmTipoMemoriaRamComEstaDescricao(string descricao) //Para caso esteja criando
        {
            bool tipoRam = await _modManutencoesContext.Ramtype
                                .Where(t => t.TypeName!.ToUpper() == descricao.ToUpper() && t.Active == "Y")
                                .AnyAsync();

            return !tipoRam;
        }

        public async Task<bool> ValidarSeJaExisteUmTipoMemoriaRamComEstaDescricao(int id, string descricao) //Para caso esteja atualizando
        {
            bool tipoRam = await _modManutencoesContext.Ramtype
                                .Where(t => t.TypeName!.ToUpper() == descricao.ToUpper() && t.Active == "Y" && t.Id != id)
                                .AnyAsync();

            return !tipoRam;
        }
    }
}
