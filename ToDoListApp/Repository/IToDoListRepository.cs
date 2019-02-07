using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Repository
{
    interface IToDoListRepository : IRepository<ToDoList, string>
    {
        IList<ToDoList> GetUserToDoLists(User user);
    }
}
