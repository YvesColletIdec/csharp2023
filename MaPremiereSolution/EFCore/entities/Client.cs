using System;
using System.Collections.Generic;

namespace EFCore.entities
{
    public partial class Client
    {
        public Client()
        {
            Factures = new HashSet<Facture>();
        }

        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public string Adresse { get; set; } = null!;
        public string Npa { get; set; } = null!;
        public string Localite { get; set; } = null!;

        public virtual ICollection<Facture> Factures { get; set; }
    }
}
