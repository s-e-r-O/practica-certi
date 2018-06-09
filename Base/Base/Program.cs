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
            
            StoreService ss = new StoreService();
            Store store2 = new Store() { Name = "MAC", Line1 = "Av Juan de la Rosa", Line2 = "Edif Torres Rivera", Phone = 4040890 };
            bdlists.StoresList.Add(store2);
            ss.Delete("MAC");
            Console.ReadLine();
        }
    }
}
