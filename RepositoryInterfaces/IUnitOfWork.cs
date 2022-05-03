using RepositoryInterfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IUsersRepository Users { get; }
        ITasksRepository Tasks { get; }



        
        int Complete();
    }
}
