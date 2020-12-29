using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_DTO
{
    public class Cake
    {
        private int _cakeID;
        private string _cakeName;
        private int _cakeTypeID;
        private float _cakePrice;
        private string _cakeAvatar;
 
        public int CakeID { get => _cakeID; set => _cakeID = value; }
        public string CakeName { get => _cakeName; set => _cakeName = value; }
        public int CakeTypeID { get => _cakeTypeID; set => _cakeTypeID = value; }
        public float CakePrice { get => _cakePrice; set => _cakePrice = value; }
        public string CakeAvatar { get => _cakeAvatar; set => _cakeAvatar = value; }
    }
}
