using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AutoMapper;
using ServiceInterfaces.DataViewModel;
using WebAPI_Tutorial.Models;

namespace WebAPI_Tutorial.Provider
{
    public class UserMasterRepository : IDisposable
    {
        UserService context = new UserService();

        public UserModel ValidateUser(string username, string password)
        {
            var UserD = context.ValidateUser(username, password);
            var UserM = new UserModel()
            {
                UserID = UserD.UserID,
                UserEmailID = UserD.UserEmailID,
                UserPassword = UserD.UserPassword,
                UserName = UserD.UserName
            };
            return UserM;
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}