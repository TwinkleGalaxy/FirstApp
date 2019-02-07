using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Repository
{
    interface IRepository<T, Key>
    {
        IList<T> GetAll();

        T GetByName(Key key);
        void Add(T t);

        void Update(Key key, T t);

        void Delete(Key key);
    }
}
