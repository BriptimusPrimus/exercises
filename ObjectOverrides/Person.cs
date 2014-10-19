using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    // Remember! Person extends Object.
    class Person 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string fName, string lName, int personAge)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
        }
        public Person() { }

        public override string ToString()
        {
            string myState;
            myState = string.Format("[First Name: {0}; Last Name: {1}; Age: {2}]",
              FirstName, LastName, Age);
            return myState;
        }

        public override bool Equals(object obj)
        {
            // No need to cast "obj" to a Person anymore,
            // as everything has a ToString() method.
            return obj.ToString() == this.ToString();
        }

        //// Assume we have an SSN property as so.
        //// Return a hash code based on a point of unique string data.
        //public override int GetHashCode()
        //{
        //    return SSN.GetHashCode();
        //}

        // Return a hash code based on the person's ToString() value.
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
