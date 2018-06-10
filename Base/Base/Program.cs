using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class Program
    {
        private static ECommerceDB bdlists = ECommerceDB.Instance;

        static void Main(string[] args)
        {
            Console.WriteLine("This is an E-Commerce App!!");

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
            Console.ReadLine();
            
            
        }
    }
}
