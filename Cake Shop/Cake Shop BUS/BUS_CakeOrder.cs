using Cake_Shop_DAO;
using Cake_Shop_DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_BUS
{
    public class BUS_CakeOrder
    {
        private static BUS_CakeOrder _instance = null;

        public static BUS_CakeOrder Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BUS_CakeOrder();
                }

                return _instance;
            }
        }

        public List<DTO_CakeOrder> GetAllOrders()
        {
            List<DTO_CakeOrder> result = new List<DTO_CakeOrder>();

            DataTable data = DAO_CakeOrder.Instance.GetAllOrders();

            foreach (DataRow row in data.Rows)
            {
                DTO_CakeOrder order = new DTO_CakeOrder();
                order.OrderId = int.Parse(row["OrderID"].ToString());
                order.OrderDate = DateTime.Parse(row["OrderDate"].ToString());
                order.OrderCakeList = GetOrderDetails(order.OrderId);
                result.Add(order);
            }

            return result;
        }

        public List<Tuple<DTO_Cake, int, float>> GetOrderDetails(int orderId)
        {
            List<Tuple<DTO_Cake, int, float>> result = new List<Tuple<DTO_Cake, int, float>>();
            DataTable data = DAO_CakeOrder.Instance.GetOrderDetails(orderId);

            foreach (DataRow row in data.Rows)
            {
                DTO_Cake cake = new DTO_Cake();
                cake.CakeId = int.Parse(row["CakeID"].ToString());
                cake.CakeName = row["CakeName"].ToString();
                cake.CakePrice = float.Parse(row["CakePrice"].ToString());
                int amount = int.Parse(row["CakeAmount"].ToString());
                float total = float.Parse(row["Total"].ToString());
                result.Add(Tuple.Create(cake, amount, total));
            }

            return result;
        }

        public void AddOrderDetail(int orderId, int cakeId, int amount)
        {
            DAO_CakeOrder.Instance.AddOrderDetail(orderId, cakeId, amount);
        }

        public void AddOrder(int id)
        {
            DAO_CakeOrder.Instance.AddOrder(id);
        }

        public int GetAmount()
        {
            int result;

            DataTable data = DAO_CakeOrder.Instance.GetAmount();
            DataRow row = data.Rows[0];

            result = int.Parse(row["Amount"].ToString());

            return result;
        }
    }
}