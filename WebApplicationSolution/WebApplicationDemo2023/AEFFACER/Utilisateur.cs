using System;
using System.Collections.Generic;

namespace WebApplicationDemo2023.AEFFACER
{
    public partial class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string MotDePasse { get; set; } = null!;
        public string Role { get; set; } = null!;
        public bool EstActif { get; set; }
    }
}
