using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public class ToDoList
    {
        private string id;
        private string title;
        private string userId;
        private List<string> itemsIds;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public List<string> ItemsIds
        {
            get { return itemsIds; }
            set { itemsIds = value; }
        }

        public ToDoList(string userId, string listTitle)
        {
            this.id = Guid.NewGuid().ToString();
            this.title = listTitle;
            this.userId = userId;
            this.itemsIds = new List<string>();
        }
    }

}
