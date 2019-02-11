using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Service
{
    interface IService<T>
    {
        T SearchIfExisted(T t);
        void DeletingProcess(T t);
    }
}
