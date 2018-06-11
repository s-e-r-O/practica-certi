using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class UserService : ICrudable<User>
    {
        private readonly ECommerceDB _dbContext = ECommerceDB.Instance;

        public bool Create(User obj)
        {
            if (_dbContext.UsersList.Exists(user => { return user.Username == obj.Username; }))
            {
                Console.WriteLine("The user '" + obj.Username +"' already exist.");
                return false;
            }
            _dbContext.UsersList.Add(obj);  
            return true;

       }

        public bool Delete(string key)
        {
            int index;
            if((index = _dbContext.UsersList.FindIndex(user => { return user.Username == key; } ))< 0)
            {
                Console.WriteLine("The user'" + key + "'does not exist.");
                return false;
            }
            _dbContext.UsersList.RemoveAt(index);
            return true;
        }

        public List<User> Get()
        {
            return _dbContext.UsersList;
        }

        public bool Update(string key, User obj)
        {
            int index;
            if ((index = _dbContext.UsersList.FindIndex(user => { return user.Username == key; })) < 0)
            {
                Console.WriteLine("The user '" + key + "' does not exist.");
                return false;
            }
            if (_dbContext.UsersList.Exists(user => { return user.Username == obj.Username; }))
            {
                Console.WriteLine("The keys do not match. ( '" + key + "' != '" + obj.Username + "' )");
                return false;
            }
            _dbContext.UsersList[index] = obj;
            return true;
        }
        public void Show()
        {
            Console.WriteLine("======== USER LIST ========");
            this.Get().ForEach(user => { user.Show(); });
            Console.WriteLine("---------------------------");
        }
    }
}
