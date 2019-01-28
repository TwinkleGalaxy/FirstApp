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

        public void ShowAllUserLists()
        {
            for (var i = 0; i < todolist.Count; i++)
            {
                // Console.WriteLine($"List#{todolist[i]}: todolist[i].Title"); // VS 2013 doesn't support c#6 - string interpolation 
                Console.WriteLine("List#{0}: {1}", todolist[i], todolist[i].Title);
            }
        }

        public User GetUserInfoByUserName(Dictionary<string, User> UsersMap)
        {
            User user = new User();
            UsersMap.TryGetValue(username, out user);
            return user;
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
