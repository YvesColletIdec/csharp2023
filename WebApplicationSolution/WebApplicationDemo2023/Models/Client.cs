using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDemo2023.Models
{
    public partial class Client
    {
        public Client()
        {
            Factures = new HashSet<Facture>();
        }
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        [DisplayName("Prénom")]
        public string Prenom { get; set; } = null!;
        public string Adresse { get; set; } = null!;
        public string Npa { get; set; } = null!;
        [DisplayName("Localité")]
        public string Localite { get; set; } = null!;

        public virtual ICollection<Facture> Factures { get; set; }
    }
}
