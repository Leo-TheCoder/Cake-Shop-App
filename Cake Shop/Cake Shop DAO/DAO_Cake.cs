using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Cake_Shop_DTO;

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

        public DataTable GetAllCakes()
        {
            DataTable result = new DataTable();

            string query = "select * from Cake, CakeType where Cake.CakeTypeID = CakeType.CakeTypeID";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _conn);

            adapter.Fill(result);

            return result;
        }

        public DataTable SearchCakeByName(string cakeName)
        {
            DataTable result = new DataTable();

            string query = $"select * from Cake c, CakeType ct where " +
                $"c.CakeName like N'%{cakeName}%' and " +
                $"c.CakeTypeID = ct.CakeTypeID";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _conn);

            adapter.Fill(result);

            return result;
        }

        public DataTable GetCakeByID(int cakeID)
        {
            DataTable result = new DataTable();

            string query = $"select * from Cake c, CakeType ct where c.CakeID = {cakeID}";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _conn);
            adapter.Fill(result);

            return result;
        }

        public void UpdateCake(int cakeID, string newName, double newPrice, int newType)
        {
            string query = $"update Cake set CakeName = N'{newName}', CakePrice = {newPrice}, CakeTypeID = {newType} where CakeID = {cakeID}";
            SqlCommand cmd = new SqlCommand(query, _conn);

            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void AddCake(DTO_Cake cake)
        {
            string query = $"insert into Cake(CakeID, CakeName, CakeTypeID, CakePrice, CakeAvatar) values({cake.CakeId}, '{cake.CakeName}', {int.Parse(cake.CakeType)}, {cake.CakePrice}, '{cake.CakeAvatar}')";
            SqlCommand cmd = new SqlCommand(query, _conn);

            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }
    }
}
