﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Repository;
using ToDoListApp.DB;

namespace ToDoListApp.Service
{
    class ToDoListService : IToDoListService
    {
        public static UserRepository userRep = new UserRepository();
        public static ToDoListRepository toDoListRep = new ToDoListRepository();
        public static ItemDetailsRepository itemDetailsRep = new ItemDetailsRepository();

        public static ItemDetailsService itemDetailsService = new ItemDetailsService();

        public ToDoList Get(string todolistTitle)
        {
            return toDoListRep.GetByName(todolistTitle);
        }
        public bool checkToDoListHasItems(ToDoList todolist)
        {
            if (todolist.ItemsIds.Count() == 0)
            {
                return false;
            }
            return true;
        }
        
        public IList<ToDoList> GetUserToDoLists(User user)
        {
            return toDoListRep.GetUserToDoLists(user);
        }

        public ToDoList ToDoListFilling(User myUser, string listTitle)
        {
            ToDoList toDoList = new ToDoList(myUser.Username, listTitle);
            toDoListRep.Add(toDoList);
            myUser.ToDoListsIds.Add(toDoList.Id);
            return toDoList;
        }
        public void Update(string toDoListTitle, ToDoList toDoList)
        {
            toDoListRep.Update(toDoListTitle, toDoList);
        }

        public void DeletingProcess(ToDoList todolist)
        {
            itemDetailsService.DeletingToDoListItems(todolist);
            toDoListRep.Delete(todolist);
        }

        public void DeletingUserToDoLists(User user)
        {
            List<ToDoList> myUserToDoLists = toDoListRep.GetUserToDoLists(user).ToList<ToDoList>();

            foreach (var todolist in myUserToDoLists)
            {
                itemDetailsService.DeletingToDoListItems(todolist);
                toDoListRep.Delete(todolist);
            }
        }



    }
}
