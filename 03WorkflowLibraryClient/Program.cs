using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _02CheckInventoryWorkflowLib;
using System.Activities;

namespace _03WorkflowLibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Inventory Look up ****");

            // Get user preferences.
            Console.Write("Enter Color: ");
            string color = Console.ReadLine();
            Console.Write("Enter Make: ");
            string make = Console.ReadLine();

            // Package up data for workflow.
            Dictionary<string, object> wfArgs = new Dictionary<string, object>()
            {
                {"RequestedColor", color},
                {"RequestedMake", make}
            };

            try
            {
                // Send data to workflow!
                WorkflowInvoker.Invoke(new CheckInventory(), wfArgs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
