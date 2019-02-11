using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public class ItemDetails
    {
        private string refnum;
        private string name;
        private string description;
        private string listId;

        public string Refnum
        {
            get { return refnum; }
            set { refnum = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string ListId
        {
            get { return listId; }
            set { listId = value; }
        }

        public ItemDetails(string _name, string _description, string _listId)
        {
            this.refnum = Guid.NewGuid().ToString();
            this.name = _name;
            this.description = _description;
            this.listId = _listId;
        }
    }
}
