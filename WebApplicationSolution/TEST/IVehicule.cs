using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    public interface IVehicule
    {
        string Nom { get; }
        void Demarrer();
        void Accelerer();

    }
}
