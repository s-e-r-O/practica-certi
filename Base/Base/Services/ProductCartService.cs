using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class ProductCartService : ICrudable<ProductCart>
    {
        private readonly ECommerceDB _dbContext = ECommerceDB.Instance;
        public Cart Cart { private get; set; }


        public ProductCartService() { }

        public ProductCartService(Cart cart)
        {
            Cart = cart;
        }
        
        public bool Create(ProductCart obj)
        {
            if (Cart == null)
            {
                Console.WriteLine("No cart was specified.");
                return false;
            }

            // TO-DO: Check if a Product with obj.ProductCode exists

            if (Cart.ProductCarts.Exists(productCart => { return productCart.ProductCode == obj.ProductCode; }))
            {
                Console.WriteLine("The cart of user '" + Cart.Username + "' already has the product '" + obj.ProductCode + "'.");
                return false;
            }
            Cart.ProductCarts.Add(obj);
            return true;
        }

        public bool Delete(string key)
        {
            if (Cart == null)
            {
                Console.WriteLine("No cart was specified.");
                return false;
            }
            int index;
            if ((index = Cart.ProductCarts.FindIndex(productCart => { return productCart.ProductCode == key; })) < 0)
            {
                Console.WriteLine("The cart of user '" + Cart.Username + "' does not have the product '" + key + "'.");
                return false;
            }
            Cart.ProductCarts.RemoveAt(index);
            return true;
        }

        public List<ProductCart> Get()
        {
            if (Cart == null)
            {
                Console.WriteLine("No cart was specified.");
                return null;
            }
            return Cart.ProductCarts;
        }

        public bool Update(string key, ProductCart obj)
        {
            if (Cart == null)
            {
                Console.WriteLine("No cart was specified.");
                return false;
            }
            if (key != obj.ProductCode)
            {
                Console.WriteLine("The keys do not match. ( '" + key + "' != '" + obj.ProductCode + "' )");
                return false;
            }
            int index;
            if ((index = Cart.ProductCarts.FindIndex(productCart => { return productCart.ProductCode == key; })) < 0)
            {
                Console.WriteLine("The cart of user '" + Cart.Username + "' does not have the product '" + key + "'.");
                return false;
            }
            Cart.ProductCarts[index] = obj;
            return true;
        }
    }
}
