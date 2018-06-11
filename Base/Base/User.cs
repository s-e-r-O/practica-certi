using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class User 
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        private List<ShippingAddress> _shipAdress;
        public List<ShippingAddress> ShipAdress
        {
            get
            {
                if(_shipAdress == null)
                {
                    _shipAdress = new List<ShippingAddress>();
                }
                return _shipAdress;
            }
            private set { }
        }

        public void Show()
        {
           
        }
    }
}
