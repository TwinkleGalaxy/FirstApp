using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Service
{
    interface IItemDetailsService : IService<ItemDetails, string>
    {
        ItemDetails ItemsFilling(ToDoList toDoList, string itemName, string itemDescription);

        IList<ItemDetails> GetToDoListItems(ToDoList toDoList);

        void DeletingToDoListItems(ToDoList toDoList);
    }
}
