using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.EntityClient;

namespace InventoryEDMConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with ADO.NET EF *****\n");
            //AddNewRecord();
            PrintAllInventory();
            Console.ReadLine();
        }

        private static void AddNewRecord()
        {
            // Add record to the Inventory table of the AutoLot
            // database.
            using (AutoLotEntities context = new AutoLotEntities())
            {
                try
                {
                    // Hard-code data for a new record, for testing.
                    context.Cars.AddObject(new Car()
                    {
                        CarID = 2222,
                        Make = "Yugo",
                        Color = "Brown"
                    });
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static void PrintAllInventory()
        {
            // Select all items from the Inventory table of AutoLot,
            // and print out the data using our custom ToString()
            // of the Car entity class.
            using (AutoLotEntities context = new AutoLotEntities())
            {
                foreach (Car c in context.Cars)
                    Console.WriteLine(c);
            }
        }

        private static void RemoveRecord()
        {
            // Find a car to delete by primary key.
            using (AutoLotEntities context = new AutoLotEntities())
            {
                var carToDelete =
                  (from c in context.Cars where c.CarID == 2222 select c).FirstOrDefault();

                if (carToDelete != null)
                {
                    context.DeleteObject(carToDelete);
                    context.SaveChanges();
                }
            }
        }

        private static void UpdateRecord()
        {
            // Find a car to delete by primary key.
            using (AutoLotEntities context = new AutoLotEntities())
            {
                // Define a key for the entity we are looking for.
                EntityKey key = new EntityKey("AutoLotEntities.Cars", "CarID", 2222);

                // Grab the car, change it, save!
                Car carToUpdate = (Car)context.GetObjectByKey(key);
                if (carToUpdate != null)
                {
                    carToUpdate.Color = "Blue";
                    context.SaveChanges();
                }
            }
        }

        private static void FunWithLINQQueries()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                // Get all data from the Inventory table.
                // Could also write:
                // var allData = (from item in context.Cars select item).ToArray();
                var allData = context.Cars.ToArray();

                // Get a projection of new data.
                var colorsMakes = from item in allData select new { item.Color, item.Make };

                // Get only items where CarID < 1000.
                var idsLessThan1000 = from item in allData where
                    item.CarID < 1000 select item;
            }
        }

        private static void FunWithEntitySQL()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                // Build a string containing Entity SQL syntax.
                string query = "SELECT VALUE car FROM AutoLotEntities.Cars " +
                               "AS car WHERE car.Color='black'";

                // Now build an ObjectQuery<T> based on the string.
                var blackCars = context.CreateQuery<Car>(query);
                foreach (var item in blackCars)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void FunWithEntityDataReader()
        {
            // Make a connection object, based on our *.config file.
            using (EntityConnection cn = new EntityConnection("name=AutoLotEntities"))
            {
                cn.Open();

                // Now build an Entity SQL query.
                string query = "SELECT VALUE car FROM AutoLotEntities.Cars AS car";

                // Create a command object.
                using (EntityCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = query;

                    // Finally, get the data reader and process records.
                    using (EntityDataReader dr =
                           cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine("***** RECORD *****");
                            Console.WriteLine("ID: {0}", dr["CarID"]);
                            Console.WriteLine("Make: {0}", dr["Make"]);
                            Console.WriteLine("Color: {0}", dr["Color"]);
                            Console.WriteLine("Pet Name: {0}", dr["CarNickname"]);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

    }
}
