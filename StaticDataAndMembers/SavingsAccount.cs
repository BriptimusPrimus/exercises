using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    // A simple savings account class.
    class SavingsAccount
    {
        // Instance-level data.
        public double currBalance;

        // A static point of data.
        public static double currInterestRate;

        // Notice that our constructor is setting
        // the static currInterestRate value.
        public SavingsAccount(double balance)
        {
            currBalance = balance;
        }

        // A static constructor!
        static SavingsAccount()
        {
            Console.WriteLine("In static ctor!");
            currInterestRate = 0.04;
        }

        // Static members to get/set interest rate.
        public static void SetInterestRate(double newRate)
        { currInterestRate = newRate; }

        public static double GetInterestRate()
        { return currInterestRate; }

    }
}
