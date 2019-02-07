using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Repository
{
    interface IUserRepository : IRepository<User, string>
    {
    }
}
