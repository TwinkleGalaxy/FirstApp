using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Repository;
using ToDoListApp.DB;

namespace ToDoListApp.Service
{
    class UserService : IUserService
    {
        public static UserRepository userRep = new UserRepository();
        public static ToDoListRepository toDoListRep = new ToDoListRepository();
        public static ItemDetailsRepository itemDetailsRep = new ItemDetailsRepository();

        public static ToDoListService toDoListService = new ToDoListService();

        // Search if the user is already existed
        public User Get(string username)
        {
            User user = null;
            if (DB.DB.UsersMap.Count >= 1)
            {
                user = userRep.GetByName(username);
            }
            if (user != null) // if found
            {
                return user;
            } 
            // if not found or the may is empty
            user = new User(username);
            userRep.Add(user);
            user.Username = "NewUser";
            return user;
        }

        public bool checkUserHasToDoLists(User myUser)
        {
            if (myUser.ToDoListsIds.Count() == 0)
            {
                return false;
            }
            return true;
        }

        public void Update(string username, User user)
        {
            userRep.Update(username, user);
        }

        public void DeletingProcess(User myUser)
        {
            toDoListService.DeletingUserToDoLists(myUser);
            userRep.Delete(myUser);
        }
    }

   
}
