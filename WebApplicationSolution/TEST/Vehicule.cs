using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    internal class Vehicule : Object, IVehicule, IDisposable, IEnumerable<object>
    {
        public string Nom { get; }

        public void Accelerer()
        {
            Console.WriteLine("vroum");
        }

        public void Demarrer()
        {
            Console.WriteLine("stop");
        }

        public void Dispose()
        {
            Console.WriteLine();
        }

        public IEnumerator<object> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
