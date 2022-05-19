using AutoMapper;
using ServiceInterfaces.DataTransferObjects;
using ServiceInterfaces.DataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI_Tutorial;


namespace WebAPI_Tutorial.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {

        MapperConfiguration config;
        IMapper mapper;
        UserService userService;
        //TaskServices categoryService;


        public UsersController()
        {
            userService = new UserService();
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, UserService>();
                //cfg.CreateMap
            });
            mapper = config.CreateMapper();
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            return userService.getAllUsers();
        }


        [HttpGet]
        public IEnumerable<UserDTO> GetUsersByID(int id)
        {
            return userService.getUserByID(id);
        }


        //POST Quote
        [HttpPost]
        public void PostUser([FromBody] UserDTO userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserDTO userDTO = mapper.Map<UserDTO>(userModel);
                    userService.PostUser(userDTO);

                }
                catch (Exception)
                {
                    BadRequest();
                }
            }
        }




        //PATCH
        //DELETE
        //PUT

    }
}