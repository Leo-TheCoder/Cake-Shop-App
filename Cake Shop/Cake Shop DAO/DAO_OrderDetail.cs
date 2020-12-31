using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_DAO
{
    public class DAO_OrderDetail
    {
        private static DAO_OrderDetail _instance = null;

        public static DAO_OrderDetail Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAO_OrderDetail();
                }

                return _instance;
            }
        }
    }
}
