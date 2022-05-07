using DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Repositories
{
    public class QuotesRepository : GenericRepository<tblQuote>, IQuotesRepository
    {

        public QuotesRepository(WebApiDBEntities dBEntities) : base(dBEntities)
        {


        }


        public void PutQuote(int id, tblQuote quote)
        {
            using (var db = new WebApiDBEntities())
            {
                var result = db.tblQuotes.SingleOrDefault(q => q.Quote_ID == id);
                if (result != null)
                {
                    result.Quote_Type = quote.Quote_Type;
                    result.Task_Type = quote.Task_Type;
                }
                db.SaveChanges();
            }
        }




        public void PatchQuote(int id, tblQuote quote)
        {
            using (var db = new WebApiDBEntities())
            {
                var result = db.tblQuotes.SingleOrDefault(q => q.Quote_ID == id);
                
                if (result != null)
                {
                    var target = quote.Quote_Type;
                    if (target != null)
                    {
                        result.Quote_Type = target;
                    }

                    var target2 = quote.Task_Type;
                    if (target2 != null)
                    {
                        result.Quote_Type = target2;
                    }
                }
                db.SaveChanges();
            }
        }
    }
}