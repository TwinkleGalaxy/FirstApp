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
        private string userName;
        private List<string> itemsRefNums;

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

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public List<string> ItemsRefNums
        {
            get { return itemsRefNums; }
        }


        public ToDoList(string username, string listTitle)
        {
            this.id = Guid.NewGuid().ToString();
            this.title = listTitle;
            this.userName = username;
            this.itemsRefNums = new List<string>();
        }
    }

}
