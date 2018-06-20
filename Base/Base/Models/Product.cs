using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{

    public class Product
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string ShippingDeliveryType  { get; set; }
        public string ImageURL { get; set; }
        public Category Category { get; set; }

        public Product() { }       

        public void Show()
        {
            Console.WriteLine("PRODUCT: " + Code);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("ShippingDeliveryType : " + ShippingDeliveryType );
            Console.WriteLine("Category: " + Category.Name);
        }

    }
}
