using System;
using System.Collections.Generic;

namespace EFCore.entities
{
    public partial class Client
    {
        public string Prenom_Nom { get { return $"{Prenom} {Nom}"; } }
    }
}
