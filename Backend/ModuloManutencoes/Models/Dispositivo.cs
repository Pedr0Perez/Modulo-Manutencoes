using System;
using System.Collections.Generic;

namespace ModuloManutencoes.Models
{
    public partial class Dispositivo
    {
        public Dispositivo()
        {
            Manutencos = new HashSet<Manutenco>();
        }

        public int Id { get; set; }
        public int DispType { get; set; }
        public string DispName { get; set; } = null!;
        public string? Cpu { get; set; }
        public string? Gpu { get; set; }
        public string? Mb { get; set; }
        public string? Psu { get; set; }
        public int? Storage { get; set; }
        public int? RamQtd { get; set; }
        public int? RamType { get; set; }
        public int? VramQtd { get; set; }
        public int? VramType { get; set; }
        public string? Note { get; set; }
        public string Active { get; set; } = null!;

        public virtual Disptype DispTypeNavigation { get; set; } = null!;
        public virtual Ramtype? RamTypeNavigation { get; set; }
        public virtual Vramtype? VramTypeNavigation { get; set; }
        public virtual ICollection<Manutenco> Manutencos { get; set; }
    }
}
