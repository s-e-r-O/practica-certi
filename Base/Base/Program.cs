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
            TestProductCartService();
            Console.ReadLine();
        }

        static void TestCartService()
        {
            CartService cs = new CartService();
            Cart cart1 = new Cart() { Username = "Mac" };
            Cart cart2 = new Cart() { Username = "Tom" };
            Console.WriteLine("$$$$ Testing CREATE $$$$");
            cs.Create(cart1);
            cs.Create(cart2);
            cs.Create(cart2);
            cs.Show();
            Console.WriteLine("$$$$ Testing DELETE $$$$");
            cs.Delete("Tom");
            cs.Delete("AspNet");
            cs.Show();
            Console.WriteLine("$$$$ Testing UPDATE $$$$");
            cs.Update("Tom", new Cart() { Username = "Lola" });
            cs.Update("Mac", new Cart() { Username = "Lola" });
            cs.Show();
        }

        static void TestProductCartService()
        {
            ProductCartService pcs = new ProductCartService();
            CartService cs = new CartService();
            Cart cart1 = new Cart() { Username = "Mac" };
            Cart cart2 = new Cart() { Username = "Lola" };
            cs.Create(cart1);
            cs.Show();
            Console.WriteLine("$$$$ Testing CREATE $$$$");
            pcs.Cart = cart1;
            pcs.Create(new ProductCart() { ProductCode = "AA", SelectedDelivery = "None", Quantity = 2 });
            pcs.Create(new ProductCart() { ProductCode = "AA", SelectedDelivery = "None", Quantity = 2 });
            pcs.Cart = cart2;
            pcs.Create(new ProductCart() { ProductCode = "AA", SelectedDelivery = "None", Quantity = 2 });
            cs.Show();
            cs.Create(cart2);
            cs.Show();
            Console.WriteLine("$$$$ Testing UPDATE $$$$");
            pcs.Cart = cart1;
            pcs.Update("AA", new ProductCart() { ProductCode = "AA", SelectedDelivery = "None", Quantity = 5 });
            cs.Show();
            pcs.Cart = cart2;
            pcs.Update("AA", new ProductCart() { ProductCode = "AA", SelectedDelivery = "None", Quantity = 5 });
            cs.Show();
            Console.WriteLine("$$$$ Testing DELETE $$$$");
            pcs.Cart = cart1;
            pcs.Delete("AA");
            pcs.Delete("ASA");
            cs.Show();
            pcs.Cart = cart2;
            pcs.Delete("AA");
            cs.Show();
        }



    }
}
