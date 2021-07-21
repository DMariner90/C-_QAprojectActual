using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sales_Report_APP
{
    class Program

    {
        //MySqlConnection con;
       // MySqlCommand cmd;

        static void Main(string[] args)
        {
            // do
            SQLcommands SQL = new SQLcommands();        
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1- Data Entry");
                Console.WriteLine("2- Reports");
                Console.WriteLine("3- Exit the console");
                int choice = Int32.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    //create a data entry within sql sales table
                    Console.WriteLine("Enter Product Name");
                    string Product_Name = Console.ReadLine();
                    Console.WriteLine("Enter Quantity");
                    int Quantity = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Price");
                    float Price = float.Parse(Console.ReadLine());
                    SQL.dataStore(Product_Name, Quantity, Price);
                }

            if (choice == 2)
            {
                Console.WriteLine("1- List of products sold in specifc year");
                Console.WriteLine("2- List of products sold in a specfic month and specific year");
                Console.WriteLine("3- Total sales in specifc year");
                Console.WriteLine("4- Total sales of a specific month and year");
                int selection = Int32.Parse(Console.ReadLine());

                if (selection == 1)
                {
                    // report list of products sold in specific year
                    Console.WriteLine("Enter year (YYYY)");
                    int Product_Year = Int32.Parse(Console.ReadLine());
                    SQL.ProductListSpecificYear(Product_Year);
                }

                if (selection == 2)
                {
                    //list of products sold in specific month
                    Console.WriteLine("Enter month (MM)");
                    int Product_Month = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Year (YYYY)");
                    int Product_Year = Int32.Parse(Console.ReadLine());
                    SQL.ProductsListSpecificMonth(Product_Month, Product_Year);
                }

                if (selection == 3)
                {
                    // total sales for specific year;
                    Console.WriteLine("Enter year (YYYY)");
                    int TotalSales_Year = Int32.Parse(Console.ReadLine());
                    SQL.TotalSalesSpecificYear(TotalSales_Year);
                }

                if (selection == 4)
                {
                    // total sales in specific month in specific year
                    Console.WriteLine("Enter month (MM)");
                    int TotalSales_Month = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter year (YYYY)");
                    int TotalSales_Year = Int32.Parse(Console.ReadLine());
                    SQL.TotalSalesSpecificMonthYear(TotalSales_Month, TotalSales_Year);
                }

            }

            if (choice == 3)
                {
                    Environment.Exit(0);
                }

           // } while (true);
        }
    }
}




