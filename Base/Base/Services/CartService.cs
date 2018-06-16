using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class CartService : ICrudable<Cart>
    {
        private static ECommerceDB _dbContext = ECommerceDB.Instance;

        public bool Create(Cart obj)
        {
            if (_dbContext.CartsList.Exists(cart => { return cart.Username == obj.Username; }))
            {
                Console.WriteLine("The user '" + obj.Username + "' already has a cart.");
                return false;
            }
            _dbContext.CartsList.Add(obj);
            return true;
        }

        public bool Delete(string key)
        {
            int index;
            if ((index = _dbContext.CartsList.FindIndex(cart => { return cart.Username == key; })) < 0)
            {
                Console.WriteLine("The user '" + key + "' does not have a cart.");
                return false;
            }
            _dbContext.CartsList.RemoveAt(index);
            return true;
        }

        public List<Cart> Get()
        {
            return _dbContext.CartsList;
        }

        public bool Update(string key, Cart obj)
        {
            if (key != obj.Username)
            {
                Console.WriteLine("The keys do not match. ( '" + key + "' != '" + obj.Username + "' )");
                return false;
            }
            int index;
            if ((index = _dbContext.CartsList.FindIndex(cart => { return cart.Username == key; })) < 0)
            {
                Console.WriteLine("The user '" + key + "' does not have a cart.");
                return false;
            }
            _dbContext.CartsList[index] = obj;
            return true;
        }

        public void Show()
        {
            Console.WriteLine("======== CART LIST ========");
            this.Get().ForEach(cart => { cart.Show(); });
            Console.WriteLine("---------------------------");
        }
    }
}
