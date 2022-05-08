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

        public WebApiDBEntities dBEntities;

        public UserService()
        {
            this.dBEntities = new WebApiDBEntities();
            this.uow = new UnitOfWork(dBEntities);
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
    }
}
