using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    class Program
    {
        static void Main(string[] args)
        {        
            string answer = "";
            string username = "";
            string listTitle = "";
            var UsersMap = new Dictionary<string, User>();
            ToDoList toDoList = new ToDoList();

            Console.WriteLine("         TODO List  ");

            while (true) 
            {
                Console.Write("\nPlease enter your username: ");
                username = Console.ReadLine();
                User myUser = new User(username);

                if (UsersMap.Count != 0) // Search if the user is already existed
                {
                    myUser = myUser.GetUserInfoByUserName(UsersMap);
                }
                else
                {
                    myUser = myUser.CreateUser(username, UsersMap);
                }

                if (myUser.Todolist.Count() != 0)
                {
                    Console.WriteLine("\nWelcome {0}, you have already had {1} \n To view your lists Press: 2",
                        myUser.Username, myUser.Todolist.Count());
                    Console.WriteLine("To create a new ToDo list Press: 1", myUser.Username);
                    Console.WriteLine("To end the programm Press: 0");
                }
                else
                {
                    Console.WriteLine("\nWelcome {0}, To create your first ToDo list Press: 1", myUser.Username);
                    Console.WriteLine("To go back Press: 2");
                    Console.WriteLine("To end the programm Press: 0");
                }


                    answer = Console.ReadLine();

                    if (answer == "0")
                    {
                        break;
                    }
                    else if (answer == "1")
                    {
                        Console.Write("Enter the list name: ");
                        listTitle = Console.ReadLine();
                        toDoList.Create(myUser, listTitle);
                    }
                    else if (answer == "2")
                    {
                        continue;
                    }

                }
            } 
            
        }
    }
