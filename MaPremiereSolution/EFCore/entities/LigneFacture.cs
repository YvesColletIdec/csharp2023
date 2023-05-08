﻿using System;
using System.Collections.Generic;

namespace EFCore.entities
{
    public partial class LigneFacture
    {
        public int Id { get; set; }
        public int FactureId { get; set; }
        public int ArticleId { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }

        public virtual Article Article { get; set; } = null!;
        public virtual Facture Facture { get; set; } = null!;
    }
}
