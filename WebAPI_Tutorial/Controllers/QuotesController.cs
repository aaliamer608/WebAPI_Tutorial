using AutoMapper;
using ServiceInterfaces.DataTransferObjects;
using ServiceInterfaces.DataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Tutorial;


namespace WebAPI_Tutorial.Controllers
{
    public class QuotesController : ApiController
    {

        MapperConfiguration config;
        IMapper mapper;
        QuoteService quoteService;


        public QuotesController()
        {
            quoteService = new QuoteService();
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuoteDTO, QuoteService>();
                cfg.CreateMap<QuoteService, QuoteDTO>();
                //cfg.CreateMap
            });
            mapper = config.CreateMapper();
        }
        //GET All quotes
        [HttpGet]
        public IEnumerable<QuoteDTO> GetQuotes()
        {
            return quoteService.GetAllQuotes();
        }

        //GET Quote by id
        [HttpGet]
        public IEnumerable<QuoteDTO> GetQuotesByID(int id)
        {
            return quoteService.GetQuoteByID(id);
        }

        //DELETE Quote
        [HttpDelete]
        public HttpResponseMessage DeleteQuote(int id)
        {

            var target = quoteService.GetQuoteByID(id);

            try
            {
                if (target != null)
                {
                    quoteService.DeleteQuote(id);
                    return Request.CreateResponse(HttpStatusCode.OK);

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Quote with Id = " + id.ToString() + " not found to delete");

                }
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //POST Quote
        [HttpPost]
        public void PostQuote([FromBody] QuoteDTO quoteModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    QuoteDTO quoteDTO = mapper.Map<QuoteDTO>(quoteModel);
                    quoteService.PostQuote(quoteDTO);

                }
                catch (Exception)
                {
                    BadRequest();
                }
            }
        }

        //PUT Quote
        [HttpPut]
        public void PutQuote(int id, [FromBody] QuoteDTO quoteModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    quoteService.PutQuote(id, quoteModel);
                    Request.CreateResponse(HttpStatusCode.OK);

                }
                catch (Exception ex)
                {
                    Request.CreateErrorResponse(HttpStatusCode.NotFound,
    "Employee with Id " + id.ToString() + " not found to update");
                }
            }
        }


        //PATCH Quote
        [HttpPatch]
        public IHttpActionResult PatchQuote([FromUri] int id, [FromBody] QuoteService quoteModel)
        {
            if (quoteModel == null)
            {
                return BadRequest("Nothing To Patch");

            }
            else
            {
                QuoteDTO quoteDTO = mapper.Map<QuoteDTO>(quoteModel);
                quoteService.PatchQuote(id, quoteDTO);
                return Ok(quoteService.GetQuoteByID(id));

            }
        }
    }
}