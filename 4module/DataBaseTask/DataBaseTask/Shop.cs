using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask
{
    class Shop
    {
        public int _shop_number;
        public string _name;
        public string _town;
        public string _area;
        public int _telephon;

        public Shop(int shop_number, string name, string town, string area, int telephon)
        {
            _shop_number = shop_number;
            _name = name;
            _town = town;
            _area = area;
            _telephon = telephon;
        }

        public override string ToString()
        {
            return $"shop_number={_shop_number}, name={_name}," +
                $"town={_town}, area={_area}, telephon={_telephon}";
        }
    }
}
