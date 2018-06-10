using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class ShippingAddressService : ICrudable<ShippingAddress>
    {
        //change _dbContext to User in the end
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
            _dbContext.ShippingAddressesList.Add(obj);
            return true;
        }

        public bool Delete(string key)
        {
            if (User == null)
            {
                Console.WriteLine("No cart was specified.");
                return false;
            }
            int index;
            if ((index = _dbContext.ShippingAddressesList.FindIndex(shippingAddress => { return shippingAddress.Identifier == key; })) < 0)
            {
                Console.WriteLine("The user '" + "' does not have the shipping address of '" + obj.Identifier);
                return false;
            }
            _dbContext.ShippingAddressesList.RemoveAt(index);
            return true;
        }

        public List<ShippingAddress> Get()
        {
            if (User == null)
            {
                Console.WriteLine("No user specified");
                return null;
            }
            return _dbContext.ShippingAddressesList;
        }

        public bool Update(string key, ShippingAddress obj)
        {
            throw new NotImplementedException();
        }
    }
}
