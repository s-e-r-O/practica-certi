using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class ECommerceDB
    {
        private static ECommerceDB _instance;

        private ECommerceDB() {
            this.UsersList = new List<User>();
            this.CategorysList = new List<Category>();
            this.StoresList = new List<Store>();
            this.CartsList = new List<Cart>();
            this.ProductsList = new List<Product>();
            this.ShippingAddressesList = new List<ShippingAddress>();
        }

        public static ECommerceDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ECommerceDB();
                }
                return _instance;
            }
        }

        public List<Product> ProductsList { get; private set; }
        public List<Category> CategorysList { get; private set; }
        public List<Store> StoresList { get; private set; }
        public List<ShippingAddress> ShippingAddressesList { get; private set; }
        public List<User> UsersList { get; private set; }
        public List<Cart> CartsList { get; private set; }

    }
}
