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
            Console.ReadLine();
        }
    }
}
