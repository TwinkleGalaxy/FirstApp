using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    class Program
    {
        //private enum MainMenuAction
        //{
        //    exit = 0,
        //    viewLists = 1,
        //    creatList = 2,
        //    repeat = 3
        //}
        static void Main(string[] args)
        {        
            string userChoice = "";
            string username = "";
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

                Console.WriteLine("\nWelcome {0}", myUser.Username);
                AskingForUserChoice(myUser);
                userChoice = Console.ReadLine();

                    if (userChoice == "1")
                    {

                    }
                    else if (userChoice == "2")
                    {
                        ListFilling(myUser, toDoList);
                        AskingForUserChoice(myUser);
                    }
                    else if (userChoice == "3")
                    {
                        continue;
                    }
                    else if (userChoice == "0")
                    {
                        break;
                    }

                }
            }

        private static void AskingForUserChoice(User myUser)
        {
            if (myUser.Todolist.Count() != 0)
            {
                Console.WriteLine("You have already had {1} \n ", myUser.Username, myUser.Todolist.Count());
                Console.WriteLine("To view your lists Press: 1");
            }
            Console.WriteLine("To create a new ToDo list Press: 2", myUser.Username);
            Console.WriteLine("To go back Press: 3");
            Console.WriteLine("To end the programm Press: 0");
        }

        private static void ListFilling(User myUser, ToDoList toDoList)
        {
            Console.WriteLine("");
            Console.Write("Enter the list name: ");
            string listTitle = Console.ReadLine();
            toDoList = toDoList.Create(myUser, listTitle);
            Console.WriteLine("");
            Console.WriteLine("Add items:");
            int i = 1;
            do
            {
                Console.WriteLine("");
                Console.Write("Item #{0}: ", i);
                ItemDetails itemdetails = new ItemDetails();
                itemdetails.Name = Console.ReadLine();
                Console.Write("Enter item description: ");
                itemdetails.Description = Console.ReadLine();

                toDoList.Itemdetails.Add(i, itemdetails);
                i++;

                Console.Write("Add another item? y/n ==> ");
            } 
            while (Console.ReadLine() != "n" || Console.ReadLine() != "N");
        }
        }
    }
