using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class Database
    {
        private static Database _instance;

        private Database() { }

        public static Database Instance
        {
            get
            {
                if(Instance == null)
                {
                    Instance = new Database();
                }
                return Instance;
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
