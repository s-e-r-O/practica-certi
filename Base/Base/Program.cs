using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is an E-Commerce App!!");
            TestCartService();
            Console.ReadLine();
        }

        static void TestCartService()
        {
            CartService cs = new CartService();
            Cart cart1 = new Cart() { ProductCarts = null, Username = "Mac" };
            Cart cart2 = new Cart() { ProductCarts = null, Username = "Tom" };
            Console.WriteLine("$$$$ Testing CREATE $$$$");
            cs.Create(cart1);
            cs.Create(cart2);
            cs.Create(cart2);
            cs.ShowCarts();
            Console.WriteLine("$$$$ Testing DELETE $$$$");
            cs.Delete("Tom");
            cs.Delete("AspNet");
            cs.ShowCarts();
            Console.WriteLine("$$$$ Testing UPDATE $$$$");
            cs.Update("Tom", new Cart() { ProductCarts = null, Username = "Lola" });
            cs.Update("Mac", new Cart() { ProductCarts = null, Username = "Lola" });
            cs.ShowCarts();
        }

        

    }
}
