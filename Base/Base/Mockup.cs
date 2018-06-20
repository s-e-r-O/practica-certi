using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class Mockup
    {
        public static void MockData()
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
                                ShippingDeliveryType  = "Express", Price = 1299, Type = "Physical" },
                new Product() { Code = "gamesphere_5", Name = "Gamesphere 5", Description = "It's not a copy at all", Category = categories[1],
                                ShippingDeliveryType  = "InStore", Price = 349, Type = "Physical" },
                new Product() { Code = "extreme_vg", Name = "Extreme Video Game", Description = "It's so XTREMEE", Category = categories[1],
                                ShippingDeliveryType  = "None", Price = 59, Type = "Digital"},
                new Product() { Code = "man_jacket_1", Name = "Winter Jacket", Description = "For Men", Category = categories[3],
                                ShippingDeliveryType  = "Free", Price = 199, Type = "Physical" },
                new Product() { Code = "leko", Name = "LEKO Brix", Description = "They are not LEGO at all", Category = categories[2],
                                ShippingDeliveryType  = "Normal", Price = 129, Type = "Physical" },
                new Product() { Code = "draculao_s", Name = "Dracula O's", Description = "Cereal for vampires", Category = categories[4],
                                ShippingDeliveryType  = "Express", Price = 8, Type = "Physical" },
                new Product() { Code = "tv_xl", Name = "TV XL", Description = "A new way to wathc your movies", Category = categories[0],
                                ShippingDeliveryType  = "Free", Price = 499, Type = "Physical" },
                new Product() { Code = "woman_jacket_1", Name = "Winter Jacket", Description = "For Women", Category = categories[3],
                                ShippingDeliveryType  = "Free", Price = 249, Type = "Physical" },
                new Product() { Code = "pirated_windows", Name = "Windows 98", Description = "Remember the old days", Category = categories[0],
                                ShippingDeliveryType  = "None", Price = 5, Type = "Digital" }
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

            // Mocking Shipping Address Data

            ShippingAddress[][] shippingAddresses = {
                new ShippingAddress[] {
                    new ShippingAddress() { Identifier="00000", City="Cochabamba",
                                            Line1 ="C. Caracoles", Line2="", Phone = 4787657, Zone = "Zona Norte"},
                    new ShippingAddress() { Identifier="00001", City="Cochabamba",
                                            Line1 ="C. Camarones", Line2="", Phone = 4559403, Zone = "Zona Norte"},
                },
                new ShippingAddress[] {
                    new ShippingAddress() { Identifier="00000", City="La Paz",
                                            Line1 ="Edificio Miranda", Line2="Dpto 222", Phone = 2098799, Zone = "Zona Sud"},
                    new ShippingAddress() { Identifier="00001", City="El Alto",
                                            Line1 ="C. Miranda", Line2="", Phone = 4787657, Zone = "Zona Sud"},
                },
                new ShippingAddress[] {
                    new ShippingAddress() { Identifier="00000", City="Alabama",
                                            Line1 ="Bright Av.", Line2="", Phone = 150923098, Zone = "Sunnyside"},
                    new ShippingAddress() { Identifier="00001", City="Alabamba",
                                            Line1 ="Sky St.", Line2="", Phone = 150829300, Zone = "Sweet Home"},
                },
                new ShippingAddress[] {
                    new ShippingAddress() { Identifier="00000", City="Cochabamba",
                                            Line1 ="C. Angulo", Line2="", Phone = 4332617, Zone = "Colcapirhua"},
                    new ShippingAddress() { Identifier="00001", City="Cochabamba",
                                            Line1 ="C. Benito", Line2="", Phone = 4889201, Zone = "Sarco"},
                }
            };
            int index = 0;
            shippingAddresses.ToList().ForEach(shippingAddressesList => {
                shippingAddressService.User = users[index];
                shippingAddressesList.ToList().ForEach(shippingAddress => { shippingAddressService.Create(shippingAddress); });
                index++;
            });

            // Mocking Cart Data

            Cart[] carts = {
                new Cart() { Username="lol1" },
                new Cart() { Username="fabiox" },
                new Cart() { Username="gup" },
                new Cart() { Username="s_O" }
            };
            carts.ToList().ForEach(cart => { cartService.Create(cart); });

            // Mocking Product Cart Data

            ProductCart[][] productCarts = {
                new ProductCart[] {
                    new ProductCart() { ProductCode="tv_xl", SelectedDelivery="Express", Quantity=1 },
                    new ProductCart() { ProductCode="leko", SelectedDelivery="Express", Quantity=3 }
                },
                new ProductCart[] {
                    new ProductCart() { ProductCode="gamesphere_5", SelectedDelivery="Express", Quantity=1 },
                    new ProductCart() { ProductCode="xtreme_vg", SelectedDelivery="Express", Quantity=5 }
                },
                new ProductCart[] {
                    new ProductCart() { ProductCode="man_jacket_1", SelectedDelivery="Express", Quantity=2 },
                    new ProductCart() { ProductCode="woman_jacket_1", SelectedDelivery="Express", Quantity=2 }
                },
                new ProductCart[] {
                    new ProductCart() { ProductCode="pirated_windows", SelectedDelivery="Express", Quantity=10 },
                    new ProductCart() { ProductCode="draculao_s", SelectedDelivery="Express", Quantity=11 }
                }
            };
            index = 0;
            productCarts.ToList().ForEach(productCartsList => {
                productCartService.Cart = carts[index];
                productCartsList.ToList().ForEach(productCart => { productCartService.Create(productCart); });
                index++;
            });
        }
    }
}
