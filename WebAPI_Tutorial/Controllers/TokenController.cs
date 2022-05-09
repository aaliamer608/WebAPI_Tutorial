using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Owin;



namespace WebAPI_Tutorial.Controllers
{
    public class TokenController : ApiController
    {
        [Authorize]
        public IHttpActionResult Authorize()
        {
            return Ok("Authorized");
        }
    }
}
