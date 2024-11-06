using System;
using System.Collections.Generic;

namespace ModuloManutencoes.Models
{
    public partial class Manutenco
    {
        public int Id { get; set; }
        public int DispId { get; set; }
        public int UserId { get; set; }
        public string ItEnded { get; set; } = null!;
        public DateTime DateCreate { get; set; }
        public DateTime? DateEnded { get; set; }
        public string? Description { get; set; }

        public virtual Dispositivo Disp { get; set; } = null!;
        public virtual Usuario User { get; set; } = null!;
    }
}
