using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    public class Guest
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class Party : IEnumerable<Guest>
    {
        private List<Guest> _guestList;

        public Party()
        {
            _guestList = new List<Guest>();
        }

        public void AddGuest(Guest guest)
        {
            _guestList.Add(guest);
        }

        public IEnumerator<Guest> GetEnumerator()
        {
            foreach (Guest guest in _guestList)
            {
                yield return guest;
            }
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
            Party party = new Party();
            party.AddGuest(new Guest() { Age = 25, Name = "John" });
            party.AddGuest(new Guest() { Age = 24, Name = "Barbara" });
            party.AddGuest(new Guest() { Age = 24, Name = "Phil" });
            party.AddGuest(new Guest() { Age = 23, Name = "Fred" });
            party.AddGuest(new Guest() { Age = 26, Name = "Hannah" });
            party.AddGuest(new Guest() { Age = 27, Name = "Cindy" });

            foreach (Guest guest in party)
            {
                Console.WriteLine(guest.Name);
            }
            Console.ReadKey();
        }
    }
}