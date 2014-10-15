using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotConnectedLayer;

namespace _04AdoNetTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Transaction Example *****\n");

            // A simple way to allow the transaction to succeed or not.
            bool throwEx = true;
            string userAnswer = string.Empty;

            Console.Write("Do you want to throw an exception (Y or N): ");
            userAnswer = Console.ReadLine();
            if (userAnswer.ToLower() == "n")
            {
                throwEx = false;
            }

            InventoryDAL dal = new InventoryDAL();
            dal.OpenConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=AutoLot;Integrated Security=True");

            // Process customer 333.
            dal.ProcessCreditRisk(throwEx, 333);

            Console.WriteLine("Check CreditRisk table for results");
            Console.ReadLine();
        }
    }
}
