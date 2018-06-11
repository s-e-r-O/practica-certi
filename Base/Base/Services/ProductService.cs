using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class ProductService : ICrudable<Product>
    {

        private static ECommerceDB DBConnections = ECommerceDB.Instance;

        public bool Create(Product obj)
        {
            bool check = DBConnections.ProductsList.Any(item => item.Code == obj.Code);
            if (!check) {
                DBConnections.ProductsList.Add(obj);
                return true;
            }
            Console.WriteLine("ERROR while adding product. Product is already on the list");
            return false;
        }

        public bool Delete(string key)
        {
            int index = DBConnections.ProductsList.FindIndex(product => product.Code == key);
            if (index >= 0) {
                DBConnections.ProductsList.RemoveAt(index);
                Console.WriteLine("SUCCESFULLY removed the product of the list");
                return true;
            }
            Console.WriteLine("ERROR while removing product. Product is not on the list!");
            return false;
        }

        public List<Product> Get()
        {
            if (!DBConnections.ProductsList.Any()) //Is empty
            {
                Console.WriteLine("WARNING! No elements inside list of products.");
            }
            Console.WriteLine("SUCCESFULLY returning the list of products.");
            return DBConnections.ProductsList;
        }

        public bool Update(string key, Product obj)
        {
            int index = DBConnections.ProductsList.FindIndex(product => product.Code == key);
            if (index >= 0)
            {
                DBConnections.ProductsList[index] = obj;
                Console.WriteLine("SUCCESFULLY updated the product of the list");
                return true;
            }
            Console.WriteLine("ERROR while updating the product. Product is not on the list!");
            return false;
        }
    }
}
