using System;
using System.Collections.Generic;

namespace TestEfCore
{
    public partial class Facture
    {
        public int Id { get; set; }
        public DateTime DateFacture { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
    }
}
