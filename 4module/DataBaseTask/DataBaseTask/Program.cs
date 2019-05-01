using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Good> goods = new List<Good>();
            List<Shop> shops = new List<Shop>();
            List<Buyer> buyers = new List<Buyer>();
            List<GrocerySale> grocerySales = new List<GrocerySale>();
            shops.Add(new Shop(1, "Ашан", "Москва", "Москва", 915678));
            shops.Add(new Shop(2, "Пятерочка", "Москва", "Москва", 343298));
            shops.Add(new Shop(3, "Азбука Вкуса", "Мамыри", "Москва", 234980));
            shops.Add(new Shop(4, "Глобус", "Самара", "Самарская область", 457890));
            shops.Add(new Shop(5, "Перекресток", "Вологда", "Вологодская область", 234590));
            shops.Add(new Shop(6, "Перекресток", "Москва", "Москва", 321432));
            shops.Add(new Shop(7, "Пятерочка", "Москва", "Москва", 321111));

            goods.Add(new Good(1, "Ограничен срок хранения", "Молоко"));
            goods.Add(new Good(2, "Хранить при -10", "Творог"));
            goods.Add(new Good(3, "Очень вкусный", "Творог"));
            goods.Add(new Good(4, "Маленькая пачка", "Творог"));
            goods.Add(new Good(5, "Яркая упаковка", "Сыр"));
            goods.Add(new Good(6, "Не очень вкусно", "Глазированный сырок"));
            goods.Add(new Good(7, "Горчит", "Масло"));
            goods.Add(new Good(8, "Очень дорого", "Масло"));
            goods.Add(new Good(9, "Редко бывает", "Масло"));
            goods.Add(new Good(10, "Быстро портится", "Сыр"));

            buyers.Add(new Buyer(1, "Иван", "Иванов"));
            buyers.Add(new Buyer(2, "Петр", "Петров"));
            buyers.Add(new Buyer(3, "Андрей", "Андреев"));

            grocerySales.Add(new GrocerySale(1, 1, 1, 1, 1));
            grocerySales.Add(new GrocerySale(2, 1, 2, 2, 2));
            grocerySales.Add(new GrocerySale(3, 1, 3, 2, 10));
            grocerySales.Add(new GrocerySale(4, 1, 1, 3, 5));
            grocerySales.Add(new GrocerySale(5, 1, 6, 4, 7));
            grocerySales.Add(new GrocerySale(6, 1, 5, 5, 3));
            grocerySales.Add(new GrocerySale(7, 1, 7, 6, 8));
            grocerySales.Add(new GrocerySale(8, 2, 7, 7, 6));
            grocerySales.Add(new GrocerySale(9, 2, 6, 7, 5));
            grocerySales.Add(new GrocerySale(10, 2, 7, 7, 9));
            grocerySales.Add(new GrocerySale(11, 2, 7, 8, 3));
            grocerySales.Add(new GrocerySale(12, 2, 2, 9, 1));
            grocerySales.Add(new GrocerySale(13, 2, 1, 10, 3));
            grocerySales.Add(new GrocerySale(14, 2, 5, 1, 5));
            grocerySales.Add(new GrocerySale(15, 3, 1, 2, 7));
            grocerySales.Add(new GrocerySale(16, 3, 6, 4, 8));
            grocerySales.Add(new GrocerySale(17, 3, 7, 6, 3));
            grocerySales.Add(new GrocerySale(18, 3, 3, 8, 4));
            grocerySales.Add(new GrocerySale(19, 3, 1, 10, 9));
            grocerySales.Add(new GrocerySale(20, 3, 6, 1, 6));

            var a = from t in grocerySales
                    from b in goods
                    where t._buyer_number == 2 && b._goods_number == t._goods_number
                    select b;

            foreach (var aa in a)
                Console.WriteLine(aa);

            Console.ReadKey();

        }
    }
}
