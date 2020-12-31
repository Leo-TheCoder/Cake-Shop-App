using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_BUS
{
    public class BUS_Cake
    {
        private static BUS_Cake _instance = null;

        public static BUS_Cake Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BUS_Cake();
                }

                return _instance;
            }
        }
    }
}
