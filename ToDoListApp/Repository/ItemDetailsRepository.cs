using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Repository
{
    class ItemDetailsRepository
    {
        public IList<ItemDetails> GetToDoListItems(ToDoList todolist)
        {
            return DB.DB.ItemDetailsMap.Values.Where(x => x.ListId == todolist.Id).ToList<ItemDetails>();
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

        public ItemDetails GetByNum(string itemname)
        {
            ItemDetails itemDetails;
            DB.DB.ItemDetailsMap.TryGetValue(itemname, out itemDetails);
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

        public void Delete(ItemDetails itemDetails)
        {
            DB.DB.ItemDetailsMap.Remove(itemDetails.Refnum);
        }
    }
}
