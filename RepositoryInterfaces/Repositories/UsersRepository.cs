using DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Repositories
{
    public class UsersRepository : GenericRepository<UserMaster>, IUsersRepository
    {

        public UsersRepository(WebApiDBEntities dBEntities) : base(dBEntities)
        {


        }


    }

}
