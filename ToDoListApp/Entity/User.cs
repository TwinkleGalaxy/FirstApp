using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    public class User
    {
        private string id;
        private string username;
        private List<string> todolistsIds;

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

        public List<string> TodolistIds
        {
            get { return todolistsIds; }
        }
        public User(string _username) 
        {
            this.id = Guid.NewGuid().ToString();
            this.username = _username;
            this.todolistsIds = new List<string>();
        }
    }

}
