﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class ECommerceDB
    {
        private static ECommerceDB _instance;

        public ECommerceDB() { }

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

        public List<Product> ProductsList { get; set; }
        public List<Category> CategorysList { get; set; }
        public List<Store> StoresList { get; set; }
        public List<ShippingAddress> ShippingAddressesList { get; set; }
        public List<User> UsersList { get; set; }
        public List<ProductCart> ProductCartsList { get; set; }
        public List<Cart> CartsList { get; set; }

    }
}
