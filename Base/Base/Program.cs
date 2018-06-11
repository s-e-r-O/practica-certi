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
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("+                                           +");
            Console.WriteLine("+        This is an E-Commerce App!!        +");
            Console.WriteLine("+                                           +");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");

            MockData();

            Console.ReadLine();
        }

        static void MockData()
        {
            CategoryService categoryService = new CategoryService();
            ProductService productService = new ProductService();
            StoreService storeService = new StoreService();
            UserService userService = new UserService();
            ShippingAddressService shippingAddressService = new ShippingAddressService();
            CartService cartService = new CartService();
            ProductCartService productCartService = new ProductCartService();

            // Mocking Category Data

            Category[] categories = {
                new Category() { Name = "Technology", Description = "All tech things" },
                new Category() { Name = "Entertainment", Description = "Fun stuff" },
                new Category() { Name = "Kid Toys", Description = "Toys for kids" },
                new Category() { Name = "Clothes", Description = "Just clothes" },
                new Category() { Name = "Food", Description = "To eat" }
            };
            categories.ToList().ForEach(category => { categoryService.Create(category); });

            // Mocking Product Data

            Product[] products = {
                new Product() { Code = "peraphone_xi", Name = "Peraphone XI", Description = "The new PeraphoneTM", Category = categories[0],
                                Delivery = _Delivery.Express, Price = 1299, Type = _Type.Physical },
                new Product() { Code = "gamesphere_5", Name = "Gamesphere 5", Description = "It's not a copy at all", Category = categories[1],
                                Delivery = _Delivery.InStore, Price = 349, Type = _Type.Physical },
                new Product() { Code = "extreme_vg", Name = "Extreme Video Game", Description = "It's so XTREMEE", Category = categories[1],
                                Delivery = _Delivery.None, Price = 59, Type = _Type.Digital },
                new Product() { Code = "man_jacket_1", Name = "Winter Jacket", Description = "For Men", Category = categories[3],
                                Delivery = _Delivery.Free, Price = 199, Type = _Type.Physical },
                new Product() { Code = "leko", Name = "LEKO Brix", Description = "They are not LEGO at all", Category = categories[2],
                                Delivery = _Delivery.Normal, Price = 129, Type = _Type.Physical },
                new Product() { Code = "draculao_s", Name = "Dracula O's", Description = "Cereal for vampires", Category = categories[4],
                                Delivery = _Delivery.Express, Price = 8, Type = _Type.Physical },
                new Product() { Code = "tv_xl", Name = "TV XL", Description = "A new way to wathc your movies", Category = categories[0],
                                Delivery = _Delivery.Free, Price = 499, Type = _Type.Physical },
                new Product() { Code = "woman_jacket_1", Name = "Winter Jacket", Description = "For Women", Category = categories[3],
                                Delivery = _Delivery.Free, Price = 249, Type = _Type.Physical },
                new Product() { Code = "pirated_windows", Name = "Windows 98", Description = "Remember the old days", Category = categories[0],
                                Delivery = _Delivery.None, Price = 5, Type = _Type.Digital }
            };
            products.ToList().ForEach(product => { productService.Create(product); });

            // Mocking Store Data

            Store[] stores = {
                new Store() { Name = "Only Cereals", Line1 = "Dream St.", Line2 = "Oakland", Phone=41204930 },
                new Store() { Name = "Games", Line1 = "Flying Av.", Line2 = "Pallet Town", Phone=12389499 },
                new Store() { Name = "Just for you", Line1 = "Blv. of Broken Dreams", Line2 = "Greenland", Phone=65415844 },
                new Store() { Name = "Techs", Line1 = "Bit St.", Line2 = "Silicon Valley", Phone=90028192 }
            };
            stores.ToList().ForEach(store => { storeService.Create(store); });

            // Mocking User Data

            User[] users = {
                new User() { Username="lol1", Name="Lola", LastName="Lopez", Password="aaa111"},
                new User() { Username="fabiox", Name="Fabio", LastName="Xavier", Password="bbb111"},
                new User() { Username="gup", Name="Gonzalo", LastName="Perez", Password="ccc111"},
                new User() { Username="s_O", Name="Sandro", LastName="Dominguez", Password="aaa222"}
            };
            users.ToList().ForEach(user => { userService.Create(user); });

        }
    }
}
