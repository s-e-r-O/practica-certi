using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class StoreService : ICrudable<Store>
    {
        private static ECommerceDB _dbContext = ECommerceDB.Instance;
        
        public bool Create(Store obj)
        {
            bool check = _dbContext.StoresList.Any(item => item.Name == obj.Name);
            bool checkNull = IsAnyNullOrEmpty(obj);
            if (!check && !checkNull)
            {
                _dbContext.StoresList.Add(obj);
                return true;
            }
            Console.WriteLine("ERROR while adding store. Store is already on the list");
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
            int index = _dbContext.StoresList.FindIndex(store => store.Name == key);
            bool checkNull = IsAnyNullOrEmpty(obj);

            if (index >= 0 && obj.Name == key && !checkNull)
            {
                _dbContext.StoresList[index] = obj;
                Console.WriteLine("SUCCESFULLY updated the store of the list");
                return true;
            }
            Console.WriteLine("ERROR while updating the store.");
            return false;
        }

        public bool IsAnyNullOrEmpty(object myObject)
        {
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


    }
    }

