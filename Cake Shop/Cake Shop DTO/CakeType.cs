using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_DTO
{
    public class CakeType
    {
        private string _cakeTypeName;
        private int _cakeTypeID;

        public string CakeTypeName { get => _cakeTypeName; set => _cakeTypeName = value; }
        public int CakeTypeID { get => _cakeTypeID; set => _cakeTypeID = value; }

    }
}
