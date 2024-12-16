using System;
using System.Collections.Generic;

namespace ModuloManutencoes.Models
{
    public partial class Disptype
    {
        public Disptype()
        {
            Dispositivos = new HashSet<Dispositivo>();
        }

        public int Id { get; set; }
        public string? TypeDisp { get; set; }
        public string Active { get; set; } = null!;

        public virtual ICollection<Dispositivo> Dispositivos { get; set; }
    }
}
