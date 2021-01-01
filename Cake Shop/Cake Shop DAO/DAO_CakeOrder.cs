using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_DAO
{
    public class DAO_CakeOrder
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
    }
}
