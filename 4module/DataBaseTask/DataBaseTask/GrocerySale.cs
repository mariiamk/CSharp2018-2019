using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask
{
    class GrocerySale
    {
        public int _account_number;
        public int _buyer_number;
        public int _shop_number;
        public int _goods_number;
        public int _count;

        public GrocerySale(int account_number, int buyer_number, int shop_number, int goods_number, int count)
        {
            _account_number = account_number;
            _buyer_number = buyer_number;
            _shop_number = shop_number;
            _goods_number = goods_number;
            _count = count;
        }

        public override string ToString()
        {
            return $"account_number={_account_number}, buyer_number={_buyer_number}," + 
                $"shop_number={_shop_number}, goods_number={_goods_number}, count={_count}";
        }
    }
}
