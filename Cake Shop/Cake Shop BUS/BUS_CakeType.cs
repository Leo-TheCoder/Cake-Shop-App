using Cake_Shop_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake_Shop_DAO;
using System.Data;

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

        public List<DTO_CakeType> GetAllTypes()
        {
            List<DTO_CakeType> result = new List<DTO_CakeType>();

            DataTable data = DAO_CakeType.Instance.GetAllTypes();

            foreach(DataRow row in data.Rows)
            {
                DTO_CakeType tmpType = new DTO_CakeType
                {
                    CakeTypeId = int.Parse(row["CakeTypeID"].ToString()),
                    CakeTypeName = row["CakeTypeName"].ToString()
                };
                result.Add(tmpType);
            }

            return result;
        }

        public List<Tuple<string, int>> GetStatistic()
        {
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();

            DataTable data = DAO_CakeType.Instance.GetStatistic();

            foreach (DataRow row in data.Rows)
            {
                string typeName = row["CakeTypeName"].ToString();
                int amount = int.Parse(row["Amount"].ToString());

                Tuple<string, int> tmpTuple = new Tuple<string, int>(typeName, amount);
                result.Add(tmpTuple);
            }

            return result;
        }
    }
}
