using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    enum ShippingDelivery {
        Express,
        Normal,
        InStore,
        Free,
        None
    }

    class ProductCart
    {
        public string ProductCode { get; set; }
        public string SelectedDelivery { get; set; }
        public Store Store { get; set; }
        public int Quantity { get; set; }

        public void Show()
        {
            Console.Write("PRODUCT CART:");
            Console.Write("Code: " + ProductCode + " Delivery: " + SelectedDelivery + " Quantity: " + Quantity);
        }
    }
}
