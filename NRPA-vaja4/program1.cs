using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRPA_vaja4
{
    class program1
    {
        static void Main(string[] args)
        {
            Ulomek u1 = new Ulomek(4, 16);
            u1.Okrajsaj();
            Console.WriteLine("Ulomek u1: " + u1);
        }
    }
}
