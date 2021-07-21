using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sales_Report_APP
{
    class SQLcommands
    {
        MySqlConnection connect;
        MySqlCommand cmd;

        public SQLcommands()
        {

            string connectionstring = "server=localhost;user=root;password=root;database=qa_project";
            connect = new MySqlConnection(connectionstring);
            connect.Open();
            cmd = new MySqlCommand();
            cmd.Connection = connect;

        }

        /*
        public void createDataEntry( string Product_Name, int Quantity, float Price)
        {

            //cmd.CommandText = $"insert into sales values('Sales_ID','{Product_Name}','{Quantity}','{Price}','now()')";
            //cmd.ExecuteNonQuery();
            //MySqlDataReader data = cmd.ExecuteReader();
            //string newDataEntry = Product_Name + Quantity + Price;
            //data.Close();

            //Console.ReadLine();
            //data.Close();
           
        }
        */

        public void dataStore( string Product_Name, int Quantity, float Price)
        {
            cmd.CommandText = $"insert into sales values(Sale_ID,'{Product_Name}','{Quantity}','{Price}',now())";
            cmd.ExecuteNonQuery();

        }

        public void ProductListSpecificYear(int Product_Year)
        {
            string row = "";
            cmd.CommandText = $"Select * from Sales where year (Sales_Date)= '{Product_Year}'";
            cmd.ExecuteNonQuery();
            MySqlDataReader data = cmd.ExecuteReader();
            while(data.Read())
            {
                for (int i = 0; i < data.FieldCount; i++)
                {
                    row += data.GetString(i) +"   ";
                }
                Console.WriteLine(row);
                row = "";
            }
            //ShowRecords(sqlSelect);
            
        }

        public void ProductsListSpecificMonth(int Product_Month, int Product_Year)
        {
            string row = "";
            cmd.CommandText = $"Select * from Sales where year (Sales_Date)= '{Product_Year}' and month (Sales_Date)='{Product_Month}'";
            cmd.ExecuteNonQuery();
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                for (int i = 0; i < data.FieldCount; i++)
                {
                    row += data.GetString(i) + "   ";
                }
                Console.WriteLine(row);
                row = "";
            }
        }

        public void TotalSalesSpecificYear(int TotalSales_Year)
        {
            string row = "";
            cmd.CommandText = $"select (quantity*price) as Total_Sales from sales where year (Sales_Date)= '{TotalSales_Year}'";
            cmd.ExecuteNonQuery();
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                for (int i = 0; i < data.FieldCount; i++)
                {
                    row += data.GetString(i) + "   ";
                }
                Console.WriteLine(row);
                row = "";
            }
        }

        public void TotalSalesSpecificMonthYear(int TotalSales_Month, int TotalSales_Year )
        {
            string row = "";
            cmd.CommandText = $"select (quantity*price) as Total_Sales from sales where month (Sales_Date)= '{TotalSales_Month}' and year (Sales_Date)='{TotalSales_Year}'";
            cmd.ExecuteNonQuery();
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                for (int i = 0; i < data.FieldCount; i++)
                {
                    row += data.GetString(i) + "   ";
                }
                Console.WriteLine(row);
                row = "";
            }
        }


        /* private void ShowRecords(string sqlSelect)
         {
             cmd.CommandText = sqlSelect;
             MySqlDataReader data = cmd.ExecuteReader();
             while (data.Read())
             {
                 Console.WriteLine(data[0] + "_____" + data[1] + "_____" + data[2] + "_____" + data[3] + "_____" + data[4] + "_____");

             }
             Console.Read();
             data.Close();
         }

         */

    }
}