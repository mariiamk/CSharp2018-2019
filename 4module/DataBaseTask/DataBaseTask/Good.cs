using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask
{
    class Good
    {
        public int _goods_number;
        public string _comment;
        public string _category;

        public Good(int goods_number, string comment, string category)
        {
            _goods_number = goods_number;
            _comment = comment;
            _category = category;
        }

        public override string ToString()
        {
            return $"goods_number={_goods_number}, comment={_comment}," +
                $"category={_category}";
        }
    }
}
