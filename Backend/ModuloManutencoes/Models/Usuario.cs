using System;
using System.Collections.Generic;

namespace ModuloManutencoes.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Manutencos = new HashSet<Manutenco>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string? Mail2 { get; set; }
        public string Password { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; } = null!;
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string Active { get; set; } = null!;
        public string Admin { get; set; } = null!;
        public string SuperAdmin { get; set; } = null!;

        public virtual ICollection<Manutenco> Manutencos { get; set; }
    }
}
