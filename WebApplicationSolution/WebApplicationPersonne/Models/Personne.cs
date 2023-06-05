using System;
using System.Collections.Generic;

namespace WebApplicationPersonne.Models
{
    public partial class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public DateTime DateDeNaissance { get; set; }
        public string? Utilisateur { get; set; }
    }
}
