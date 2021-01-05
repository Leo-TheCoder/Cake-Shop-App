using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_DAO
{
    public class DAO_CakeType
    {
        private static DAO_CakeType _instance = null;

        public static DAO_CakeType Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAO_CakeType();
                }

                return _instance;
            }
        }
    }
}
