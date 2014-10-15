using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotDAL;
using System.Data;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;

namespace _02AutoLotEDMClient
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintCustomerOrders("4");
            CallStoredProc();
            Console.ReadLine();
        }

        private static void PrintCustomerOrders(string custID)
        {
            int id = int.Parse(custID);

            using (AutoLotEntities context = new AutoLotEntities())
            {
                var carsOnOrder = from o in context.Orders
                                  where o.CustID == id
                                  select o.Inventory;
                int count = carsOnOrder.Count();
                Console.WriteLine("\nCustomer has {0} orders pending:", carsOnOrder.Count());
                foreach (var item in carsOnOrder)
                {
                    Console.WriteLine("-> {0} {1} named {2}.",
                      item.Color, item.Make, item.PetName);
                }
            }
        }

        private static void CallStoredProc()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                // Approach #1.
                ObjectParameter input = new ObjectParameter("carID", 83);
                ObjectParameter output = new ObjectParameter("petName", typeof(string));

                // Call ExecuteFunction off the context....
                var objectContext = (context as IObjectContextAdapter).ObjectContext;
                objectContext.ExecuteFunction("GetPetName", input, output);

                // Approach #2.
                // ....or use the strongly typed method on the context.
                context.GetPetName(83, output);

                Console.WriteLine("Car #83 is named {0}", output.Value);
            }
        }

    }
}
