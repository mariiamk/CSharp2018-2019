using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public double Mod
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }

        public bool Equals(Point other)
        {
            if (X == other.X & Y == other.Y)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return String.Format("x = {0}, y = {1}, mod = {2:G5}", X, Y, Mod);
        }
    }
    public class PointList : IEnumerable<Point>
    {
        private List<Point> list;

        public PointList()
        {
            list = new List<Point>();
        }
        public void Add(Point p)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Equals(p)) return;
            }
            list.Add(p);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PointList set = new PointList();

            set.Add(new Point(4, 5));
            set.Add(new Point(4, 5));
            set.Add(new Point(4, 5));
            set.Add(new Point(7, 1));
            set.Add(new Point(7, 2));
            set.Add(new Point(5, 2));
            set.Add(new Point(7, 2));
            Console.WriteLine("Список точек на плоскости:");

            foreach (Point p in set)
                Console.WriteLine(p.ToString());

            Console.ReadKey();
        }
    }
}
