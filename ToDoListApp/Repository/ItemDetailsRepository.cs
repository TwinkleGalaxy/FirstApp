using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Repository
{
    class ItemDetailsRepository
    {
        public IList<ItemDetails> GetToDoListItems(ToDoList toDoList)
        {
            IList<ItemDetails> toDoListItems = new List<ItemDetails>();
            for (var i = 0; i < toDoList.ItemsRefNums.Count(); i++)
            {
                DB.DB.ItemDetailsMap.First(x => x.Key == toDoList.ItemsRefNums[i]);
            }
            return toDoListItems;
        }

        public IList<ItemDetails> GetAll()
        {
            IList<ItemDetails> itemDetailsList = new List<ItemDetails>();
            foreach (var item in DB.DB.ItemDetailsMap)
            {
                itemDetailsList.Add(item.Value);
            }
            return itemDetailsList;
        }

        public ItemDetails GetByName(string refnum)
        {
            ItemDetails itemDetails;
            DB.DB.ItemDetailsMap.TryGetValue(refnum, out itemDetails);
            return itemDetails;
        }
        public void Add(ItemDetails itemDetails)
        {
            DB.DB.ItemDetailsMap.Add(itemDetails.Refnum, itemDetails);
        }

        public void Update(string itemname, ItemDetails newItemDetails)
        {
            DB.DB.ItemDetailsMap[itemname] = newItemDetails;
        }

        public void Delete(string refnum)
        {
            DB.DB.ItemDetailsMap.Remove(refnum);
        }
    }
}
