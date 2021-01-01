using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_BUS
{
    public class BUS_CakeType
    {
        private static BUS_CakeType _instance = null;

        public static BUS_CakeType Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BUS_CakeType();
                }

                return _instance;
            }
        }
    }
}
