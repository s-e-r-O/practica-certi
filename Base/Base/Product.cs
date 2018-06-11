using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    enum _Type { Physical, Digital }
    enum _Delivery { Express, Normal, InStore, Free, None }

    class Product
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public _Type Type { get; set; }
        public _Delivery Delivery { get; set; }
        public Category Category { get; set; }

        public Product() { }       

        public void Show()
        {
            Console.WriteLine("PRODUCT: " + Code);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Delivery: " + Delivery);
            Console.WriteLine("Category: " + Category.Name);
        }

    }
}
