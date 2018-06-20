using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class ShippingAddress
    {
        public string Identifier { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public int Phone { get; set; }
        public string City { get; set; }
        public string Zone { get; set; }
        public string Username { get; set; }

        public void Show()
        {
            Console.WriteLine("Identifier: " + Identifier);
            Console.WriteLine("Line 1: " + Line1);
            Console.WriteLine("Line 2: " + Line2);
            Console.WriteLine("Phone: " + Phone);
            Console.WriteLine("City: " + City);
            Console.WriteLine("Zone: " + Zone);
            Console.WriteLine("Username: " + Zone);
        }

        public static implicit operator List<object>(ShippingAddress v)
        {
            throw new NotImplementedException();
        }
    }
}
