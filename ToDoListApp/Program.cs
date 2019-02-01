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
            var toDoList = new ToDoList();
            var itemDetailsMap = new Dictionary<int, ItemDetails>();

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
                AskingForUserChoice_MainMenu(myUser);
                userChoice = Console.ReadLine();

                if (userChoice == "1") // view all the lists
                {
                    myUser.ShowAllUserLists();

                    Console.Write("Do you want to view a list items? y/n ==> ");
                    if (Console.ReadLine() == "n" || Console.ReadLine() == "N")
                    {
                        AskingForUserChoice(myUser);
                    }
                    else
                    {
                        Console.Write("Enter the list number: ");
                        int userAnswer;
                        int.TryParse(Console.ReadLine(), out userAnswer);
                        int listIndex = userAnswer - 1;

                        if (myUser.Todolist[listIndex].Itemdetails.Count() == 0) // the list has no items
                        {
                            Console.Write("\nThis list has no items.");
                            Console.Write("\nTo add items, Press 1:");
                            AskingForUserChoice_ListMenu(myUser);
                            int.TryParse(Console.ReadLine(), out userAnswer);
                            if (userAnswer == 1)
                            {
                                Item_CRUD(userAnswer, listIndex, myUser);
                            }
                        }

                        else // the list has items
                        {
                            myUser.Todolist[listIndex].ShowListItems();
                            Console.WriteLine("\nDo you want to add another item to the list, view an item details, \nupdate an existed item, or delete an item?");

                            Console.WriteLine("\nIf yes, press 1 for add, 2 for view details, 3 for update, 4 for delete");
                            int.TryParse(Console.ReadLine(), out userAnswer);

                            Item_CRUD(userAnswer, listIndex, myUser);
                        }

                    }
                }
                else if (userChoice == "2") // create list
                {
                    ListFilling(myUser, toDoList);
                    AskingForUserChoice_MainMenu(myUser);
                }
                else if (userChoice == "3") // going back to enter another username
                {
                    continue;
                }
                else if (userChoice == "0") // exit the program
                {
                    break;
                }

                }
            }

        private static void AskingForUserChoice_ListMenu(User myUser)
        {
            Console.WriteLine("To view another list Press: 4");
            AskingForUserChoice(myUser);
        }

        private static void AskingForUserChoice_MainMenu(User myUser)
        {
            if (myUser.Todolist.Count() != 0)
            {
                Console.WriteLine("You have already had {1} \n ", myUser.Username, myUser.Todolist.Count());
                Console.WriteLine("To view your lists Press: 1");
            }
            AskingForUserChoice(myUser);
        }

        private static void AskingForUserChoice(User myUser)
        {
            Console.WriteLine("To create a new ToDo list Press: 2", myUser.Username);
            Console.WriteLine("To go back Press: 3");
            Console.WriteLine("To end the programm Press: 0");
        }

        private static void ListFilling(User myUser, ToDoList toDoList)
        {
            Console.Write("\nEnter the list name: ");
            string listTitle = Console.ReadLine();
            toDoList = toDoList.Create(myUser, listTitle);
            AddingItems(myUser, toDoList);
        }

        private static void AddingItems(User myUser, ToDoList toDoList)
        {
            Console.WriteLine("\nAdd items:");
            int i = 1;
            do
            {
                Console.Write("\nItem #{0}: ", i);
                ItemDetails itemdetails = new ItemDetails();
                itemdetails.Name = Console.ReadLine();
                Console.Write("Enter item description: ");
                itemdetails.Description = Console.ReadLine();

                toDoList.Itemdetails.Add(i, itemdetails);

                Console.Write("Add another item? y/n ==> ");
                if (Console.ReadLine() == "n" || Console.ReadLine() == "N")
                    break;
                i++;
            } while (true);
        }

        private static void Item_CRUD(int userAnswer, int listIndex, User myUser)
        {
            int itemNum;
            //if (userAnswer != 1)
            //{
            //    Console.Write("Press the item number: ");
            //    int.TryParse(Console.ReadLine(), out itemNum);
            //}
            switch (userAnswer)
            {
                case 1: // add
                    AddingItems(myUser, myUser.Todolist[listIndex]);
                    break;


                case 2: // view
                    Console.Write("Press the item number: ");
                    int.TryParse(Console.ReadLine(), out itemNum);

                    myUser.Todolist[listIndex].Itemdetails[itemNum].ShowItemDetails();
                    break;

                case 3: // update
                    Console.Write("Press the item number: ");
                    int.TryParse(Console.ReadLine(), out itemNum);

                    ItemDetails newItemDetails = new ItemDetails();
                    newItemDetails.Refnum = itemNum;

                    Console.Write("/nDo you want to update the item name? y/n ==> ");
                    if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
                    {
                        Console.Write("Update item name: ");
                        newItemDetails.Name = Console.ReadLine();
                    }
                    Console.Write("Update item description: ");
                    newItemDetails.Description = Console.ReadLine();

                    myUser.Todolist[listIndex].Itemdetails[itemNum].UpdateItem(myUser, listIndex, newItemDetails, itemNum);
                    break;

                case 4: // delete
                    Console.Write("Press the item number: ");
                    int.TryParse(Console.ReadLine(), out itemNum);
                    myUser.Todolist[listIndex].Itemdetails[itemNum].ShowItemDetails();
                    break;

                default:
                    break;
            }
        }
        }
    } 

// Remaining List CRUD & User CRUD
