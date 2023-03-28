using System;
using System.Collections.Generic;

namespace TestEfCore
{
    public partial class Article2
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public decimal Prix { get; set; }
    }
}
