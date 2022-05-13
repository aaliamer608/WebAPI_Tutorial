using RepositoryInterfaces;
using DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceInterfaces.DataTransferObjects;
using AutoMapper;

namespace ServiceInterfaces.DataViewModel
{
    public class QuoteService
    {
        public UnitOfWork uow { get; set; }

        public WebApiDBEntities dBEntities;

        MapperConfiguration config;
        IMapper mapper;

        public QuoteService()
        {
            this.dBEntities = new WebApiDBEntities();
            this.uow = new UnitOfWork(dBEntities);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<tblQuote, QuoteDTO>();
                cfg.CreateMap<QuoteDTO, tblQuote>();
            }
            );
            mapper = config.CreateMapper();
        }

        public List<QuoteDTO> GetAllQuotes()
        {
            IEnumerable<tblQuote> quotes = uow.Quotes.GetAll();
            List<QuoteDTO> results = new List<QuoteDTO>();

            foreach (tblQuote quote in quotes)
            {
                QuoteDTO quoteDTO = new QuoteDTO()
                {
                    Quote_ID = quote.Quote_ID,
                    Quote_Type = quote.Quote_Type,
                    Task_Type = quote.Task_Type,
                    Contact_Name = quote.Contact_Name,
                    DueDate = (DateTime)quote.DueDate
                };
                results.Add(quoteDTO);
            }
            uow.Complete();

            return results;
        }




        public IList<QuoteDTO> GetQuoteByID(int id)
        {
            var quotes = uow.Quotes.GetAll();

            var result = (
                from q in quotes
                where q.Quote_ID.Equals(id)
                select new QuoteDTO
                {
                    Quote_ID = q.Quote_ID,
                    Quote_Type = q.Quote_Type,
                    Task_Type = q.Task_Type,
                    DueDate = (DateTime)q.DueDate

                }).ToList();

            uow.Complete();

            return result;
        }



        public QuoteDTO DeleteQuote(int id)
        {
            tblQuote foundQuote = uow.Quotes.GetById(id);
            if (foundQuote != null)
            {
                uow.Quotes.Remove(foundQuote);
                uow.Complete();
                return mapper.Map<QuoteDTO>(foundQuote);
            }
            else
            {
                return null;
            }
        }

        public void PostQuote(QuoteDTO quoteDTO)
        {
            tblQuote quote = mapper.Map<tblQuote>(quoteDTO);
            uow.Quotes.Add(quote);
            uow.Complete();
        }


        public void PutQuote(int id, QuoteDTO quoteDTO)
        {
            uow.Quotes.PutQuote(id, mapper.Map<tblQuote>(quoteDTO));
        }



        public void PatchQuote(int id, QuoteDTO quoteDTO)
        {
            uow.Quotes.PatchQuote(id, mapper.Map<tblQuote>(quoteDTO));
        }
    }
}
