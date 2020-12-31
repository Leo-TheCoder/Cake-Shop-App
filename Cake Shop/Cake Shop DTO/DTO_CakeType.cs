using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_Shop_DTO
{
    public class DTO_CakeType
    {
        private int _cakeTypeId;
        private string _cakeTypeName;

        public DTO_CakeType()
        {
        }

        public DTO_CakeType(int cakeTypeId, string cakeTypeName)
        {
            CakeTypeId = cakeTypeId;
            CakeTypeName = cakeTypeName;
        }

        public int CakeTypeId { get => _cakeTypeId; set => _cakeTypeId = value; }
        public string CakeTypeName { get => _cakeTypeName; set => _cakeTypeName = value; }
    }
}
