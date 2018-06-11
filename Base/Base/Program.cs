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
            TestUserService();
            TestCategoryService();
            TestStoreService();
            TestProductCartService();
            Console.ReadLine();
        }
        
        static void TestUserService()
        {
            UserService us = new UserService();
            User user1 = new User() { Username = "Sumorenito19",Password = "camba123", Name="Tomas",LastName="Cafe" };
            User user2 = new User() { Username = "smitty", Password = "numero1", Name = "Bob", LastName = "Carvajal" };
            Console.WriteLine("$$$$ Testing CREATE $$$$");
            us.Create(user1);
            us.Create(user2);
            us.Show();
            Console.WriteLine("$$$$ Testing DELETE $$$$");
            us.Delete("Sumorenito19");
            us.Delete("Pepepicapiedras");
            us.Show();
            Console.WriteLine("$$$$ Testing UPDATE $$$$");
            us.Update("smitty", new User() { Username = "Smitty2", Password = "numero2", Name = "Bobi", LastName = "Tomi" });
            us.Update("Sumorenito19", new User() { Username = "AngelesNegros", Password = "camba345", Name = "Tom", LastName = "Te" });
            us.Show();
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
      
        static void TestStoreService()
        {
            
            Console.WriteLine("Creating!!");
            StoreService ss = new StoreService();
            Store store2 = new Store() { Name = "MAC", Line1 = "Av Juan de la Rosa", Line2 = "Edif Torres Rivera", Phone = 4040890 };
            ss.Create(store2);
            store2 = new Store() { Name = "Atom", Line1 = "Av Juan de la Rosa", Line2 = "Edif Torres Rivera", Phone = 4040890 };
            ss.Create(store2);
            foreach (Store store in ss.Get())
            {
                Console.WriteLine(store.Name + " " + store.Line1 + " " + store.Line2 + " " + store.Phone);

            }
            Console.WriteLine("Deleting!!");
            ss.Delete("Atom");
            foreach(Store store in ss.Get())
            {
                Console.WriteLine(store.Name + " " + store.Line1 + " " + store.Line2 + " " + store.Phone);

            }
            Console.WriteLine("Updating!!");
            ss.Update("MAC", new Store() { Name = "MAC", Line1 = "Av Melchor Perez", Line2 = "Edif Torres Rivera", Phone = 401123123 });
            foreach (Store store in ss.Get())
            {
                Console.WriteLine(store.Name + " " + store.Line1 + " " + store.Line2 + " " + store.Phone);
                
            }
        }
  
        static void TestCategoryService()
        {
            CategoryService cs = new CategoryService();
            Console.WriteLine(cs.Get().Count);
            Category cat = new Category() { Name = "lalada", Description = "ropachidorixdxd" };
            Category cat2 = new Category() { Name = "ropiwi", Description = "ropachidorixdxd" };
            Category cat3 = new Category() { Name = "ropota", Description = "ropachidorixdxd" };
            cs.Create(cat);
            cs.Create(cat2);
            cs.Show();
            cs.Update("ropiwi", cat3);
            cs.Show();
            cs.Delete("ropota");
            cs.Show();
        }
    }
}
