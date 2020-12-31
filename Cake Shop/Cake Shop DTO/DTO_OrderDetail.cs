using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_DTO
{
    public class DTO_OrderDetail
    {
        private int _orderId;
        private int _cakeId;
        private int _cakeAmount;

        public DTO_OrderDetail()
        {
        }

        public DTO_OrderDetail(int orderId, int cakeId, int cakeAmount)
        {
            OrderId = orderId;
            CakeId = cakeId;
            CakeAmount = cakeAmount;
        }

        public int OrderId { get => _orderId; set => _orderId = value; }
        public int CakeId { get => _cakeId; set => _cakeId = value; }
        public int CakeAmount { get => _cakeAmount; set => _cakeAmount = value; }
    }
}
