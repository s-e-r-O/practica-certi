using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class ProductCart
    {
        public string ProductCode { get; set; }
        public string SelectedDelivery { get; set; }
        public Store Store { get; set; }
        public int Quantity { get; set; }
        public string Username { get; set; }

        public void Show()
        {
            Console.WriteLine("ProductCode: " + ProductCode + ", ShippingDeliveryType : " + SelectedDelivery + ", Quantity: " + Quantity);
        }
    }
}
