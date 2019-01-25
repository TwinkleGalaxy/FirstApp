using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    public class User
    {
        private Guid id;
        private string username;
        private List<ToDoList> todolist;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public List<ToDoList> Todolist
        {
            get { return todolist; }
            set { todolist = value; }
        }

        public User() { }
        public User(string _username) 
        {
            this.id = Guid.NewGuid();
            this.username = _username;
            this.todolist = new List<ToDoList>();
        }

        public void GetUserInfoByUserName(Dictionary<string, User> UsersMap, out User user)
        {
            UsersMap.TryGetValue(username, out user);
        }

        public User CreateUser(string _username, Dictionary<string, User> UsersMap)
        {
            User newUser = new User(_username);
            UsersMap.Add(_username, newUser);

            return newUser;
        }

        public User UpdateUser(User myUser)
        {
            return myUser;
        }

        public void DeleteUser(Dictionary<string, User> usersMap, string _username)
        {
            usersMap.Remove(_username);
        }
    }

}
