using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_DTO
{
    public class DTO_Cake
    {
        private int _cakeId;
        private string _cakeName;
        private string _cakeType;
        private float _cakePrice;
        private string _cakeAvatar;

        public DTO_Cake()
        {
        }

        public DTO_Cake(int cakeId, string cakeName, string cakeType, float cakePrice, string cakeAvatar)
        {
            CakeId = cakeId;
            CakeName = cakeName;
            CakeType = cakeType;
            CakePrice = cakePrice;
            CakeAvatar = cakeAvatar;
        }

        public int CakeId { get => _cakeId; set => _cakeId = value; }
        public string CakeName { get => _cakeName; set => _cakeName = value; }
        public string CakeType { get => _cakeType; set => _cakeType = value; }
        public float CakePrice { get => _cakePrice; set => _cakePrice = value; }
        public string CakeAvatar { get => _cakeAvatar; set => _cakeAvatar = value; }


    }
}
