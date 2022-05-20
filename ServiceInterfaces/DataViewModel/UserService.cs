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
    public class UserService
    {
        public UnitOfWork uow { get; set; }

        public WebApiDBEntities dBEntities;

        MapperConfiguration config;
        IMapper mapper;

        public UserService()
        {
            this.dBEntities = new WebApiDBEntities();
            this.uow = new UnitOfWork(dBEntities);
            
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<tblUser, UserDTO>();
                cfg.CreateMap<UserDTO, tblUser>();
            }
            );
            mapper = config.CreateMapper();
        }

        public List<UserDTO> getAllUsers()
        {
            IEnumerable<tblUser> users = uow.Users.GetAll();
            List<UserDTO> results = new List<UserDTO>();

            foreach (tblUser user in users)
            {
                UserDTO userDTO = new UserDTO()
                {
                    UserID = user.UserID,
                    UserName = user.UserName,
                    UserPassword = user.UserPassword,
                    UserEmailID = user.UserEmailID,
                    UserRoles = user.UserRoles
                };
                results.Add(userDTO);
            }
            uow.Complete();

            return results;
        }




        public IEnumerable<UserDTO> getUserByID(int id)
        {
            var user = uow.Users.GetAll();

            var result = (
                from u in user
                where u.UserID.Equals(id)
                select new UserDTO
                {
                    UserName = u.UserName,
                    UserEmailID = u.UserEmailID,
                    UserRoles = u.UserRoles
                }).ToList();

            uow.Complete();

            return result;


        }

        public void PostUser(UserDTO userDTO)
        {
            tblUser user = mapper.Map<tblUser>(userDTO);
            uow.Users.Add(user);
            uow.Complete();
        }




        public UserDTO ValidateUser(string username, string password)
        {
            var user = uow.Users.GetAll();
            var retu = user.Where(x => x.UserName == username && x.UserPassword == password).Select(x => new UserDTO
            {
                UserID = x.UserID,
                UserEmailID = x.UserEmailID,
                UserPassword = x.UserPassword,
                UserName = x.UserName
            }).FirstOrDefault<UserDTO>();

            return retu;
        }
        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
