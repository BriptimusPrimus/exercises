using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    // Managers need to know their number of stock options.
    class Manager : Employee
    {
        public int StockOptions { get; set; }

        public Manager(string fullName, int age, int empID,
                       float currPay, string ssn, int numbOfOpts)
            : base(fullName, age, empID, currPay, ssn)
        {
            // This property is defined by the Manager class.
            StockOptions = numbOfOpts;
        }

        // Add back the default ctor
        public Manager() {}

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Number of Stock Options: {0}", StockOptions);
        }
    }
}
