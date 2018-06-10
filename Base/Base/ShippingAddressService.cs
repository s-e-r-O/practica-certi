using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class ShippingAddressService : ICrudable<ShippingAddress>
    {
        private static ECommerceDB _dbContext = ECommerceDB.Instance;
        public User User { private get; set; }
        
        public ShippingAddressService(User user)
        {
            User = user;
        }
        public bool Create(ShippingAddress obj)
        {
            if (User == null)
            {
                Console.WriteLine("No user specified");
                return false;
            }
            if (_dbContext.ShippingAddressesList.Exists(shippingAddress => { return shippingAddress.Identifier == obj.Identifier; }))
            {
                Console.WriteLine("The user '" + "' already has the shipping address of '" + obj.Identifier);
                return false;
            }
            //add to user shipping address list
            return true;
        }

        public bool Delete(string key)
        {
            throw new NotImplementedException();
        }

        public List<ShippingAddress> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(string key, ShippingAddress obj)
        {
            throw new NotImplementedException();
        }
    }
}
