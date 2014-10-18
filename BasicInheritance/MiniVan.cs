using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInheritance
{
    // MiniVan derives from Car.
    class MiniVan : Car
    {
        public void TestMethod()
        {
            // OK! Can access public members
            // of a parent within a derived type.
            Speed = 10;

            // Error! Cannot access private
            // members of parent within a derived type.
            // currSpeed = 10;
        }
    } 
}
