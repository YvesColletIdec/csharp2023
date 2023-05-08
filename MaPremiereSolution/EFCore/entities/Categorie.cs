using System;
using System.Collections.Generic;

namespace EFCore.entities
{
    public partial class Categorie
    {
        public Categorie()
        {
            Articles = new HashSet<Article>();
        }

        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public bool? Estactif { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
