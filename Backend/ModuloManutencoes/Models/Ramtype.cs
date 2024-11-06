using System;
using System.Collections.Generic;

namespace ModuloManutencoes.Models
{
    public partial class Ramtype
    {
        public Ramtype()
        {
            Dispositivos = new HashSet<Dispositivo>();
        }

        public int Id { get; set; }
        public string? TypeName { get; set; }
        public string Active { get; set; } = null!;

        public virtual ICollection<Dispositivo> Dispositivos { get; set; }
    }
}
