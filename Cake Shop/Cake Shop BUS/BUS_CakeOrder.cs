using Cake_Shop_DAO;
using Cake_Shop_DTO;
using System;
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
                DTO_CakeOrder cake = new DTO_CakeOrder();
                cake.OrderId = int.Parse(row["OrderID"].ToString());
                cake.OrderDate = DateTime.Parse(row["OrderDate"].ToString());
                result.Add(cake);
            }

            return result;
        }
    }
}
