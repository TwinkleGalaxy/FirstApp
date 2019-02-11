using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Repository
{
    class ToDoListRepository : IToDoListRepository
    {
        public IList<ToDoList> GetUserToDoLists(User user)
        {
            return DB.DB.ToDoListsList.Where(x => x.UserId == user.Id).ToList<ToDoList>();
        }
        public IList<ToDoList> GetAll()
        {
            return DB.DB.ToDoListsList;
        }

        public ToDoList GetByName(string listTitle)
        {
            return DB.DB.ToDoListsList.Find(x => x.Title == listTitle);
        }
        public void Add(ToDoList toDoList)
        {
            DB.DB.ToDoListsList.Add(toDoList);
        }

        public void Update(string listTitle, ToDoList newToDoList)
        {
            var index = DB.DB.ToDoListsList.IndexOf(GetByName(listTitle));
            DB.DB.ToDoListsList[index] = newToDoList;
        }

        public void Delete(ToDoList todolist)
        {
            DB.DB.ToDoListsList.Remove(todolist);
        }
    }
}
