using System;
using System.Collections.Generic;
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
    }
}
