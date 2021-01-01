using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_BUS
{
    public class BUS_OrderDetail
    {
        private static BUS_OrderDetail _instance = null;

        public static BUS_OrderDetail Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BUS_OrderDetail();
                }

                return _instance;
            }
        }
    }
}
