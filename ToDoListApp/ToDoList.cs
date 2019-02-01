using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public class ToDoList
    {
        private Guid id;
        private string title;
        private string owner;
        private Dictionary<int, ItemDetails> itemdetails;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public Dictionary<int, ItemDetails> Itemdetails
        {
            get { return itemdetails; }
            set { itemdetails = value; }
        }

        public ToDoList()
        { }

        public ToDoList(string username, string listTitle)
        {
            this.id = Guid.NewGuid();
            this.title = listTitle;
            this.owner = username;
            this.itemdetails = new Dictionary<int, ItemDetails>(); // Key: refnum, Value: ItemDetails struct
        }
        public void ShowListItems()
        {
            foreach (var item in itemdetails)
            {
                Console.WriteLine("Item#{0}: {1}", item.Key, item.Value.Name);

            }
        }

        public ToDoList Create(User user, string _listTitle)
        {
            ToDoList newList = new ToDoList(_listTitle, user.Username);
             user.Todolist.Add(newList);
             return newList;
        }

        public void UpdateToDoList(User user, ToDoList newToDoList, int index)
        {
            user.Todolist.Insert(index, newToDoList);
        }

        public void DeleteToDoList(User user, ToDoList toDoList)
        {
            user.Todolist.Remove(toDoList);
        }

    }

}
