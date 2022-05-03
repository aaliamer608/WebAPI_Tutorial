using RepositoryInterfaces;
using DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceInterfaces.DataTransferObjects;

namespace ServiceInterfaces.DataViewModel
{
    public class UserService
    {
        public UnitOfWork uow { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }

        public WebApiDBEntities dBEntities;

        public UserService()
        {
            this.dBEntities = new WebApiDBEntities();
            this.uow = new UnitOfWork(dBEntities);
        }


        //public List<UserDTO> getAllUsers()
        //{
        //    IEnumerable<UserMaster> users = uow.Users.GetAll();
        //    List<UserDTO> results = new List<UserDTO>();

        //    foreach (UserMaster user in users)
        //    {
        //        UserDTO userDTO = new UserDTO()
        //        {
        //            UserID = user.UserID,
        //            UserName = user.UserName,
        //            UserPassword = user.UserPassword,
        //            UserEmailID = user.UserEmailID,
        //            UserRoles = user.UserRoles
        //        };
        //        results.Add(userDTO);
        //    }

        //    return results;
        //}

        public List<UserService> getAllUsers()
        {
            //IEnumerable<UserMaster> users = uow.Users.GetAll();
            //List<UserDTO> results = new List<UserDTO>();

            var results = uow.Users.GetAll();

            return (List<UserService>)results;//(IEnumerable<UserService>)results.ToList();
        }


    }
}
