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
        public User SearchIfExisted(User myUser)
        {
            UserRepository userRep = new UserRepository();
            User user = null;
            if (DB.DB.UsersMap.Count > 1)
            {
                user = userRep.GetByName(myUser.Username);
            }
            if (user != null)
            {
                return user;
            }
            return myUser;
        }

        public bool checkUserHasToDoLists(User myUser)
        {
            if (myUser.ToDoListsIds.Count() == 0)
            {
                return false;
            }
            return true;
        }

        public void DeletingProcess(User myUser)
        {
            toDoListService.DeletingUserToDoLists(myUser);
            userRep.Delete(myUser);
        }
    }

   
}
