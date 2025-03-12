using Microsoft.EntityFrameworkCore;
using ModuloManutencoes.Contexts;
using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Models;
using ModuloManutencoes.Repositories.Interfaces;

namespace ModuloManutencoes.Repositories
{
    public class TipoDispositivoRepository : ICrud<int, TipoDispositivoDTO, TipoDispositivoGetDTO>, ITipoDispositivoRepository
    {
        private readonly MODMANUTENCOESContext _modManutencoesContext;

        public TipoDispositivoRepository(MODMANUTENCOESContext modManutencoesContext)
        {
            _modManutencoesContext = modManutencoesContext;
        }

        public async Task<IEnumerable<TipoDispositivoGetDTO>> GetAll()
        {
            IEnumerable<TipoDispositivoGetDTO> listaTipoDispositivo = await _modManutencoesContext.Disptype
                                                                    .Where(d => d.Active == "Y")
                                                                    .Select(d => new TipoDispositivoGetDTO
                                                                    {
                                                                        Id = d.Id,
                                                                        Descricao = d.TypeDisp!
                                                                    }).ToListAsync();

            return listaTipoDispositivo;
        }

        public async Task<TipoDispositivoGetDTO?> GetById(int tipoDispId)
        {
            TipoDispositivoGetDTO? dispositivo = await _modManutencoesContext.Disptype
                                                                    .Where(d => d.Active == "Y" && d.Id == tipoDispId)
                                                                    .Select(d => new TipoDispositivoGetDTO
                                                                    {
                                                                        Id = d.Id,
                                                                        Descricao = d.TypeDisp!
                                                                    }).FirstOrDefaultAsync();

            return dispositivo;
        }

        public async Task Create(TipoDispositivoDTO tipoDispositivo)
        {
            await _modManutencoesContext.Disptype.AddAsync(new Disptype
            {
                TypeDisp = tipoDispositivo.Descricao,
                Active = "Y"
            });

            await _modManutencoesContext.SaveChangesAsync();
        }

        public async Task Update(int id, TipoDispositivoDTO tipoDispositivo)
        {
            Disptype? tipoDispositivoAtualizar = await _modManutencoesContext.Disptype.FindAsync(id);

            tipoDispositivoAtualizar!.TypeDisp = tipoDispositivo.Descricao;
            await _modManutencoesContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Disptype? tipoDispositivoAtualizar = await _modManutencoesContext.Disptype.FindAsync(id);

            tipoDispositivoAtualizar!.Active = "N";
            await _modManutencoesContext.SaveChangesAsync();
        }

        public async Task<bool> ValidarSeTipoDispositivoExiste(int id)
        {
            Disptype? tipoDispositivo = await _modManutencoesContext.Disptype
                                                .Where(d => d.Active == "Y" && d.Id == id)
                                                .FirstOrDefaultAsync();

            return tipoDispositivo != null;
        }
    }
}
