using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class Cart
    {
        private List<ProductCart> _productCarts;
        public List<ProductCart> ProductCarts
        {
            get
            {
                if (_productCarts == null)
                {
                    _productCarts = new List<ProductCart>();
                }
                return _productCarts;
            }
            private set { }
        }
        public string Username { get; set; }
        public void Show()
        {
            Console.WriteLine("(Cart of " + Username + ")");
            Console.WriteLine("CART:");
            if (ProductCarts.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else { }
        }
    }
}
