using System;
using System.Collections.Generic;

namespace EFCore.entities
{
    public partial class Article
    {
        public Article()
        {
            LigneFactures = new HashSet<LigneFacture>();
        }

        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public string? Designation { get; set; }
        public decimal Prix { get; set; }
        public int? CategorieId { get; set; }

        public virtual Categorie? Categorie { get; set; }
        public virtual ICollection<LigneFacture> LigneFactures { get; set; }
    }
}
