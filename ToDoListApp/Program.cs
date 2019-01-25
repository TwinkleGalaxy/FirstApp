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

            Console.WriteLine("         TODO List  ");

            while (true) 
            {
                Console.Write("\nPlease enter your username: ");
                username = Console.ReadLine();
                User myUser = new User();
                ToDoList toDoList = new ToDoList();

                if (UsersMap.Count != 0) // Search if the user is already existed
                {
                    myUser.GetUserInfoByUserName(UsersMap, out myUser);
                }
                else
                {
                    myUser = myUser.CreateUser(username, UsersMap);
                }

                
                    if (myUser.Todolist.Count() != 0)
                    {

                    }
                    Console.WriteLine("");
                    Console.WriteLine("\nTo create your first ToDo list Press: 1");
                    Console.WriteLine("To go back Press: 2");
                    Console.WriteLine("To end the programm Press: 0");

                    answer = Console.ReadLine();

                    if (answer == "2")
                    {
                        continue;
                    }
                    else if (answer == "0")
                    {
                        break;
                    }
                    else if (answer == "1")
                    {
                        Console.WriteLine("Please enter the list name: ");
                        listTitle = Console.ReadLine();
                        toDoList.Create(myUser, listTitle);
                    }
                    else
                        Console.WriteLine("Please enter: \n1 for creating a ToDo list, 2 for going back, or 0 for ending the program");

                }
            } 
            
        }
    }
