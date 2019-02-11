using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Repository;
using ToDoListApp.DB;

namespace ToDoListApp.Service
{
    class ItemDetailsService : IItemDetailsService
    {
        public static ToDoListRepository toDoListRep = new ToDoListRepository();
        public static ItemDetailsRepository itemDetailsRep = new ItemDetailsRepository();

        public ItemDetails SearchIfExisted(ItemDetails itemDetails)
        {
            return itemDetails;
        }
        public ItemDetails ItemsFilling(ToDoList toDoList, string itemName, string itemDescription)
        {

            ItemDetails itemDetails = new ItemDetails(itemName, itemDescription, toDoList.Title);
            itemDetailsRep.Add(itemDetails);
            toDoList.ItemsIds.Add(itemDetails.Refnum);

            toDoListRep.Update(toDoList.Title, toDoList);

            return itemDetails;
        }

        public void DeletingProcess(ItemDetails itemDetails)
        {
            itemDetailsRep.Delete(itemDetails);
        }

        public void DeletingToDoListItems(ToDoList todolist)
        {
            if (todolist.ItemsIds.Count() != 0)
            {
                List<ItemDetails> itemDetailsList = itemDetailsRep.GetToDoListItems(todolist).ToList<ItemDetails>();
                foreach (var item in itemDetailsList)
                {
                    itemDetailsRep.Delete(item);
                    todolist.ItemsIds.Remove(item.Refnum);
                }
            }
        }
    }
}
