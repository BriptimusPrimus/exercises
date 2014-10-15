using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotDAL;
using AutoLotDAL.AutoLotDataSetTableAdapters;

namespace _06StronglyTypedDataSetConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Strongly Typed DataSets *****\n");

            AutoLotDataSet.InventoryDataTable table =
              new AutoLotDataSet.InventoryDataTable();

            InventoryTableAdapter dAdapt = new InventoryTableAdapter();
            dAdapt.Fill(table);

            // Add rows, update, and reprint.
            AddRecords(table, dAdapt);
            table.Clear();
            dAdapt.Fill(table);
            PrintInventory(table);
            Console.ReadLine();

            RemoveRecords(table, dAdapt);
            dAdapt.Fill(table);
            PrintInventory(table);
            Console.ReadLine();

            CallStoredProc();
            Console.ReadLine();
        }

        static void PrintInventory(AutoLotDataSet.InventoryDataTable dt)
        {
            // Print out the column names.
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.Write(dt.Columns[curCol].ColumnName + "\t");
            }
            Console.WriteLine("\n----------------------------------");

            // Print the data.
            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void AddRecords(AutoLotDataSet.InventoryDataTable tb,
          InventoryTableAdapter dAdapt)
        {
            try
            {
                // Get a new strongly typed row from the table.
                AutoLotDataSet.InventoryRow newRow = tb.NewInventoryRow();

                // Fill row with some sample data.
                newRow.CarID = 999;
                newRow.Color = "Purple";
                newRow.Make = "BMW";
                newRow.PetName = "Saku";

                // Insert the new row.
                tb.AddInventoryRow(newRow);

                // Add one more row, using overloaded Add method.
                tb.AddInventoryRow(889, "Yugo", "Green", "Zippy");

                // Update database.
                dAdapt.Update(tb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RemoveRecords(AutoLotDataSet.InventoryDataTable tb,
          InventoryTableAdapter dAdapt)
        {
            try
            {
                AutoLotDataSet.InventoryRow rowToDelete = tb.FindByCarID(999);
                dAdapt.Delete(rowToDelete.CarID, rowToDelete.Make,
                              rowToDelete.Color, rowToDelete.PetName);
                rowToDelete = tb.FindByCarID(889);
                dAdapt.Delete(rowToDelete.CarID, rowToDelete.Make,
                              rowToDelete.Color, rowToDelete.PetName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CallStoredProc()
        {
            try
            {
                QueriesTableAdapter q = new QueriesTableAdapter();
                Console.Write("Enter ID of car to look up: ");
                string carID = Console.ReadLine();
                string carName = "";
                q.GetPetName(int.Parse(carID), ref carName);
                Console.WriteLine("CarID {0} has the name of {1}", carID, carName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
