using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace ComparableCar
{
    // Garage contains a set of Car objects.
    public class Garage : IEnumerable
    {
        // System.Array already implements IEnumerator!
        private Car[] carArray = new Car[4];

        public Garage()
        {
            carArray[0] = new Car("FeeFee", 200, 1);
            carArray[1] = new Car("Clunker", 90, 1);
            carArray[2] = new Car("Zippy", 30, 1);
            carArray[3] = new Car("Fred", 30, 1);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Return the array object's IEnumerator.
            return carArray.GetEnumerator();
        }
    }
}
