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
            IList<ToDoList> userToDoLists = new List<ToDoList>();
            for (var i = 0; i < user.TodolistIds.Count(); i++)
            {
                DB.DB.ToDoListsList.First(x => x.Id == user.TodolistIds[i]);
            }
            return userToDoLists;
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

        public void Delete(string listTitle)
        {
            DB.DB.ToDoListsList.Remove(GetByName(listTitle));
        }
    }
}
