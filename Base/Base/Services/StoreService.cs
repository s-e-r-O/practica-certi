using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class StoreService : ICrudable<Store>
    {
        private static ECommerceDB _dbContext = ECommerceDB.Instance;
        
        public bool Create(Store obj)
        {
            int size1 = _dbContext.StoresList.Count;
            _dbContext.StoresList.Add(obj);
            if (_dbContext.StoresList.Count == size1 + 1)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string key)
        {
            int index;
            if ((index = _dbContext.StoresList.FindIndex(Store => { return Store.Name == key; })) < 0)
            {
                Console.WriteLine("The store '" + key + "' does not exist");
                return false;
            }
            _dbContext.StoresList.RemoveAt(index);
            return true;
        }

        public List<Store> Get()
        {
            return _dbContext.StoresList;
        }

        public bool Update(string key, Store obj)
        {
            if (key != obj.Name)
            {
                Console.WriteLine("The keys do not match. ( '" + key + "' != '" + obj.Name + "' )");
                return false;
            }
            int index;
            if ((index = _dbContext.StoresList.FindIndex(cart => { return cart.Name == key; })) < 0)
            {
                Console.WriteLine("The store '" + key + "' does not exists");
                return false;
            }
            _dbContext.StoresList[index] = obj;
            return true;
        }
    }
    }

