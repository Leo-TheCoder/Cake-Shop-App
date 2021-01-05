using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_DTO
{
    public class DTO_CakeOrder
    {
        private int _orderId;
        private DateTime _orderDate;
        private List<Tuple<DTO_Cake, int, float>> _orderCakeList;

        public DTO_CakeOrder()
        {
        }

        public DTO_CakeOrder(int orderId, DateTime orderDate)
        {
            OrderId = orderId;
            OrderDate = orderDate;
        }

        public int OrderId { get => _orderId; set => _orderId = value; }
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
        public List<Tuple<DTO_Cake, int, float>> OrderCakeList { get => _orderCakeList; set => _orderCakeList = value; }
    }
}