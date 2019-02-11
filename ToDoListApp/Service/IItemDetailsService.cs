using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Service
{
    interface IItemDetailsService : IService<ItemDetails>
    {
        ItemDetails ItemsFilling(ToDoList toDoList, string itemName, string itemDescription);

        void DeletingToDoListItems(ToDoList toDoList);
    }
}
