using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Repository
{
    interface IItemDetailsRepository : IRepository<ItemDetails, string>
    {
        IList<ItemDetails> GetToDoListItems(ToDoList todolist);
    }
}
