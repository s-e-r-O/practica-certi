using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class ShippingAddressService : ICrudable<ShippingAddress>
    {
        public User User { private get; set; }
        private static ECommerceDB DBConnections = ECommerceDB.Instance;

        public ShippingAddressService(User user)
        {
            User = user;
        }
        public ShippingAddressService()
        {
        }
        
        public bool Create(ShippingAddress obj)
        {
            if (User == null)
            {
                Console.WriteLine("No user specified");
                return false;
            }
            if (User.ShipAdress.Exists(shippingAddress => { return shippingAddress.Identifier == obj.Identifier; }))
            {
                Console.WriteLine("The user '" + User.Username + "' already has the shipping address of '" + obj.Identifier + "'.");
                return false;
            }
            DBConnections.ShippingAddressesList.Add(obj);
            User.ShipAdress.Add(obj);
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
            if ((index = User.ShipAdress.FindIndex(shippingAddress => { return shippingAddress.Identifier == key; })) < 0)
            {
                Console.WriteLine("The user '" + User.Username + "' does not have the shipping address of '" + key + "'.");
                return false;
            }
            User.ShipAdress.RemoveAt(index);
            return true;
        }

        public List<ShippingAddress> Get()
        {
            if (User == null)
            {
                Console.WriteLine("No user specified");
                return DBConnections.ShippingAddressesList;
            }
            return User.ShipAdress;
        }

        public bool Update(string key, ShippingAddress obj)
        {
            if (User == null)
            {
                Console.WriteLine("No user was specified.");
                return false;
            }
            if (key != obj.Identifier)
            {
                Console.WriteLine("The keys do not match. ( '" + key + "' != '" + obj.Identifier + "' )");
                return false;
            }
            int index;
            if ((index = User.ShipAdress.FindIndex(shippingAddress => { return shippingAddress.Identifier == key; })) < 0)
            {
                Console.WriteLine("The user '" + User.Username + "' does not have the product '" + key + "'.");
                return false;
            }
            User.ShipAdress[index] = obj;
            return true;
        }   
    }
}
