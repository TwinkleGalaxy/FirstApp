using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Service
{
    interface IService<T, Key>
    {
        T Get(Key key);

        void Update(Key key, T t);

        void DeletingProcess(T t);
    }
}
