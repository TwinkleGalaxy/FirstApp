using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.DB
{
    public static class DB
    {
        private static Dictionary<string, User> usersMap;
        private static List<ToDoList> toDoListsList;
        private static Dictionary<string, ItemDetails> itemDetailsMap;

        public static Dictionary<string, User> UsersMap
        {
            get { return DB.usersMap; }
        }

        public static List<ToDoList> ToDoListsList
        {
            get { return DB.toDoListsList; }
        }

        public static Dictionary<string, ItemDetails> ItemDetailsMap
        {
            get { return DB.itemDetailsMap; }
        }
    }
}
