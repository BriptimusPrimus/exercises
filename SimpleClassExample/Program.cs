using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Class Types *****\n");

            // Allocate and configure a Car object.
            Car myCar = new Car();
            myCar.petName = "Henry";
            myCar.currSpeed = 10;

            // Speed up the car a few times and print out the
            // new state.
            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }

            // Make a Car called Chuck going 10 MPH.
            Car chuck = new Car();
            chuck.PrintState();

            // Make a Car called Mary going 0 MPH.
            Car mary = new Car("Mary");
            mary.PrintState();

            // Make a Car called Daisy going 75 MPH.
            Car daisy = new Car("Daisy", 75);
            daisy.PrintState();

            // Make a Motorcycle.
            Motorcycle c = new Motorcycle(5);
            c.SetDriverName("Tiny");
            c.PopAWheely();
            Console.WriteLine("Rider name is {0}", c.driverName);

            Console.ReadLine();
        }
    }
}
