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
            //TestUsertService();
            TestShippingAddress();
            Console.ReadLine();
        }

        static void TestUsertService()
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
    }
}
