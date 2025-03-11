using Microsoft.EntityFrameworkCore;
using ModuloManutencoes.Contexts;
using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Dtos.MensagemDtos;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Models;
using ModuloManutencoes.Repositories.Interfaces;

namespace ModuloManutencoes.Repositories
{
    public class DispositivoRepository : ICrud<int, DispositivoDTO, DispositivoGetDTO>, IDispositivoRepository
    {
        private readonly MODMANUTENCOESContext _modManutencoesContext;

        public DispositivoRepository(MODMANUTENCOESContext modManutencoesContext)
        {
            _modManutencoesContext = modManutencoesContext;
        }

        public async Task<IEnumerable<DispositivoGetDTO>> GetAll()
        {
            IEnumerable<DispositivoGetDTO> listaDispositivos = await _modManutencoesContext.Dispositivo
                                                            .Where(d => d.Active == "Y")
                                                            .Select(d => new DispositivoGetDTO
                                                            {
                                                                Id = d.Id,
                                                                Tipo = d.DispType,
                                                                Nome = d.DispName,
                                                                Cpu = d.Cpu,
                                                                Gpu = d.Gpu,
                                                                PlacaMae = d.Mb,
                                                                Fonte = d.Psu,
                                                                Armazenamento = d.Storage,
                                                                RamQuantidade = d.RamQtd,
                                                                RamTipo = d.RamType,
                                                                VramQuantidade = d.VramQtd,
                                                                VramTipo = d.VramType,
                                                                Observacao = d.Note
                                                            }).ToListAsync();

            return listaDispositivos;
        }

        public async Task<DispositivoGetDTO?> GetById(int id)
        {
            DispositivoGetDTO? dispositivo = await _modManutencoesContext.Dispositivo
                                                            .Where(d => d.Active == "Y" && d.Id == id)
                                                            .Select(d => new DispositivoGetDTO
                                                            {
                                                                Id = d.Id,
                                                                Tipo = d.DispType,
                                                                Nome = d.DispName,
                                                                Cpu = d.Cpu,
                                                                Gpu = d.Gpu,
                                                                PlacaMae = d.Mb,
                                                                Fonte = d.Psu,
                                                                Armazenamento = d.Storage,
                                                                RamQuantidade = d.RamQtd,
                                                                RamTipo = d.RamType,
                                                                VramQuantidade = d.VramQtd,
                                                                VramTipo = d.VramType,
                                                                Observacao = d.Note
                                                            }).FirstOrDefaultAsync();

            return dispositivo;
        }

        public async Task<MensagemAoClienteDTO> Create(DispositivoDTO dispositivo)
        {
            await _modManutencoesContext.Dispositivo.AddAsync(new Dispositivo
            {
                DispType = dispositivo.Tipo,
                DispName = dispositivo.Nome,
                Cpu = dispositivo.Cpu,
                Gpu = dispositivo.Gpu,
                Mb = dispositivo.PlacaMae,
                Psu = dispositivo.Fonte,
                Storage = dispositivo.Armazenamento,
                RamQtd = dispositivo.RamQuantidade,
                RamType = dispositivo.RamTipo,
                VramQtd = dispositivo.VramQuantidade,
                VramType = dispositivo.VramTipo,
                Note = dispositivo.Observacao,
                Active = "Y"
            });

            await _modManutencoesContext.SaveChangesAsync();

            return new MensagemAoClienteDTO
            {
                Mensagem = "Dispositivo adicionado com sucesso.",
                Data = dispositivo
            };
        }

        public async Task<MensagemAoClienteDTO> Update(int id, DispositivoDTO dispositivo)
        {
            Dispositivo? dispositivoAtualizar = await _modManutencoesContext.Dispositivo.FindAsync(id);

            dispositivoAtualizar!.DispType = dispositivo.Tipo;
            dispositivoAtualizar.DispName = dispositivo.Nome;
            dispositivoAtualizar.Cpu = dispositivo.Cpu;
            dispositivoAtualizar.Gpu = dispositivo.Gpu;
            dispositivoAtualizar.Mb = dispositivo.PlacaMae;
            dispositivoAtualizar.Psu = dispositivo.Fonte;
            dispositivoAtualizar.Storage = dispositivo.Armazenamento;
            dispositivoAtualizar.RamQtd = dispositivo.RamQuantidade;
            dispositivoAtualizar.RamType = dispositivo.RamTipo;
            dispositivoAtualizar.VramQtd = dispositivo.VramQuantidade;
            dispositivoAtualizar.VramType = dispositivo.VramTipo;
            dispositivoAtualizar.Note = dispositivo.Observacao;

            await _modManutencoesContext.SaveChangesAsync();

            return new MensagemAoClienteDTO
            {
                Mensagem = "Dispositivo atualizado com sucesso."
            };
        }

        public async Task<MensagemAoClienteDTO> Delete(int id)
        {
            Dispositivo? dispositivoApagar = await _modManutencoesContext.Dispositivo.FindAsync(id);

            dispositivoApagar!.Active = "N";

            await _modManutencoesContext.SaveChangesAsync();

            return new MensagemAoClienteDTO
            {
                Mensagem = "Dispositivo excluído com sucesso."
            };
        }

        public async Task<bool> ValidarSeJaExisteDispositivoComEsteNome(string nome) //Para adicionar
        {
            bool validar = await _modManutencoesContext.Dispositivo
                                    .Where(d => d.Active == "Y" && d.DispName == nome)
                                    .AnyAsync();

            return !validar;
        }

        public async Task<bool> ValidarSeJaExisteDispositivoComEsteNome(int id, string nome) //Para atualizar
        {
            bool validar = await _modManutencoesContext.Dispositivo
                                    .Where(d => d.Active == "Y" && d.DispName == nome && d.Id != id)
                                    .AnyAsync();

            return validar;
        }

        public async Task<bool> ValidarSeDispositivoExiste(int id)
        {
            bool validar = await _modManutencoesContext.Dispositivo
                                    .Where(d => d.Active == "Y" && d.Id == id)
                                    .AnyAsync();

            return validar;
        }

        public async Task<bool> ValidarSeTipoDispositivoExiste(int id)
        {
            bool validar = await _modManutencoesContext.Disptype
                                    .Where(t => t.Active == "Y" && t.Id == id)
                                    .AnyAsync();

            return validar;
        }

        public async Task<bool> ValidarSeTipoRamExiste(int? id)
        {
            bool validar = await _modManutencoesContext.Ramtype
                                .Where(t => t.Active == "Y" && t.Id == id)
                                .AnyAsync();

            return validar;
        }

        public async Task<bool> ValidarSeTipoVramExiste(int? id)
        {
            bool validar = await _modManutencoesContext.Vramtype
                                 .Where(t => t.Active == "Y" && t.Id == id)
                                 .AnyAsync();

            return validar;
        }
    }
}
