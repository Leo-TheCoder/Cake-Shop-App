using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_DAO
{
    public class DAO_Cake : DBConnect
    {
        private static DAO_Cake _instance = null;

        public static DAO_Cake Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAO_Cake();
                }

                return _instance;
            }
        }
    }
}
