using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class CategoryService : ICrudable<Category>
    {
        private static ECommerceDB categorydb = ECommerceDB.Instance;

        public bool Create(Category obj)
        {
            foreach (Category data in categorydb.CategorysList)
            {
                if (data.Name.Equals(obj.Name))
                {
                    Console.WriteLine("El nombre ya existe");
                    return false;
                }

            }
            categorydb.CategorysList.Add(obj);
            return true;
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
            foreach (Category data in categorydb.CategorysList)
            {
                if (data.Name.Equals(key))
                {
                    foreach (Category data1 in categorydb.CategorysList)
                    {
                        if (data1.Name.Equals(obj.Name))
                        {
                            Console.WriteLine("Ya existe una categoria con este nombre");
                            return false;
                        }
                        else
                        {
                            data.Name = obj.Name;
                            data.Description = obj.Description;
                            Console.WriteLine("Datos modificados exitosamente");
                            return true;
                        }
                    }
                }

            }
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
    }
}
