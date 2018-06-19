using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class Test
    {
        public static void Run()
        {
            Console.WriteLine("\n***************** TESTING USER ******************\n");
            TestUserService();
            Console.WriteLine("\n*********** TESTING SHIPPING ADDRESS ************\n");
            TestShippingAddress();
            Console.WriteLine("\n*************** TESTING CATEGORY ****************\n");
            TestCategoryService();
            Console.WriteLine("\n***************** TESTING STORE *****************\n");
            TestStoreService();
            Console.WriteLine("\n************** TESTING PRODUCT ******************\n");
            TestProductService();
            Console.WriteLine("\n*********** TESTING PRODUCT CART/CART ***********\n");
            TestProductCartService();
        }
        static void TestProductService()
        {
            Category c1 = new Category() { Name = "Para mayores papu :v", Description = "Not for crazy kidsss" };
            ProductService PS = new ProductService();
            Product p1 = new Product() { Code = "QWERTY", Name = "Product 1", Category = c1, ShippingDeliveryType  = "Express", Description = "Very good reco +10", Type = "Digital", Price = 100.5 };
            Product p2 = new Product() { Code = "JEJE", Name = "Product 2", Category = c1, ShippingDeliveryType  = "Normal", Description = "Not good, its feik", Type = "Physical", Price = 500.80 };

            PS.Create(p1);
            PS.Create(p2);
            PS.Create(p1);
            foreach (Product p in PS.Get())
            {
                p.Show();
            }
            PS.Delete("JEJE");
            foreach (Product p in PS.Get())
            {
                p.Show();
            }
            PS.Update("QWERTY", p2);
            foreach (Product p in PS.Get())
            {
                p.Show();
            }

            Console.WriteLine("TESTEADO PAPU, INEFICIENTE PERO TESTEADO :v");

        }


        static void TestUserService()
        {
            UserService us = new UserService();
            User user1 = new User() { Username = "Sumorenito19", Password = "camba123", Name = "Tomas", LastName = "Cafe" };
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

        static void TestShippingAddress()
        {
            ShippingAddressService shs = new ShippingAddressService();
            UserService us = new UserService();
            User user1 = new User() { Username = "Sam", Password = "camba123", Name = "Tomas", LastName = "Cafe" };
            User user2 = new User() { Username = "Sarah", Password = "numero1", Name = "Bob", LastName = "Carvajal" };
            us.Create(user1);
            us.Show();
            Console.WriteLine("$$$$ Testing CREATE $$$$");
            shs.User = user1;
            shs.Create(new ShippingAddress() { Identifier = "sh1", Line1 = "Av. America", Line2 = "Edif. Torrez", Phone = 75382012, City = "Cochabamba", Zone = "Sarcobamba" });
            shs.Create(new ShippingAddress() { Identifier = "sh1", Line1 = "Av. America", Line2 = "Edif. Torrez", Phone = 75382012, City = "Cochabamba", Zone = "Sarcobamba" });
            shs.User = user2;
            shs.Create(new ShippingAddress() { Identifier = "sh1", Line1 = "Av. America", Line2 = "Edif. Torrez", Phone = 75382012, City = "Cochabamba", Zone = "Sarcobamba" });
            us.Show();
            us.Create(user2);
            us.Show();
            Console.WriteLine("$$$$ Testing UPDATE $$$$");
            shs.User = user1;
            shs.Update("sh1", new ShippingAddress() { Identifier = "sh1", Line1 = "Av. America", Line2 = "Edif. Muriel", Phone = 75382012, City = "Cochabamba", Zone = "Sarcobamba" });
            us.Show();
            shs.User = user2;
            shs.Update("sh1", new ShippingAddress() { Identifier = "sh1", Line1 = "Av. America", Line2 = "Edif. Torrez", Phone = 75382012, City = "Cochabamba", Zone = "Sarcobamba" });
            us.Show();
            Console.WriteLine("$$$$ Testing DELETE $$$$");
            shs.User = user1;
            shs.Delete("sh1");
            shs.Delete("shsh1");
            us.Show();
            shs.User = user2;
            shs.Delete("sh1");
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
            pcs.Create(new ProductCart() { ProductCode = "AA", SelectedDelivery ="None", Quantity = 2 });
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
            foreach (Store store in ss.Get())
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
