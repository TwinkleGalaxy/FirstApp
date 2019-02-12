using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Service
{
    interface IUserService : IService<User, string>
    {
        bool checkUserHasToDoLists(User user);
    }
}
