using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDemo2023.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        [DisplayName("N°")]
        public int Id { get; set; }
        [DisplayName("Nom de la catégorie")]
        [Required(ErrorMessage = "Le nom de la catégorie est obligatoire!!!!!!!")]
        [MaxLength(100)]
        [MinLength(5)]
        public string Nom { get; set; } = null!;
        [DisplayName("Actif?")]
        public bool Estactif { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
