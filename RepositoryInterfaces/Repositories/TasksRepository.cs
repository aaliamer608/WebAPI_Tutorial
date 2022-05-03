using DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Repositories
{
    public class TasksRepository : GenericRepository<tblTask>, ITasksRepository
    {

        public TasksRepository(WebApiDBEntities dBEntities) : base(dBEntities)
        { 


        }


    }
        
}
