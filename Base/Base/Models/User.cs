using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class User 
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        private List<ShippingAddress> _shipAdress;
        public List<ShippingAddress> ShipAdress
        {
            get
            {
                if(_shipAdress == null)
                {
                    _shipAdress = new List<ShippingAddress>();
                }
                return _shipAdress;
            }
            private set { }
        }

        public void Show()
        {
            Console.WriteLine("(User: "+ Username + ")");
            Console.WriteLine("(Password: " + Password + ")");
            Console.WriteLine("(Name: " + Name + ")");
            Console.WriteLine("(Last Name: " + LastName + ")");
            if (ShipAdress.Count == 0)
            {
                Console.WriteLine("No Shipping Address Registered");
            }
            else {
                for (int i=0; i<ShipAdress.Count; i++)
                {
                    Console.WriteLine("Identifier " + (i+1) + ": " + ShipAdress[i].Identifier);
                    Console.WriteLine("Line1 " + (i + 1) + ": " + ShipAdress[i].Line1);
                    Console.WriteLine("Line1 " + (i + 1) + ": " + ShipAdress[i].Line2);
                    Console.WriteLine("Phone " + (i + 1) + ": " + ShipAdress[i].Phone);
                    Console.WriteLine("City " + (i + 1) + ": " + ShipAdress[i].City);
                    Console.WriteLine("Zone " + (i + 1) + ": " + ShipAdress[i].Zone);
                }
            }
        }
    }
}
