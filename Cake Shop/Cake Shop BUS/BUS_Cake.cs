using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Cake_Shop_DAO;
using Cake_Shop_DTO;

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

            foreach(DataRow row in data.Rows)
            {
                DTO_Cake tmpCake = new DTO_Cake();

                tmpCake.CakeId = int.Parse(row["CakeID"].ToString());
                tmpCake.CakeName = row["CakeName"].ToString();
                tmpCake.CakePrice = float.Parse(row["CakePrice"].ToString());
                tmpCake.CakeType = row["CakeTypeName"].ToString();
                tmpCake.CakeAvatar = row["CakeAvatar"].ToString();

                result.Add(tmpCake);
            }

            return result;
        }

        public DTO_Cake GetCakeByID(int cakeID)
        {
            DTO_Cake result = new DTO_Cake();
            DataTable data = DAO_Cake.Instance.GetCakeByID(cakeID);
            DataRow row = data.Rows[0];

            
            result.CakeId = int.Parse(row["CakeID"].ToString());
            result.CakeName = row["CakeName"].ToString();
            result.CakePrice = float.Parse(row["CakePrice"].ToString());
            result.CakeType = row["CakeTypeName"].ToString();
            result.CakeAvatar = row["CakeAvatar"].ToString();

            return result;
        }

        public void UpdateCake(int cakeID, string newName, double newPrice, int newType)
        {
            DAO_Cake.Instance.UpdateCake(cakeID, newName, newPrice, newType);
        }

        public List<DTO_Cake> GetSearchCakeByName(string nameCake)
        {
            List<DTO_Cake> result = new List<DTO_Cake>();
            DataTable data = DAO_Cake.Instance.SearchCakeByName(nameCake);

            foreach (DataRow row in data.Rows)
            {
                DTO_Cake tmpCake = new DTO_Cake();

                tmpCake.CakeId = int.Parse(row["CakeID"].ToString());
                tmpCake.CakeName = row["CakeName"].ToString();
                tmpCake.CakePrice = float.Parse(row["CakePrice"].ToString());
                tmpCake.CakeType = row["CakeTypeName"].ToString();
                tmpCake.CakeAvatar = row["CakeAvatar"].ToString();

                result.Add(tmpCake);
            }

            return result;
        }
    }
}
