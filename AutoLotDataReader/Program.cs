using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Data Readers *****\n");

            // Create a connection string via the builder object.
            SqlConnectionStringBuilder cnStrBuilder =
              new SqlConnectionStringBuilder();
            cnStrBuilder.InitialCatalog = "AutoLot";
            cnStrBuilder.DataSource = @"(localdb)\v11.0";
            cnStrBuilder.ConnectTimeout = 30;
            cnStrBuilder.IntegratedSecurity = true;

            // Create and open a connection.
            using (SqlConnection cn = new SqlConnection())
            {
                //cn.ConnectionString =
                //  @"Data Source=(localdb)\v11.0;Initial Catalog=AutoLot;Integrated Security=True;Connect Timeout=30";
                cn.ConnectionString = cnStrBuilder.ConnectionString;
                cn.Open();

                // New helper function (see below).
                ShowConnectionStatus(cn);

                // Create a SQL command object.
                string strSQL = "Select * From Inventory";
                SqlCommand myCommand = new SqlCommand(strSQL, cn);

                // Obtain a data reader a la ExecuteReader().
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    // Loop over the results.
                    while (myDataReader.Read())
                    {
                        Console.WriteLine("-> Make: {0}, PetName: {1}, Color: {2}.",
                                          myDataReader["Make"].ToString(),
                                          myDataReader["PetName"].ToString(),
                                          myDataReader["Color"].ToString());
                    }
                    myDataReader.Close();
                }
            }
            Console.ReadLine();
        }

        static void ShowConnectionStatus(SqlConnection cn)
        {
            // Show various stats about current connection object.
            Console.WriteLine("***** Info about your connection *****");
            Console.WriteLine("Database location: {0}", cn.DataSource);
            Console.WriteLine("Database name: {0}", cn.Database);
            Console.WriteLine("Timeout: {0}", cn.ConnectionTimeout);
            Console.WriteLine("Connection state: {0}\n", cn.State.ToString());
        }

    }
}
