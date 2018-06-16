using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class CategoryService : ICrudable<Category>
    {
        private static ECommerceDB categorydb = ECommerceDB.Instance;

        public bool Create(Category obj)
        {
            bool check = categorydb.CategorysList.Any(item => item.Name == obj.Name);
            bool checkNull = IsAnyNullOrEmpty(obj);
            if (!check && !checkNull)
            {
                categorydb.CategorysList.Add(obj);
                return true;
            }
            Console.WriteLine("ERROR while adding category. Category is already on the list");
            return false;
        }

        public bool Delete(string key)
        {
            foreach (Category data in categorydb.CategorysList)
            {
                if (data.Name.Equals(key))
                {
                    categorydb.CategorysList.Remove(data);
                    Console.WriteLine("elemento eliminado satisfactoriamente");
                    return true;
                }

            }
            return false;
        }

        public bool Update(string key, Category obj)
        {
            int index = categorydb.CategorysList.FindIndex(category => category.Name == key);
            bool checkNull = IsAnyNullOrEmpty(obj);

            if (index >= 0 && obj.Name == key && !checkNull)
            {
                categorydb.CategorysList[index] = obj;
                Console.WriteLine("SUCCESFULLY updated the category of the list");
                return true;
            }
            Console.WriteLine("ERROR while updating the category.");
            return false;

        }

        public List<Category> Get()
        {
            return categorydb.CategorysList;
        }

        public void Show()
        {
            foreach (Category data in categorydb.CategorysList)
            {
                Console.WriteLine("Name: " + data.Name + ", Description: " + data.Description);
            }
            Console.WriteLine("xdxdxdxdxdxdxdxdxdxdxdxdxdxd");
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
