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
            get
            { 
                if (DB.usersMap == null)
                {
                    return new Dictionary<string, User>();
                }
                return DB.usersMap; 
            }
        }

        public static List<ToDoList> ToDoListsList
        {
            get 
            {
                if (DB.toDoListsList == null)
                {
                    return new List<ToDoList>();
                }
                return DB.toDoListsList; 
            }
        }

        public static Dictionary<string, ItemDetails> ItemDetailsMap
        {
            get 
            {
                if (DB.itemDetailsMap == null)
                {
                    return new Dictionary<string, ItemDetails>();
                }
                return DB.itemDetailsMap; 
            }
        }
    }
}
