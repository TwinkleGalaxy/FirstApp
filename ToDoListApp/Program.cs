using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.DB;
using ToDoListApp.Repository;
using ToDoListApp.Service;

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

        public static UserRepository userRep = new UserRepository();
        public static ToDoListRepository toDoListRep = new ToDoListRepository();
        public static ItemDetailsRepository itemDetailsRep = new ItemDetailsRepository();

        public static UserService userService = new UserService();
        public static ToDoListService toDoListService = new ToDoListService();
        public static ItemDetailsService itemDetailsService = new ItemDetailsService();

        static void Main(string[] args)
        {        
            string userChoice = "";
            string username = "";



            List<ToDoList> userToDoLists = new List<ToDoList>();
            List<ItemDetails> toDoListItems = new List<ItemDetails>();

            Console.WriteLine("         TODO List  ");

            while (true) 
            {
                Console.Write("\nPlease enter your username: ");
                username = Console.ReadLine();
                User myUser = new User(username);
                userRep.Add(myUser);
                myUser = userService.SearchIfExisted(myUser); // return user if existed

                Console.WriteLine("\nWelcome {0}", myUser.Username);
                AskingForUserChoice_MainMenu(myUser);
                userChoice = Console.ReadLine();


                if (userChoice == "v") // view all the user's toDoLists
                {
                    userToDoLists = toDoListRep.GetUserToDoLists(myUser).ToList<ToDoList>();
                    
                    // show 
                    for (var i = 1; i <= userToDoLists.Count(); i++)
                    {
                        Console.WriteLine("List#{0}: {1}", i, userToDoLists[i].Title);
                    }

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

                        if (toDoListService.checkToDoListHasItems(userToDoLists[listIndex])) // the list has items
                        {
                            toDoListItems = itemDetailsRep.GetToDoListItems(userToDoLists[listIndex]).ToList<ItemDetails>();
                            // show 
                            ShowItemDetails(toDoListItems);

                            Console.WriteLine("\nDo you want to add another item to the list, view an item details, \nupdate an existed item, or delete an item?");

                            Console.WriteLine("\nIf yes, press 1 for add, 2 for view details, 3 for update, 4 for delete");
                            int.TryParse(Console.ReadLine(), out userAnswer);

                            Item_CRUD(userAnswer, userToDoLists[listIndex], myUser, toDoListItems);           
                        }

                        else // the list has no items
                        {
                            Console.Write("\nThis list has no items.");
                            Console.Write("\nTo add items, Press 1:");
                            AskingForUserChoice_ListMenu(myUser);
                            int.TryParse(Console.ReadLine(), out userAnswer);
                            if (userAnswer == 1)
                            {
                                Item_CRUD(userAnswer, userToDoLists[listIndex], myUser, toDoListItems);
                            }
                        }

                    }
                }
                else if (userChoice == "c") // create list
                {
                    Console.Write("\nEnter the list name: ");
                    string listTitle = Console.ReadLine();
                    ToDoList toDoList = toDoListService.ToDoListFilling(myUser, listTitle);

                    AddingItems(toDoList);

                    AskingForUserChoice_MainMenu(myUser);
                }
                else if (userChoice == "1") // going back to enter another username
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
            if (userService.checkUserHasToDoLists(myUser))
            {
                Console.WriteLine("You have already had {1} \n ", myUser.Username, myUser.ToDoListsIds.Count());
                Console.WriteLine("To view your lists Press: v");
            }
            AskingForUserChoice(myUser);
        }

        private static void AskingForUserChoice(User myUser)
        {
            Console.WriteLine("To create a ToDo list Press: c", myUser.Username);
            Console.WriteLine("To go back Press: 1");
            Console.WriteLine("To end the programm Press: 0");
        }

        private static void ShowItemDetails(List<ItemDetails> toDoListItems)
        {
            for (var i = 1; i <= toDoListItems.Count(); i++)
            {
                Console.WriteLine("Item#{0}: {1}", i, toDoListItems[i].Name);
            }
        }


        private static void AddingItems(ToDoList toDoList)
        {
            Console.WriteLine("\nAdd items:");
            int i = 1;
            do
            {
                Console.Write("\nItem #{0}: ", i);
                string itemName = Console.ReadLine();
                Console.Write("Enter item description: ");
                string itemDescription = Console.ReadLine();

                itemDetailsService.ItemsFilling(toDoList, itemName, itemDescription);

                Console.Write("Add another item? y/n ==> ");
                if (Console.ReadLine() == "n" || Console.ReadLine() == "N")
                    break;
                i++;
            } while (true);
        }

        private static void Item_CRUD(int userAnswer, ToDoList todolist, User myUser, List<ItemDetails> toDoListItems)
        {
            int itemNum;
            switch (userAnswer)
            {
                case 1: // add
                    AddingItems(todolist);
                    break;


                case 2: // view
                    Console.Write("Press the item number: ");
                    int.TryParse(Console.ReadLine(), out itemNum);

                    Console.WriteLine("Item Details: Descripton:", toDoListItems[itemNum-1].Description);
                    break;

                case 3: // update
                    Console.Write("Press the item number: ");
                    int.TryParse(Console.ReadLine(), out itemNum);

                    Console.Write("/nDo you want to update the item name? y/n ==> ");
                    if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
                    {
                        Console.Write("Update item name: ");
                        toDoListItems[itemNum-1].Name = Console.ReadLine();
                    }
                    Console.Write("Update item description: ");
                    toDoListItems[itemNum].Description = Console.ReadLine();

                    itemDetailsRep.Update(itemNum.ToString(), toDoListItems[itemNum-1]);
                    break;

                case 4: // delete
                    Console.Write("Press the item number: ");
                    int.TryParse(Console.ReadLine(), out itemNum);
                    itemDetailsService.DeletingProcess(toDoListItems[itemNum - 1]);
                    todolist.ItemsIds.Remove(toDoListItems[itemNum - 1].Refnum);
                    break;

                default:
                    break;
            }
        }
        private static void ToDoList_CRUD(int userAnswer, ToDoList todolist, User myUser)
        {
            switch (userAnswer)
            {
                case 1: // update
                    Console.Write("Update list title, enter the new list name: ");
                    string listTitle = todolist.Title;
                    todolist.Title = Console.ReadLine();

                    toDoListRep.Update(listTitle, todolist);
                    break;

                case 2: // delete
                    Console.Write("For deleting a list press: d \nFor deleting all the lists press: a");
                    if(Console.ReadLine() == "d")
                    {
                        toDoListService.DeletingProcess(todolist);
                    }
                    if (Console.ReadLine() == "a")
                    {
                        toDoListService.DeletingUserToDoLists(myUser);
                    }

                    break;

                default:
                    break;
            }
        }

        private static void User_CRUD(int userAnswer, User myUser) // there is no add users or view all users beause we have no Admin
        {
            switch (userAnswer)
            {
                case 1: // update
                    Console.Write("Update username, enter your new username: ");
                    string username = myUser.Username;
                    myUser.Username = Console.ReadLine();

                    userRep.Update(username, myUser);
                    break;

                case 2: // delete
                    Console.Write("Delete your account: ");
                    userService.DeletingProcess(myUser);
                    
                    break;

                default:
                    break;
            }
        }

        }
    } 

