using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Service
{
    interface IToDoListService : IService<ToDoList, string>
    {
        bool checkToDoListHasItems(ToDoList toDoList);
        ToDoList ToDoListFilling(User user, string listTitle);
        
        IList<ToDoList> GetUserToDoLists(User user);

        void DeletingUserToDoLists(User user);
    }
}
