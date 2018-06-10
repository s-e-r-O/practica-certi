using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class Cart
    {
        public List<ProductCart> ProductCarts { get; set; }
        public string Username { get; set; }

        public void Show()
        {

            Console.Write("CART:");
            if (ProductCarts == null) 
            {
                Console.Write("Empty ");
            }
            Console.WriteLine("(Cart of " + Username + ")");
        }
    }
}
