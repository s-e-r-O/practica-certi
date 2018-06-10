﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class StoreService : ICrudable<Store>
    {
        private static ECommerceDB _dbContext = ECommerceDB.Instance;
        
        public bool Create(Store obj)
        {
            int size1 = _dbContext.StoresList.Count;
            _dbContext.StoresList.Add(obj);
            if (_dbContext.StoresList.Count == size1 + 1)
            {
                Console.WriteLine("successfully created");
                return true;
            }
            return false;
        }

        public bool Delete(string key)
        {
            int size1 = _dbContext.StoresList.Count;
            foreach (object store in _dbContext.StoresList)
            {
                Console.WriteLine(store);
            }
            Store store1 = new Store() { Name = "Apple", Line1 = "Av Juan de la Rosa", Line2 = "Edif Torres Rivera", Phone = 4040890 };
            _dbContext.StoresList.Remove(store1);
            if (_dbContext.StoresList.Count == size1 - 1)
            {
                return true;
            }
            return false;
        }
        
        public bool Update(string key, Store obj)
        {
            throw new NotImplementedException();
        }
        
        public List<Store> Get()
        {
            return _dbContext.StoresList;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class StoreService : Crudable
    {
        private static ECommerceDB bdlists = ECommerceDB.Instance;
        public bool Create(object obj)
        {
            Store store1 = new Store() { Name = "Apple", Line1 = "Av Juan de la Rosa", Line2 = "Edif Torres Rivera", Phone =4040890};
            bdlists.StoresList.Add(store1);
            int size1 = bdlists.StoresList.Count;
            if (bdlists.StoresList.Count == size1+1)
            {
                Console.WriteLine("successfully created");
                return true;
            }
            return false;
        }

        public bool Delete(string key)
        {
            int size1 = bdlists.StoresList.Count;
            foreach (object store in bdlists.StoresList)
            {
                Console.WriteLine(store);
                Console.ReadKey();
            }
            Store store1 = new Store() { Name = "Apple", Line1 = "Av Juan de la Rosa", Line2 = "Edif Torres Rivera", Phone = 4040890 };
            bdlists.StoresList.Remove(store1);
            if (bdlists.StoresList.Count == size1 - 1)
            {
                return true;
            }
            return false;
        }

        public List<object> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(string key, object obj)
        {
            throw new NotImplementedException();
        }
    }
}
