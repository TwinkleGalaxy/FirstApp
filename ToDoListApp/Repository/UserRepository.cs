using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.DB;

namespace ToDoListApp.Repository
{
    class UserRepository : IUserRepository
    {
        public IList<User> GetAll()
        {
            IList<User> usersList = new List<User>();
            foreach(var user in DB.DB.UsersMap)
            {
                usersList.Add(user.Value);
            }
            return usersList;
        }

        public User GetByName(string username)
        {
            User user;
            DB.DB.UsersMap.TryGetValue(username, out user);
            return user;
        }
        public void Add(User user)
        {
            DB.DB.UsersMap.Add(user.Username, user);
        }

        public void Update(string username, User user)
        {
            DB.DB.UsersMap[username] = user;
        }

        public void Delete(string username)
        {
            DB.DB.UsersMap.Remove(username);
        }
    }
}
