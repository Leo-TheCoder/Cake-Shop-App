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

        public DataTable GetMonthlyIncome()
        {
            DataTable data = new DataTable();

            string query = "select MONTH(O.OrderDate) as Month, SUM(C.CakePrice*OD.CakeAmount) as Profit " +
                            "from CakeOrder O, OrderDetail OD, Cake C " +
                            "where O.OrderID = OD.OrderID and OD.CakeID = C.CakeID group by MONTH(O.OrderDate)";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _conn);
            adapter.Fill(data);

            return data;
        }

        public DataTable GetAmount()
        {
            DataTable data = new DataTable();

            string query = "select count(*) as Amount from CakeOrder";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _conn);
            adapter.Fill(data);

            return data;
        }

        public void AddOrder(int id)
        {
            DateTime today = DateTime.Today;
            string query = $"insert into CakeOrder(OrderID, OrderDate) values({id}, '{today.Date}')";
            SqlCommand cmd = new SqlCommand(query, _conn);

            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void AddOrderDetail(int orderId, int cakeId, int amount)
        {
            string query = $"insert into OrderDetail(OrderID, CakeID, CakeAmount) values({orderId}, {cakeId}, {amount})";
            SqlCommand cmd = new SqlCommand(query, _conn);

            try
            {
                _conn.Open();
                cmd.ExecuteNonQuery();
                _conn.Close();
            }
            catch
            {

            }
        }
    }
}