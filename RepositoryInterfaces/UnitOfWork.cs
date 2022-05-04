using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryInterfaces.Repositories;
using DomainEntities.Models;

namespace RepositoryInterfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebApiDBEntities _dbContext;
        public UnitOfWork(WebApiDBEntities dbContext)
        {
            _dbContext = dbContext;
            Users = new UsersRepository(_dbContext);
            Tasks = new TasksRepository(_dbContext);
        }


        public IUsersRepository Users { get; set; }

        public ITasksRepository Tasks { get; set; }


        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
