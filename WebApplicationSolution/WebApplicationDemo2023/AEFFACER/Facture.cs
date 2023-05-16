﻿using System;
using System.Collections.Generic;

namespace WebApplicationDemo2023.AEFFACER
{
    public partial class Facture
    {
        public Facture()
        {
            LigneFactures = new HashSet<LigneFacture>();
        }

        public int Id { get; set; }
        public DateTime DateFacture { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual ICollection<LigneFacture> LigneFactures { get; set; }
    }
}
