using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace CustomEnumeratorWithYield
{
    // Garage contains a set of Car objects.
    public class Garage
    {
        // System.Array already implements IEnumerator!
        private Car[] carArray = new Car[4];

        public Garage()
        {
            carArray[0] = new Car("FeeFee", 200);
            carArray[1] = new Car("Clunker", 90);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    // Return the array object's IEnumerator.
        //    return carArray.GetEnumerator();
        //}

        // Iterator method.
        public IEnumerator GetEnumerator()
        {
            foreach (Car c in carArray)
            {
                yield return c;
            }
        }

        public IEnumerable GetTheCars(bool ReturnRevesed)
        {
            // Return the items in reverse.
            if (ReturnRevesed)
            {
                for (int i = carArray.Length; i != 0; i--)
                {
                    yield return carArray[i - 1];
                }
            }
            else
            {
                // Return the items as placed in the array.
                foreach (Car c in carArray)
                {
                    yield return c;
                }
            }
        } 
    }
}
