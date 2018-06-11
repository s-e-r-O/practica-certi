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
            TestUsertService();
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
    }
}
