using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public class ItemDetails
    {
        private int refnum;
        private string name;
        private string description;

        public int Refnum
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

        public ItemDetails()
        {}
        public ItemDetails(string _name, string _description)
        {
            this.name = _name;
            this.description = _description;
        }

        public void ShowItemDetails(int _refnum)
        {
            Console.WriteLine("Item#{0}: {1} \nItem Description: {2}.", refnum, name, description);
        }

    }
}
