using ServiceInterfaces.DataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_Tutorial.Controllers
{
    public class AccountController : ApiController
    {
        private readonly UserService userService;
        public AccountController()
        {
        }
    }
}
