using System;
using System.Collections.Generic;
using DomainEntities.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace RepositoryInterfaces.Repositories
{
    public interface IQuotesRepository : IGenericRepository<tblQuote>
    {
        void PutQuote(int id, tblQuote tblQuote);


        void PatchQuote(int id, tblQuote tblQuote);
    }
}
