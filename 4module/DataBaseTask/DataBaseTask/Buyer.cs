using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask
{
    class Buyer
    {
        public int _buyer_number;
        public string _name;
        public string _surname;

        public Buyer(int buyer_number, string name, string surname)
        {
            _buyer_number = buyer_number;
            _name = name;
            _surname = surname;
        }

        public override string ToString()
        {
            return $"buyer_number={_buyer_number}, name={_name}," +
                $"surname={_surname}";
        }
    }
}
