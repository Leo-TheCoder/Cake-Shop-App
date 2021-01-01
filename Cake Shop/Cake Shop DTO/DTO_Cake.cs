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
        private int _cakeTypeId;
        private float _cakePrice;
        private string _cakeAvatar;

        public DTO_Cake()
        {
        }

        public DTO_Cake(int cakeId, string cakeName, int cakeTypeId, float cakePrice, string cakeAvatar)
        {
            CakeId = cakeId;
            CakeName = cakeName;
            CakeTypeId = cakeTypeId;
            CakePrice = cakePrice;
            CakeAvatar = cakeAvatar;
        }

        public int CakeId { get => _cakeId; set => _cakeId = value; }
        public string CakeName { get => _cakeName; set => _cakeName = value; }
        public int CakeTypeId { get => _cakeTypeId; set => _cakeTypeId = value; }
        public float CakePrice { get => _cakePrice; set => _cakePrice = value; }
        public string CakeAvatar { get => _cakeAvatar; set => _cakeAvatar = value; }


    }
}
