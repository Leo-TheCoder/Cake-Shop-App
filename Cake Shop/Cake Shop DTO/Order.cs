using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_DTO
{
    public class Order
    {
        private int _orderID;
        private DateTime _orderDate;

        public int OrderID { get => _orderID; set => _orderID = value; }
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
       
    }
}
