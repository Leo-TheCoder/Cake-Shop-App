using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_DAO
{
    public class DAO_CakeOrder : DBConnect
    {
        private static DAO_CakeOrder _instance = null;

        public static DAO_CakeOrder Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAO_CakeOrder();
                }

                return _instance;
            }
        }

        public DataTable GetAllOrders()
        {
            DataTable data = new DataTable();
            string query = $"select * from CakeOrder";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, _conn);
                adapter.Fill(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return data;
        }

        public DataTable GetOrderDetails(int orderId)
        {
            DataTable data = new DataTable();


            string query = "select OrderDetail.CakeID, OrderDetail.CakeAmount, Cake.CakeName, Cake.CakePrice, Cake.CakePrice * OrderDetail.CakeAmount as Total from OrderDetail, Cake"
                + $" where OrderDetail.OrderID={orderId} and OrderDetail.CakeID = Cake.CakeID";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _conn);
            adapter.Fill(data);

            return data;
        }
    }
}
