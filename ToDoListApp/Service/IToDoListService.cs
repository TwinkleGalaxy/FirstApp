using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Service
{
    interface IToDoListService : IService<ToDoList>
    {
        bool checkToDoListHasItems(ToDoList toDoList);
        ToDoList ToDoListFilling(User user, string listTitle);

        void DeletingUserToDoLists(User user);
    }
}
