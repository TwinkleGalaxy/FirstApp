using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    public class User
    {
        private string id;
        private string username;
        private List<string> toDoListsIds;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public List<string> ToDoListsIds
        {
            get { return toDoListsIds; }
            set { toDoListsIds = value; }
        }

        public User(string _username) 
        {
            this.id = Guid.NewGuid().ToString();
            this.username = _username;
            this.toDoListsIds = new List<string>();
        }
    }

}
