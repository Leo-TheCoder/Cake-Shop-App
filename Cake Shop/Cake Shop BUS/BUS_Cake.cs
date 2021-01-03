using Cake_Shop_DAO;
using Cake_Shop_DTO;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<DTO_Cake> GetAllCakes()
        {
            List<DTO_Cake> result = new List<DTO_Cake>();

            DataTable data = DAO_Cake.Instance.GetAllCakes();

            foreach (DataRow row in data.Rows)
            {
                DTO_Cake cake = new DTO_Cake();
                cake.CakeId = int.Parse(row["CakeID"].ToString());
                cake.CakeName = row["CakeName"].ToString();
                cake.CakeType = row["CakeType"].ToString();
                cake.CakePrice = float.Parse(row["CakePrice"].ToString());
                cake.CakeAvatar = row["CakeAvatar"].ToString();
                result.Add(cake);
            }

            return result;
        }
    }
}
